using Microsoft.AspNetCore.Mvc;

namespace Tindorium.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("Ping")]
        public string Ping()
        {
            return "PONG";
        }

        [HttpGet]
        [Route("Pong")]
        public string Pong()
        {
            return "PING";
        }
        
        [HttpGet]
        [Route ("GetUser")]
        public string GetUser(string id)
        {
            return "pārstrādāts " + id;
        }

        
    }
}
