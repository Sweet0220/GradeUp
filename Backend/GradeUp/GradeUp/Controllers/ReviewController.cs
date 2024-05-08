using GradeUp.Entities;
using GradeUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService reviewService;
        public ReviewController()
        {
            reviewService = new ReviewService();    
        }

        [HttpGet("id/{id}")]
        public IActionResult getTeachingById(long id)
        {
            Review review = reviewService.getById(id);
            if (review != null)
            {
                return Ok(review);
            }
            return NotFound("Review not found.");
        }

        [HttpGet("review/id/{id_user}")]
        public IActionResult getReviewByIdUser(long id_user)
        {
            List<Review> review = reviewService.getByIdUser(id_user);
            if (review.Count != 0)
            {
                return Ok(review);
            }
            return NotFound("Review not found.");
        }

        [HttpPost]
        public IActionResult addReview(Review review)
        {
            try
            { 
                reviewService.add_review(review);
                return Ok("The review was added.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult updateReview(Review review)
        {
            try
            {
                if (review == null)
                {
                    return BadRequest("Invalid review information.");
                }
                reviewService.update_review(review);
                return Ok("The review's information was updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id/{id}")]
        public IActionResult deleteReviewById(long id)
        {
            try
            {
                Review review = reviewService.getById(id);
                if (review == null)
                {
                    return NotFound("The review you wanted to be deleted was not found.");
                }

                reviewService.deleteById(id);
                return Ok("The review you have selected was deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id_user/{id_user}")]
        public IActionResult deleteReviewByIdUser(long id_user)
        {
            try
            {
                List<Review> review = reviewService.getByIdUser(id_user);
                if (review.Count == 0)
                {
                    return NotFound("The review you wanted to be deleted was not found.");
                }

                reviewService.deleteByIdUser(id_user);
                return Ok("The review you have selected was deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
