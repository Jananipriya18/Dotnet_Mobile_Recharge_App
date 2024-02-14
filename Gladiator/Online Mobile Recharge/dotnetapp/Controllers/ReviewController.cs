using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
 
namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
 
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
 
   //     [Authorize(Roles = "Admin")]
        // [HttpGet]
        // public async Task<IActionResult> GetAllReviews()
        // {
        //     var reviews = await _reviewService.GetAllReviewsAsync();
        //     return Ok(reviews);
        // }
        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            try
            {
                var reviews = await _reviewService.GetAllReviewsAsync();
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving reviews: {ex.Message}");
            }
        }
 
    //    [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] Review review)
        {
            var addedReview = await _reviewService.AddReviewAsync(review);
            return Ok(addedReview);
        }
    }
}