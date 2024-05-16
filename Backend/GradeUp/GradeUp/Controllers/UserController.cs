using GradeUp.Entities;
using GradeUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        public UserController()
        {
            userService = new UserService();    
        }

        [HttpGet("email/{email}")]
        public IActionResult getUserByEmail(string email)
        {
            Users user = userService.getByEmail(email);
            if(user != null)
            {
                return Ok(user);
            }
            return NotFound("User not found!");
        }

        [HttpGet("id/{id}")]
        public IActionResult getUserById(long id)
        {
            Users user = userService.getById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User not found!");
        }

        [HttpGet("username/{username}")]
        public IActionResult getUserByUsername(string username)
        {
            Users user = userService.getByUsername(username);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User not found!");
        }

        [HttpDelete("id/{id}")]
        public IActionResult deleteUserById(long id)
        {
            try
            {
                Users user = userService.getById(id);
                if (user == null) 
                {
                    return NotFound("The user you wanted to be deleted was not found.");
                }

                userService.deleteById(id);
                return Ok("The user you have selected was deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult addUser(Users user)
        {
            try
            {
               if (user == null)
               {
                    return BadRequest("Invalid user information.");
               }
               userService.add_user(user);
               return Ok("The user was added.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult updateUser(Users user) 
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Invalid user information.");
                }
                userService.update_user(user);
                return Ok("The user's information was updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
