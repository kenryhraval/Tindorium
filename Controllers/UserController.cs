using Microsoft.AspNetCore.Mvc;
using System.Net.Cache;
using Tindorium.Data;

namespace Tindorium.API.Controllers
{
    [ApiController]
    [Route("[controller]")]//localhost:7157/User 
    public class UserController : ControllerBase //[controller] == User
    {
        private UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
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
        [Route("GetUser/{id}")]
        public User GetUser(int id)
        {
            var user = _userRepository.GetById(id);

            return user;
        }

        [HttpPost]
        [Route("AddUser")]
        public User AddUser([FromBody] UserDTO user)//localhost:7157/AddUser    body-> {"name": "vārds"}
        {
            var userEntity = new User()
            {
                Name = user.Name,
                Surname = user.Surname,
                Age = user.Age
            };

            _userRepository.Add(userEntity);
            return userEntity;
        }

        [HttpPost]
        [Route("Test")]
        public string Test()
        {
            return "test data";
        }

        [HttpGet]
        [Route("GetPotentionalMatch")]
        public User GetPotentionalMatch()
        {
            return _userRepository.GetPotentionalMatch();
        }


        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Delete(user);
            return NoContent();
        }
    }
}

public class UserDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; } ///small int
}