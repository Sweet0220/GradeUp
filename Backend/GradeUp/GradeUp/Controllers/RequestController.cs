using GradeUp.Entities;
using GradeUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly RequestService requestService;
        public RequestController()
        {
            requestService = new RequestService();
        }

        [HttpGet("id/{id}")]
        public IActionResult getRequestById(long id)
        {
            Request request = requestService.getById(id);
            if (request != null)
            {
                return Ok(request);
            }
            return NotFound("Request not found.");
        }

        [HttpGet("trainer/id/{id_user1}")]
        public IActionResult getRequestByIdUser1(long id_user1)
        {
            List<Request> request = requestService.getByIdUser1(id_user1);
            if (request.Count != 0)
            {
                return Ok(request);
            }
            return NotFound("Request not found.");
        }

        [HttpGet("trainee/id/{id_user2}")]
        public IActionResult getRequestByIdUser2(long id_user2)
        {
            List<Request> request = requestService.getByIdUser2(id_user2);
            if (request.Count != 0)
            {
                return Ok(request);
            }
            return NotFound("Request not found.");
        }

        [HttpPost]
        public IActionResult addRequest(Request request)
        {
            try
            {
                requestService.add_request(request);
                return Ok("The request was added.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult updateRequest(Request request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request information.");
                }
                requestService.update_request(request);
                return Ok("The request's information was updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id/{id}")]
        public IActionResult deleteRequestById(long id)
        {
            try
            {
                Request request = requestService.getById(id);
                if (request == null)
                {
                    return NotFound("The request you wanted to be deleted was not found.");
                }

                requestService.deleteById(id);
                return Ok("The request you have selected was deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("user/id/{id_user}")]
        public IActionResult deleteRequestByIdUser(long id_user)
        {
            try
            {
                requestService.deleteByIdUser(id_user);
                return Ok("The request you have selected was deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
