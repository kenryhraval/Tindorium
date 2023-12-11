﻿using Microsoft.AspNetCore.Mvc;
using Tindorium.Data;

namespace Tindorium.API.Controllers
{
    [ApiController]
    [Route("[controller]")]//localhost:7157/User 
    public class UserController : ControllerBase //[controller] == User
    {
        //Get, POST, 
        [HttpGet]
        [Route("Ping")]
        public string Ping() //localhost:7157/User/Ping
        {
            return "PONG";
        }

        [HttpGet]
        [Route("Pong")]//localhost:7157/User/Pong/123/asd
        public string Pong()
        {
            return "PING";
        }

        [HttpGet]
        [Route("GetUser")]//localhost:7157/User/GetUser?id=12
        public string GetUser(int id)
        {
            return "pārstrādāts " + id;
        }

        [HttpPost]
        [Route("AddUser")]
        public string AddUser([FromBody] UserDTO user)//localhost:7157/AddUser    body-> {"name": "vārds"}
        {
            return "user name " + user.Name;
        }

        [HttpPost]
        [Route("Test")]
        public string Test()
        {
            return "test data";
        }
    }
}

public class UserDTO
{
    public string Name { get; set; }
}