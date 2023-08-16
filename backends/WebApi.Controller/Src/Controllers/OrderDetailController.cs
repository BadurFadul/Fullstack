using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Src.Shared;

namespace WebApi.Controller.Src.Controllers
{
    public class OrderDetailController: CrudController<OrderDetail, OrderDetailReadDto, OrderDetailCreateDto, OrderDetailUpdateDto>
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailController(IOrderDetailService orderDetailService): base(orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<IEnumerable<OrderDetailReadDto>>> GetAll([FromQuery]Options queryOptions)
        {
            return Ok(await _orderDetailService.GetAll(queryOptions));
        }
        [Authorize(Roles ="Admin")]
        public override async Task<ActionResult<OrderDetailReadDto>> GetById([FromRoute] Guid id)
        {
            return Ok(await _orderDetailService.GetById(id));
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<OrderDetailReadDto>> Post([FromBody]OrderDetailCreateDto item)
        {
            var createdObject = await _orderDetailService.postItem(item);
            return CreatedAtAction(nameof(Post), createdObject);
        }

        [Authorize(Roles ="Client")]
        public override async Task<ActionResult<OrderDetailReadDto>> Update([FromRoute]Guid id,[FromBody] OrderDetailUpdateDto updateItem)
        {
            var updatedObject = _orderDetailService.UpdateItem(id, updateItem);
            return Ok(updateItem);
        }

        [Authorize(Roles ="Client")]
        public override async Task<ActionResult<OrderDetailReadDto>> DeleteById([FromRoute]Guid id)
        {
            return StatusCode(204,await _orderDetailService.DeleteItem(id));
        }
    }
}