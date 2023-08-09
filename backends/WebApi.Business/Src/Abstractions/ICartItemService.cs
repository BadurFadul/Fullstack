using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Abstractions
{
    public interface ICartItemService: IBaseService<CartItem, CartItemReadDto, CartItemCreateDto, CartItemUpdateDto>
    {
        
    }
}