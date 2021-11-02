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
        private bool check = false;
        IUserRepository userRepository;
        public CRUDController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetUsers()
        {
            List<User> allUsers= userRepository.GetAllUsers();
            if(allUsers!=null)
            {
                return Ok(allUsers);
            }
            return NotFound();
        }
        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int userId)
        {
            User user = userRepository.GetUserById(userId);
            if(user!=null)
            {
                return Ok(user);
            }
            return NotFound();
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
           check= userRepository.RemoveUser(userId);

            if(check)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("UpdateUser")]
        public IActionResult SetUser(User user)
        {
          check=  userRepository.UpdateUser(user);
            if(check)
            {
                return Ok(user);
            }
            return NotFound();
        }


    }
}
