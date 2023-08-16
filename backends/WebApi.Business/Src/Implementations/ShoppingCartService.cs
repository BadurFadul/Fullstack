using AutoMapper;
using WebApi.Business.Src.Abstractions;
using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Implementations
{
    public class ShoppingCartService : BaseService<ShoppingCart, ShoppingCartReadDto,ShoppingCartCreateDto,ShoppingCartUpdateDto>, IShoppingCartService
    {
        public ShoppingCartService(IBaseRepo<ShoppingCart> baseRepo, IMapper mapper) : base(baseRepo, mapper)
        {
        }
    }
}