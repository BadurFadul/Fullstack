using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Src.Shared;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controller.Src.Controllers
{
    public class OrderController: CrudController<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        private readonly IOrderService _orderService;
        private readonly IAuthorizationService _authorizationService;
        public OrderController(IOrderService orderService, IAuthorizationService authService): base(orderService)
        {
            _authorizationService = authService;
            _orderService = orderService;
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAll([FromQuery]Options queryOptions)
        {
            return Ok(await _orderService.GetAll(queryOptions));
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<OrderReadDto>> Post([FromBody]OrderCreateDto item)
        {
            var createdObject = await _orderService.postItem(item);
            return CreatedAtAction(nameof(Post), createdObject);
        }

        [Authorize]
        public override async Task<ActionResult<OrderReadDto>> Update([FromRoute]Guid id,[FromBody] OrderUpdateDto updateItem)
        {
            var user = HttpContext.User;
            var order = await _orderService.GetById(id);
            /* resource based authorization here */
            var authorizeOwner = await _authorizationService.AuthorizeAsync(user,order, "OrderOwnerOnly");
             if(authorizeOwner.Succeeded)
            {
                return await _orderService.UpdateItem(id, updateItem);
            }
            else
            {
                return new ForbidResult();
            } 
        }

        [Authorize]
        public override async Task<ActionResult<OrderReadDto>> DeleteById([FromRoute]Guid id)
        {
            var user = HttpContext.User;
            var order = await _orderService.GetById(id);
            /* resource based authorization here */
            var authorizeOwner = await _authorizationService.AuthorizeAsync(user,order, "OrderOwnerOnly");
             if(authorizeOwner.Succeeded)
            {
                await _orderService.DeleteItem(id);
                return StatusCode(204);
            }
            else
            {
                return new ForbidResult();
            } 
        }

    }
}