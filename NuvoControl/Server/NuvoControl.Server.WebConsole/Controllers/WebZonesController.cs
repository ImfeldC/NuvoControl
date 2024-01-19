﻿using Microsoft.AspNetCore.Mvc;
using NuvoControl.Common;
using NuvoControl.Common.Configuration;
using System.Collections.Generic;
using System.Runtime.Serialization;
using static NuvoControl.Common.LogHelper;
using LogLevel = NuvoControl.Common.LogHelper.LogLevel;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NuvoControl.Server.WebConsole.Controllers
{
    [Route("api/Zones")]
    [ApiController]
    public class WebZonesController : ControllerBase
    {
        private void LogZoneState(string zoneId, string message, params object[] args)
        {
            // String.Format("GET api/Zones/{0}", zoneId)
            // String.Format("PUT api/Zones/{0}/SetVolume/{1}", zoneId, volume)
            LogHelper.Log(LogLevel.Debug, message, args);

            if (NuvoControlController.ZoneServer != null)
            {
                ZoneState zoneStatus = NuvoControlController.ZoneServer.GetZoneState(new Address(zoneId));
                Zone zone = NuvoControlController.ConfgurationServer.GetZoneHWConfiguration(new Address(zoneId));
                //Source source = NuvoControlController.ConfgurationServer.GetSourceHWConfiguration(e.ZoneState.Source);
                LogHelper.Log(LogLevel.Debug, ">>>   [{0}]  Zone '{1}'({2})  ZoneStatus={3}", DateTime.Now.ToShortTimeString(), zoneId, zone.Name, zoneStatus );
            }
        }

        // GET api/Zones
        [HttpGet]
        public Dictionary<string, ZoneState> Get()
        {
            if(NuvoControlController.ZoneServer != null )
            {
                // NOTE: There is/was an issue to serialize 'complex keys' in Dictionariy list; but 'string' as key works.
                //       Because of that, I copy the dictionary into a new list, with 'string' as key.
                Dictionary<Address, ZoneState> _zoneStatesDictionary = NuvoControlController.ZoneServer.GetZoneStates();
                Dictionary<string, ZoneState> _zoneStates = new Dictionary<string, ZoneState>();
                foreach( var item in _zoneStatesDictionary)
                {
                    _zoneStates.Add(item.Key.ToString(), item.Value);
                }
                return _zoneStates;
            }
            return null;
        }

        // GET api/Zones/{zoneId}
        [HttpGet("{zoneId}")]
        public ZoneState Get(string zoneId)
        {
            LogZoneState(zoneId, "GET api/Zones/{0}", zoneId);

            if (NuvoControlController.ZoneServer != null)
            {
                return NuvoControlController.ZoneServer.GetZoneState(new Address(zoneId));
            }
            return null;
        }

        // PUT api/Zones/{zoneId}
        [HttpPut("{zoneId}")]
        public ZoneState Put(string zoneId, [FromBody] ZoneState value)
        {
            LogZoneState(zoneId, "PUT api/Zones/{0}", zoneId);

            if (NuvoControlController.ZoneServer != null)
            {
                NuvoControlController.ZoneServer.SetZoneState(new Address(zoneId),value);
                return NuvoControlController.ZoneServer.GetZoneState(new Address(zoneId));
            }
            return new ZoneState();
        }

        // PUT api/Zones/{zoneId}/SetVolume/{volume}
        [HttpPut]
        [Route("api/Zones/{zoneId}/SetVolume/{volume}")]
        public ZoneState PutZoneVolume(string zoneId, int volume)
        {
            LogZoneState(zoneId, "PUT api/Zones/{0}/SetVolume/{1}", zoneId, volume);

            if (NuvoControlController.ZoneServer != null)
            {
                ZoneState zonestate = NuvoControlController.ZoneServer.GetZoneState(new Address(zoneId));
                zonestate.Volume = volume;  
                NuvoControlController.ZoneServer.SetZoneState(new Address(zoneId), zonestate);
                return NuvoControlController.ZoneServer.GetZoneState(new Address(zoneId));
            }
            return new ZoneState();
        }

        // PUT api/Zones/{zoneId}/SetSource/{sourceId}
        [HttpPut]
        [Route("api/Zones/{zoneId}/SetSource/{sourceId}")]
        public ZoneState PutZoneVolume(string zoneId, string sourceId)
        {
            LogZoneState(zoneId, "PUT api/Zones/{0}/SetSource/{1}", zoneId, sourceId);

            if (NuvoControlController.ZoneServer != null)
            {
                ZoneState zonestate = NuvoControlController.ZoneServer.GetZoneState(new Address(zoneId));
                zonestate.Source = new Address(sourceId);
                NuvoControlController.ZoneServer.SetZoneState(new Address(zoneId), zonestate);
                return NuvoControlController.ZoneServer.GetZoneState(new Address(zoneId));
            }
            return new ZoneState();
        }

    }
}
