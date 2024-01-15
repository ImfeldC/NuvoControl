using Microsoft.AspNetCore.Mvc;
using Common.Logging;
using NuvoControl.Common;
using NuvoControl.Common.Configuration;
using NuvoControl.Server.ConfigurationService;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Runtime.Serialization;
using LogLevel = Common.Logging.LogLevel;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NuvoControl.Server.WebConsole.Controllers
{
    [Route("api/Zones")]
    [ApiController]
    public class WebZonesController : ControllerBase
    {
        private void LogZoneState(string zoneId, string message)
        {
            if (NuvoControlController.ZoneServer != null)
            {
                ZoneState zoneStatus = NuvoControlController.ZoneServer.GetZoneState(new Address(zoneId));
                Zone zone = NuvoControlController.ConfgurationServer.GetZoneHWConfiguration(new Address(zoneId));
                //Source source = NuvoControlController.ConfgurationServer.GetSourceHWConfiguration(e.ZoneState.Source);
                LogHelper.Log(LogLevel.Debug, String.Format(">>>   [{0}]  Zone '{1}'({2})  {3}: {4}", DateTime.Now.ToShortTimeString(), zoneId, zone.Name, message, zoneStatus.ToString()));
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

        // c api/Zones/5
        [HttpGet("{zoneId}")]
        public ZoneState Get(string zoneId)
        {
            LogZoneState(zoneId, String.Format("GET api/Zones/{0}", zoneId));

            if (NuvoControlController.ZoneServer != null)
            {
                return NuvoControlController.ZoneServer.GetZoneState(new Address(zoneId));
            }
            return null;
        }

        // PUT api/Zones/5
        [HttpPut("{zoneId}")]
        public void Put(string zoneId, [FromBody] ZoneState value)
        {
            LogZoneState(zoneId, String.Format("PUT api/Zones/{0}", zoneId));

            if (NuvoControlController.ZoneServer != null)
            {
                NuvoControlController.ZoneServer.SetZoneState(new Address(zoneId),value);
                NuvoControlController.ZoneServer.GetZoneState(new Address(zoneId));
            }
        }
    }
}
