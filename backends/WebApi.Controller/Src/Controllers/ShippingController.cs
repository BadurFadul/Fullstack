using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Domain.Src.Shared;

namespace WebApi.Controller.Src.Controllers
{
    public class ShippingController: CrudController<Shipping, ShippingReadDto, ShippingCreateDto, ShippingUpdateDto>
    {
        private readonly IShippingService _shippingService;
        public ShippingController(IShippingService  shippingService):base(shippingService)
        {
            _shippingService = shippingService;
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<IEnumerable<ShippingReadDto>>> GetAll([FromQuery]Options queryOptions)
        {
            return Ok(await _shippingService.GetAll(queryOptions));
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<ShippingReadDto>> GetById([FromRoute] Guid id)
        {
            return Ok(await _shippingService.GetById(id));
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<ShippingReadDto>> Post([FromBody]ShippingCreateDto item)
        {
            var createdObject = await _shippingService.postItem(item);
            return CreatedAtAction(nameof(Post), createdObject);
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<ShippingReadDto>> Update([FromRoute]Guid id,[FromBody] ShippingUpdateDto updateItem)
        {
            var updatedObject = _shippingService.UpdateItem(id, updateItem);
            return Ok(updateItem);
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<ShippingReadDto>> DeleteById([FromRoute]Guid id)
        {
            return StatusCode(204,await _shippingService.DeleteItem(id));
        }
    }
}