using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Src.Shared;

namespace WebApi.Controller.Src.Controllers
{
    public class PaymentController: CrudController<Payment, PaymentReadDto, PaymentCreateDto, PaymentUpdateDto>
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService): base(paymentService)
        {
            _paymentService = paymentService;
        }

        [Authorize(Roles ="Admin")]
        public override async Task<ActionResult<IEnumerable<PaymentReadDto>>> GetAll([FromQuery]Options queryOptions)
        {
            return Ok(await _paymentService.GetAll(queryOptions));
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<PaymentReadDto>> GetById([FromRoute] Guid id)
        {
            return Ok(await _paymentService.GetById(id));
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<PaymentReadDto>> Post([FromBody]PaymentCreateDto item)
        {
            var createdObject = await _paymentService.postItem(item);
            return CreatedAtAction(nameof(Post), createdObject);
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<PaymentReadDto>> Update([FromRoute]Guid id,[FromBody] PaymentUpdateDto updateItem)
        {
            var updatedObject = _paymentService.UpdateItem(id, updateItem);
            return Ok(updateItem);
        }

        [Authorize(Roles = "Client")]
        public override async Task<ActionResult<PaymentReadDto>> DeleteById([FromRoute]Guid id)
        {
            return StatusCode(204,await _paymentService.DeleteItem(id));
        }
    }
}