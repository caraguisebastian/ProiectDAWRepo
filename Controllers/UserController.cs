using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.DTO;
using ProiectDAW.Services.UserService;
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
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            var result = await _userService.Get();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(Guid id)
        {
            var result = await _userService.GetById(id);
            return Ok(result);
        }


        [HttpPost]
        public ActionResult<UserDTO> Post(UserDTO user)
        {
            _userService.Create(user);

            return Ok(user);
        }

        [HttpPut]
        public ActionResult<UserDTO> Put([FromBody] UserDTO user)
        {
            _userService.Update(user);
            return Ok(user);
        }


        [HttpDelete("{id}")]
        public ActionResult<UserDTO> Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok(id);
        }
    }
}
