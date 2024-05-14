using GradeUp.Entities;
using GradeUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GradeUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingController : ControllerBase
    {
        private readonly TeachingService teachingService;
        public TeachingController()
        {
            teachingService = new TeachingService();
        }

        [HttpGet("id/{id}")]
        public IActionResult getTeachingById(long id)
        {
            Teaching teaching = teachingService.getById(id);
            if (teaching != null)
            {
                return Ok(teaching);
            }
            return NotFound("Teaching not found.");
        }

        [HttpGet("user/id/{id_user}")]
        public IActionResult getTeachingByIdUser(long id_user)
        {
            List<Teaching> teaching = teachingService.getByIdUser(id_user);
            if (teaching.Count != 0)
            {
                return Ok(teaching);
            }
            return NotFound("Teaching not found.");
        }

        [HttpGet("subject/id/{id_subject}")]
        public IActionResult getTeachingByIdSubject(long id_subject)
        {
            List<Teaching> teaching = teachingService.getByIdSubject(id_subject);
            if (teaching.Count != 0)
            {
                return Ok(teaching);
            }
            return NotFound("Teaching not found.");
        }

        [HttpPost]
        public IActionResult addTeaching(Teaching teaching)
        {
            try
            {
                if (teaching == null)
                {
                    return BadRequest("Invalid teaching information.");
                }
                teachingService.add_teaching(teaching);
                return Ok("The teaching was added.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult updateTeaching(Teaching teaching)
        {
            try
            {
                if (teaching == null)
                {
                    return BadRequest("Invalid teaching information.");
                }
                teachingService.update_teaching(teaching);
                return Ok("The teaching's information was updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id/{id}")]
        public IActionResult deleteTeachingById(long id)
        {
            try
            {
                Teaching teaching = teachingService.getById(id);
                if(teaching == null)
                {
                    return NotFound("The teaching you wanted to be deleted was not found.");
                }

                teachingService.deleteById(id);
                return Ok("The teaching you have selected was deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id_user/{id_user}")]
        public IActionResult deleteTeachingByIdUser(long id_user)
        {
            try
            {
                List<Teaching> teaching = teachingService.getByIdUser(id_user);
                if (teaching.Count == 0)
                {
                    return NotFound("The teaching you wanted to be deleted was not found.");
                }

                teachingService.deleteByIdUser(id_user);
                return Ok("The teaching you have selected was deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("id_subject/{id_subject}")]
        public IActionResult deleteTeachingByIdSubject(long id_subject)
        {
            try
            {
                List<Teaching> teaching = teachingService.getByIdSubject(id_subject);
                if (teaching.Count == 0)
                {
                    return NotFound("The teaching you wanted to be deleted was not found.");
                }

                teachingService.deleteByIdSubject(id_subject);
                return Ok("The teaching you have selected was deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
