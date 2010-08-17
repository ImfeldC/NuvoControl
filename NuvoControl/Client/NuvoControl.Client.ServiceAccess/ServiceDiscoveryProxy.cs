﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Discovery;

using Common.Logging;
using NuvoControl.Common;


namespace NuvoControl.Client.ServiceAccess
{
    /// <summary>
    /// Class to handle the discovery service for one or more types.
    /// </summary>
    public class ServiceDiscoveryProxy
    {
        /// <summary>
        /// Delegate for asynchronous call of DiscoverService method
        /// </summary>
        /// <param name="discoverType">Type to retrieve.</param>
        /// <returns>Endpoints found for the specified type.</returns>
        private delegate FindResponse DelegateDiscoverService(Type discoverType);

        /// <summary>
        /// Clas used as entyr in the list.
        /// </summary>
        private class ServiceDiscoveryEntry
        {
            /// <summary>
            /// True if the disovery service was already executed once.
            /// </summary>
            private bool _serviceDiscovered = false;

            /// <summary>
            /// Type to discover.
            /// </summary>
            private Type _discoverType;

            /// <summary>
            /// Contains the discovered endpoints for the specified type.
            /// Is null if the discovery service wasn't executed so far.
            /// </summary>
            private FindResponse _discoveredServices = null;

            /// <summary>
            /// Result used in case of asynchronous calls.
            /// </summary>
            private IAsyncResult _tag = null;


            /// <summary>
            /// Constructor, for the specified type.
            /// </summary>
            /// <param name="discoverType">Type to discover.</param>
            public ServiceDiscoveryEntry(Type discoverType)
            {
                _discoverType = discoverType;
            }

            /// <summary>
            /// True, if the discovery service was once executed for the specified type.
            /// </summary>
            public bool ServiceDiscovered
            {
                get { return _serviceDiscovered; }
            }

            /// <summary>
            /// Returns the type to discover.
            /// </summary>
            public Type DiscoverType
            {
                get { return _discoverType; }
            }

            /// <summary>
            /// Gets and Sets the found endpoints for the specified type.
            /// </summary>
            public FindResponse DiscoveredServices
            {
                get { return _discoveredServices; }
                set 
                { 
                    _discoveredServices = value;
                    _serviceDiscovered = true;
                }
            }

            /// <summary>
            /// Gets and Sets the result set for asynchronous calls.
            /// </summary>
            public IAsyncResult AsynchResult
            {
                get { return _tag; }
                set { _tag = value; }
            }
        }

        /// <summary>
        /// Trace logger
        /// </summary>
        private static ILog _log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// List with the types to discover.
        /// </summary>
        private List<ServiceDiscoveryEntry> _serviceDiscoveryList = null;

        /// <summary>
        /// Constructor. Creates an empty list of types to discover.
        /// Add the types with the addService method.
        /// </summary>
        public ServiceDiscoveryProxy()
        {
            _serviceDiscoveryList = new List<ServiceDiscoveryEntry>();
        }

        /// <summary>
        /// Add a type to the list which will be discovered later.
        /// </summary>
        /// <param name="discoverType">Type to discover.</param>
        public void addService(Type discoverType)
        {
            _serviceDiscoveryList.Add(new ServiceDiscoveryEntry(discoverType));
        }


        /// <summary>
        /// Returns true if the specified type was already discovered.
        /// </summary>
        /// <param name="discoverType">Type to discover.</param>
        /// <returns>True if type ahs been discovered.</returns>
        public bool isServiceDiscovered(Type discoverType)
        {
            bool bRet = false;
            foreach (ServiceDiscoveryEntry serviceDiscoveryEntry in _serviceDiscoveryList)
            {
                if (serviceDiscoveryEntry.DiscoverType == discoverType)
                {
                    bRet = serviceDiscoveryEntry.ServiceDiscovered;
                    break;
                }
            }
            return bRet;
        }

        /// <summary>
        /// Returns the discovered endpoints for the specified type.
        /// Returns null if the discovery servcie wasn't executed so far.
        /// </summary>
        /// <param name="discoverType">Type to discover.</param>
        /// <returns>Discovered endpoints for the specified type.</returns>
        public FindResponse ServiceEndpoints(Type discoverType)
        {
            FindResponse res = null;
            foreach (ServiceDiscoveryEntry serviceDiscoveryEntry in _serviceDiscoveryList)
            {
                if (serviceDiscoveryEntry.DiscoverType == discoverType)
                {
                    res = serviceDiscoveryEntry.DiscoveredServices;
                    break;
                }
            }
            return res;
        }

        /// <summary>
        /// Public discovery method, starts the discovery service for all types in the list.
        /// Add the types with the addService method.
        /// </summary>
        /// <param name="bEnforceDiscovery">If true, enforces a new discovery even if it was already executed.</param>
        public void DiscoverAllServices(bool bEnforceDiscovery)
        {
            _log.Trace(m => m("DiscoverAllServices: Start discovering [bEnforceDiscovery={0}] ...", bEnforceDiscovery.ToString()));

            // create the delegate
            DelegateDiscoverService delDiscoverService = new DelegateDiscoverService(DiscoverService);

            // Start asynchronous the discover service for each type
            foreach (ServiceDiscoveryEntry serviceDiscoveryEntry in _serviceDiscoveryList)
            {
                if (!serviceDiscoveryEntry.ServiceDiscovered || bEnforceDiscovery)
                {
                    //serviceDiscoveryEntry.DiscoveredServices = DiscoverService(serviceDiscoveryEntry.DiscoverType);
                    serviceDiscoveryEntry.AsynchResult = delDiscoverService.BeginInvoke(serviceDiscoveryEntry.DiscoverType, null, null);
                }
                else
                {
                    // delete a previous existing result
                    serviceDiscoveryEntry.AsynchResult = null;
                }
            }

            // Wait for each discover service
            foreach (ServiceDiscoveryEntry serviceDiscoveryEntry in _serviceDiscoveryList)
            {
                serviceDiscoveryEntry.DiscoveredServices = delDiscoverService.EndInvoke(serviceDiscoveryEntry.AsynchResult);
            }

            _log.Trace(m => m("DiscoverAllServices: End discovering ..."));
        }

        /// <summary>
        /// Discovery method for the service.
        /// </summary>
        /// <param name="discoverType">Type to discover.</param>
        /// <returns>Returns the discovered endpoints.</returns>
        private FindResponse DiscoverService(Type discoverType)
        {
            // ------- DISCOVERY ----------

            _log.Trace(m => m("DiscoverService: Start discovering {0} ...", discoverType.ToString()));

            DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());
            FindCriteria criteria = new FindCriteria(discoverType);
            FindResponse discovered = discoveryClient.Find(criteria);
            discoveryClient.Close();

            _log.Trace(m => m("DiscoverService: {0} services found.", discovered.Endpoints.Count));
            LogHelper.LogEndPoint(_log, discovered.Endpoints);

            // ----------------------------

            return discovered;
        }

    }
}
