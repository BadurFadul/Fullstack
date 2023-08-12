using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;

namespace WebApi.Controller.Src.Controllers
{
    public class ReviewController: CrudController<Review, ReviewReadDto, ReviewCreateDto, ReviewUpdateDto>
    {
        public ReviewController(IReviewService reviewService):base(reviewService)
        {}
    }
}