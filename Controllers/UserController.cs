using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<UserDTO> users = new List<UserDTO>
        {
            new UserDTO { Id = 1, Name = "Name1", Username = "username1", Password = "parola1", PhoneNumber = "0721",  Email = "email1", AddressId = 1,},
            new UserDTO { Id = 2, Name = "Name2", Username = "username2", Password = "parola2", PhoneNumber = "0722",  Email = "email2", AddressId = 2,},
            new UserDTO { Id = 3, Name = "Name3", Username = "username3", Password = "parola3", PhoneNumber = "0723",  Email = "email3", AddressId = 3,},
            new UserDTO { Id = 4, Name = "Name4", Username = "username4", Password = "parola4", PhoneNumber = "0724",  Email = "email4", AddressId = 4,}
        };

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var result = users.Where(_user => _user.Id.Equals(id))
                .Select(_user => _user);
            var user = new UserDTO();
            if (result.ToList().Count <= 0)
            {
                return NoContent();
            }
            user = result.ToList()[0];
            return Ok(user);
        }


        [HttpPost]
        public ActionResult<UserDTO> Post(UserDTO user)
        {
            users.Add(user);

            return Ok(users);
        }

        [HttpPut]
        public ActionResult<UserDTO> Put([FromBody] UserDTO user)
        {
            var userIndex = users.FindIndex((UserDTO _user) => _user.Id.Equals(user.Id));
            if (userIndex < 0) {
                return NoContent();
            }
            users[userIndex] = user;
            return Ok(users);
        }


        [HttpDelete("{id}")]
        public ActionResult<UserDTO> Delete(int id)
        {
            var result = users.Where(_user => _user.Id.Equals(id))
                .Select(_user => _user);
            var user = new UserDTO();
            if (result.ToList().Count <= 0)
            {
                return NoContent();
            }
            user = result.ToList()[0];
            users.Remove(user);
            return Ok(users);
        }
    }
}
