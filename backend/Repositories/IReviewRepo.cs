using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repositories
{
    public interface IReviewRepo
    {
        Task<ActionResult<IEnumerable<Review>>> GetAllReviews();
        Task<ActionResult<Review>> GetReview(Guid id);
        Task<ActionResult<Review>> PostReview(Review Review);
        Task<ActionResult<Review>> PutReview(Guid id, Review Review);
        Task<IActionResult> DeleteReview(Guid id);
    }
}