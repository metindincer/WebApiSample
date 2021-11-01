using CRUDAPI.Models;
using CRUDAPI.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        IUserRepository userRepository;
        public CRUDController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetUsers()
        {
            List<User> allUsers= userRepository.GetAllUsers();
            return Ok(allUsers);
        }
        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int userId)
        {
            User user = userRepository.GetUserById(userId);
            return Ok(user);
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
            userRepository.AddUser(user);
            return Ok(user);
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int userId)
        {
            userRepository.RemoveUser(userId);
            return Ok();
        }

        [HttpPut("UpdateUser")]
        public IActionResult SetUser(User user)
        {
            userRepository.UpdateUser(user);
            return Ok(user);
        }


    }
}
