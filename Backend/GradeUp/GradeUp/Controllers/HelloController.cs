using GradeUp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GradeUp.Controllers
{
    [ApiController]
    [Route("hello")]
    public class HelloController : ControllerBase
    {
        [HttpGet("world")]
        public Hello hello()
        {
            return new Hello("Hello World!");
        }
    }
}
