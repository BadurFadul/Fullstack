using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;

namespace WebApi.Controller.Src.Controllers
{
    public class ShippingController: CrudController<Shipping, ShippingReadDto, ShippingCreateDto, ShippingUpdateDto>
    {
        public ShippingController(IShippingService  shippingService):base(shippingService)
        {}
    }
}