using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;

namespace WebApi.Controller.Src.Controllers
{
    public class ShoppingCartController: CrudController<ShoppingCart, ShoppingCartReadDto, ShoppingCartCreateDto, ShoppingCartUpdateDto>
    {
        public ShoppingCartController(IShoppingCartService shoppingCartService): base(shoppingCartService)
        {}
    }
}