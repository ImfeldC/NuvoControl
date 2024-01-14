using Microsoft.AspNetCore.Mvc;
using NuvoControl.Common;
using NuvoControl.Common.Configuration;
using NuvoControl.Server.ZoneServer;
using System.Security.Policy;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NuvoControl.Server.WebConsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebZoneController : ControllerBase
    {

        // GET api/Zone/5
        [HttpGet("{zoneId}")]
        public ZoneState Get(string zoneId)
        {
            if(NuvoControlController.ZoneServer != null )
            {
                return NuvoControlController.ZoneServer.GetZoneState(new Address(zoneId) );
            }
            return null;
        }

        // PUT api/Zone/5
        [HttpPut("{zoneId}")]
        public void Put(string zoneId, [FromBody] ZoneState value)
        {
            if (NuvoControlController.ZoneServer != null)
            {
                NuvoControlController.ZoneServer.SetZoneState(new Address(zoneId),value);
            }
        }
    }
}
