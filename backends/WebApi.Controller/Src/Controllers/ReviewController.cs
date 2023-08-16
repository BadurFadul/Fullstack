using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;
using Microsoft.AspNetCore.Authorization;
using WebApi.Domain.Src.Shared;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller.Src.Controllers
{
    public class ReviewController: CrudController<Review, ReviewReadDto, ReviewCreateDto, ReviewUpdateDto>
    {
        private readonly IReviewService _reviewService;
        private readonly IAuthorizationService _authorizationService;
        public ReviewController(IReviewService reviewService, IAuthorizationService authService):base(reviewService)
        {
            _reviewService = reviewService;
            _authorizationService = authService;
        }

        [AllowAnonymous]
         public override async Task<ActionResult<IEnumerable<ReviewReadDto>>> GetAll([FromQuery]Options queryOptions)
        {
            return Ok(await _reviewService.GetAll(queryOptions));
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<ReviewReadDto>> GetById([FromRoute] Guid id)
        {
            return Ok(await _reviewService.GetById(id));
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<ReviewReadDto>> Post([FromBody]ReviewCreateDto item)
        {
            var createdObject = await _reviewService.postItem(item);
            return CreatedAtAction(nameof(Post), createdObject);
        }

        [Authorize]
        public override async Task<ActionResult<ReviewReadDto>> Update([FromRoute]Guid id,[FromBody] ReviewUpdateDto updateItem)
        {
            var user = HttpContext.User;
            var order = await _reviewService.GetById(id);
            /* resource based authorization here */
            var authorizeOwner = await _authorizationService.AuthorizeAsync(user,order, "OnlyReviewOwner");
             if(authorizeOwner.Succeeded)
            {
                return await _reviewService.UpdateItem(id, updateItem);
            }
            else
            {
                return new ForbidResult();
            } 
        }

        [Authorize]
        public override async Task<ActionResult<ReviewReadDto>> DeleteById([FromRoute]Guid id)
        {
            var user = HttpContext.User;
            var order = await _reviewService.GetById(id);
            /* resource based authorization here */
            var authorizeOwner = await _authorizationService.AuthorizeAsync(user,order, "OnlyReviewOwner");
             if(authorizeOwner.Succeeded)
            {
                await _reviewService.DeleteItem(id);
                return StatusCode(204);
            }
            else
            {
                return new ForbidResult();
            } 
        }
    }
}