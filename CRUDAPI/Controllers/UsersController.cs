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
    public class UsersController : ControllerBase
    {
        private bool check = false;
        IUserRepository userRepository;
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            List<User> allUsers = userRepository.GetAllUsers();
            if (allUsers != null)
            {
                return Ok(allUsers);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            User user = userRepository.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            var createdResource = new { Id = user.UserId };
            var actionName = nameof(GetUserById);
            var routeValues = new { id = createdResource.Id };
            userRepository.AddUser(user);
            return CreatedAtAction(actionName, routeValues, user);


        }

        [HttpPut("{id}")]
        public IActionResult SetUser(int id,[FromBody]User user)
        {
            check = userRepository.UpdateUser(id,user);
            if (check)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            check = userRepository.RemoveUser(id);

            if (check)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
