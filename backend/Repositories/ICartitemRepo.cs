using backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repositories
{
    public interface ICartitemRepo
    {
        Task<ActionResult<IEnumerable<CartItem>>> GetAllCartItems();
        Task<ActionResult<CartItem>> GetCartItem(Guid id);
        Task<ActionResult<CartItem>> PostCartItem(CartItem CartItem);
        Task<ActionResult<CartItem>> PutCartItem(Guid id, CartItem CartItem);
        Task<IActionResult> DeleteCartItem(Guid id);
    }
}