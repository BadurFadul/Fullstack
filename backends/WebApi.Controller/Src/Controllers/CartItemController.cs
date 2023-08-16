using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Src.Shared;

namespace WebApi.Controller.Src.Controllers
{
    public class CartItemController: CrudController<CartItem,CartItemReadDto, CartItemCreateDto, CartItemUpdateDto>
    {
        private readonly ICartItemService _cartItemService;
        public CartItemController(ICartItemService CartService): base(CartService)
        {
            _cartItemService = CartService;
        }

        [Authorize(Roles ="Admin")]
        public override async Task<ActionResult<IEnumerable<CartItemReadDto>>> GetAll([FromQuery]Options queryOptions)
        {
            return Ok(await _cartItemService.GetAll(queryOptions));
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<CartItemReadDto>> GetById([FromRoute] Guid id)
        {
            return Ok(await _cartItemService.GetById(id));
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<CartItemReadDto>> Post([FromBody]CartItemCreateDto item)
        {
            var createdObject = await _cartItemService.postItem(item);
            return CreatedAtAction(nameof(Post), createdObject);
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<CartItemReadDto>> Update([FromRoute]Guid id,[FromBody] CartItemUpdateDto updateItem)
        {
            var updatedObject = _cartItemService.UpdateItem(id, updateItem);
            return Ok(updateItem);
        }
        
        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<CartItemReadDto>> DeleteById([FromRoute]Guid id)
        {
            return StatusCode(204,await _cartItemService.DeleteItem(id));
        }
    }
}