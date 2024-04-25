using GradeUp.Entities;
using GradeUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectService subjectService;

        public SubjectController()
        {
            subjectService = new SubjectService();
        }

        [HttpGet("name/{name}")]
        public IActionResult getSubjectByName(string name)
        {
            Subject subject = subjectService.getSubjectByName(name);

            if (subject != null)
            {
                return Ok(subject);
            }
            return NotFound("Subject not found!");
        }

        [HttpGet("year/{year}")]
        public IActionResult getSubjectByYear(int year)
        {
            List<Subject> subject = subjectService.getSubjectByYear(year);

            if (subject != null)
            {
                if(subject.Count == 0)
                {
                    return NoContent();
                }
                return Ok(subject);
            }
            return NotFound("Subject is not teached in the year selected.");
        }

        [HttpGet("faculty/{faculty}")]
        public IActionResult getSubjectByFaculty(string faculty)
        {
            List<Subject> subject = subjectService.getSubjectByFaculty(faculty);

            if (subject != null)
            {
                if (subject.Count == 0)
                {
                    return NoContent();
                }
                return Ok(subject);
            }
            return NotFound("Subject is not teached at the faculty that you selected.");
        }

        [HttpGet("id/{id}")]
        public IActionResult getSubjectById(long id) 
        {
            Subject subject = subjectService.getSubjectById(id);

            if (subject != null)
            {
                return Ok(subject);
            }
            return NotFound("Subject not found.");
        }

        /*[HttpDelete("id/{id}")]
        public async Task<ActionResult<Subject>> DeleteSubject(int id)
        {
            if(id < 1)
            {
                return BadRequest();
            }
            
            try
            {
                Subject toDelete = subjectService.getSubjectById(id);

                if (toDelete == null)
                {
                    return NotFound($"Subject with Id = {id} not found");
                }

                subjectService.deleteSubjectById(id);
                return Ok("The subject was deleted!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/
    }
}
