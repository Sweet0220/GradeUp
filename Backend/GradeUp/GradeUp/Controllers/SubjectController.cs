using GradeUp.Entities;
using GradeUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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

        [HttpPost]
        public IActionResult addSubject(Subject subject)
        {
            try
            {
                if(subject == null)
                {
                    return BadRequest("Invalid subject data.");
                }
                subjectService.addSubject(subject);
                return Ok("New subject added!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPut]
        public IActionResult updateSubject(Subject subject) 
        {
            try
            {
                if (subject == null)
                {
                    return BadRequest("Invalid subject data.");
                }
                subjectService.updateSubject(subject);
                return Ok("The subject's data was updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id/{id}")]
        public IActionResult deleteSubjectById(long id)
        {
            try
            {
                Subject subject = subjectService.getSubjectById(id);
                if (subject == null)
                {
                    return NotFound("Subject not found.");
                }
                subjectService.removeSubject(id);
                return Ok("The subject chat was deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
