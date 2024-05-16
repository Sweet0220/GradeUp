using GradeUp.Models;
using GradeUp.Repository.Implementation;
using GradeUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService authenticationService;
        public AuthenticationController()
        {
            authenticationService = new AuthenticationService();
        }

        [HttpPost("login")]
        public IActionResult userVerification(AuthenticationEntity request)
        {
            try
            {
                var user = authenticationService.getUserByMailPassword(request);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                    return BadRequest("The credentials you had entered were incorrect. Please try again.");
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid credentials.");
            }


        }
    }
}
