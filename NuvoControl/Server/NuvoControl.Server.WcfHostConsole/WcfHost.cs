﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using Common.Logging;

using NuvoControl.Common.Configuration;
using NuvoControl.Server.WcfService;
using NuvoControl.Server.Service;
using NuvoControl.Server.Service.Configuration;
using NuvoControl.Server.ProtocolDriver.Interface;
using NuvoControl.Server.Service.MandC;
using NuvoControl.Server.Service.Zones;


namespace NuvoControl.Server.WcfService
{
    class WcfHost
    {
        #region Fields

        private static ILog _log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Holds the loaded system configuration.
        /// </summary>
        private static ConfigurationService _configurationService = null;

        /// <summary>
        /// Holds the protocol drivers per NuvoEssentia.
        /// </summary>
        private static Dictionary<int, IProtocol> _protocolDrivers = new Dictionary<int, IProtocol>();

        /// <summary>
        /// Holds a reference to the zone server.
        /// </summary>
        private static IZoneServer _zoneServer = null;

        #endregion

        #region Non-Public Interface

        static void Main(string[] args)
        {
            Console.WriteLine(">>> Starting WCF services...");
            Console.WriteLine();

            try
            {
                LoadConfigurationService(@"..\..\..\..\Config\NuvoControlKonfiguration.xml");
            }
            catch (Exception exc)
            {
                _log.ErrorFormat("Failed to load the system configuration.", exc);
                Console.WriteLine("Failed to load the system configuration. Exception message: {0}", exc.Message);
            }

            try
            {
                LoadProtocolDrivers();
            }
            catch (Exception exc)
            {
                _log.ErrorFormat("Failed to load the protocol drivers.", exc);
                Console.WriteLine("Failed to load the protocol drivers. Exception message: {0}", exc.Message);
            }

            try
            {
                InstantiateZoneServer();
            }
            catch (Exception exc)
            {
                _log.ErrorFormat("Failed to create the zone server.", exc);
                Console.WriteLine("Failed to create the zone server. Exception message: {0}", exc.Message);
            }
            Console.WriteLine();

            ServiceHost configurationServiceHost = new ServiceHost(_configurationService);
            ServiceHostMc mCServiceHost = new ServiceHostMc(typeof(MonitorAndControlService), _zoneServer);

            try
            {
                configurationServiceHost.Open();
                Console.WriteLine(">>> Configuration service is running.");
                Console.WriteLine(">>> URI: {0}", configurationServiceHost.BaseAddresses[0].AbsoluteUri);
                Console.WriteLine();

                mCServiceHost.Open();
                Console.WriteLine(">>> Monitor and control service is running.");
                Console.WriteLine(">>> URI: {0}", mCServiceHost.BaseAddresses[0].AbsoluteUri);
                Console.WriteLine();

                Console.WriteLine(">>> Press <Enter> to stop the services.");
                Console.ReadLine();
            }
            catch (Exception exc)
            {
                _log.ErrorFormat("Failed to start services.", exc);
                Console.WriteLine("Failed to start services. Exception message: {0}", exc.Message); 
            }
            finally
            {
                configurationServiceHost.Close();
                mCServiceHost.Close();
            }
           

/*
            NuvoControlService ncService = new NuvoControlService();
            ncService.StartUp(@"..\..\..\..\Config\NuvoControlKonfiguration.xml");
            

            using (ServiceHost serviceHost = new ServiceHost(ncService))
            {
                serviceHost.Open();
                Console.WriteLine("**** WCF Service is running. *******");
                Console.WriteLine("URI: {0}", serviceHost.BaseAddresses[0].AbsoluteUri);



            }
 */   
        }


        /// <summary>
        /// Reads the XML configuration file and instantiates accordingly the system configuration objects of NuvoControl.
        /// </summary>
        /// <param name="configurationFile"></param>
        private static void LoadConfigurationService(string configurationFile)
        {
            _log.Info("Loading the nuvo control configuration...");
            Console.WriteLine(">>> Loading configuration...");

            _configurationService = new ConfigurationService(configurationFile);
        }

        /// <summary>
        /// Loads the protocol drivers according to the NuvoControl system configuration.
        /// </summary>
        private static void LoadProtocolDrivers()
        {
            _log.Info("Loading protocol drivers...");
            Console.WriteLine(">>> Loading protocol drivers...");

            foreach (NuvoEssentia device in _configurationService.SystemConfiguration.Hardware.Devices)
            {
                IProtocol driver = ProtocolDriverFactory.LoadDriver(device.ProtocolDriver.AssemblyName, device.ProtocolDriver.ClassName);
                if (driver != null)
                {
                    driver.Open(ENuvoSystem.NuVoEssentia, device.Id, device.Communication);
                    _protocolDrivers[device.Id] = driver;
                }
            }
        }


        
        /// <summary>
        /// Instantiates the the zone server. This object holds all zone controllers.
        /// </summary>
        private static void InstantiateZoneServer()
        {
            _log.Info("Instantiating the zone server...");
            Console.WriteLine(">>> Instantiating the zone server...");

            List<IZoneController> zoneControllers = new List<IZoneController>();
            foreach (NuvoEssentia device in _configurationService.SystemConfiguration.Hardware.Devices)
            {
                foreach (int zoneId in device.Zones)
                {
                    zoneControllers.Add(new ZoneController(new Address(device.Id, zoneId), _protocolDrivers[device.Id]));
                }
            }
            _zoneServer = new ZoneServer(zoneControllers);
        }


        #endregion
    }
}
