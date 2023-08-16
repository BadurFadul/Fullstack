using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Src.Shared;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controller.Src.Controllers
{
    public class ShoppingCartController: CrudController<ShoppingCart, ShoppingCartReadDto, ShoppingCartCreateDto, ShoppingCartUpdateDto>
    {
        private readonly IShoppingCartService _shoppingCart;
        public ShoppingCartController(IShoppingCartService shoppingCartService): base(shoppingCartService)
        {
            _shoppingCart = shoppingCartService;
        }

        [Authorize(Roles ="Admin")]
        public override async Task<ActionResult<IEnumerable<ShoppingCartReadDto>>> GetAll([FromQuery]Options queryOptions)
        {
            return Ok(await _shoppingCart.GetAll(queryOptions));
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<ShoppingCartReadDto>> GetById([FromRoute] Guid id)
        {
            return Ok(await _shoppingCart.GetById(id));
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<ShoppingCartReadDto>> Post([FromBody]ShoppingCartCreateDto item)
        {
            var createdObject = await _shoppingCart.postItem(item);
            return CreatedAtAction(nameof(Post), createdObject);
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<ShoppingCartReadDto>> Update([FromRoute]Guid id,[FromBody] ShoppingCartUpdateDto updateItem)
        {
            var updatedObject = _shoppingCart.UpdateItem(id, updateItem);
            return Ok(updateItem);
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<ShoppingCartReadDto>> DeleteById([FromRoute]Guid id)
        {
            return StatusCode(204,await _shoppingCart.DeleteItem(id));
        }
    }
}