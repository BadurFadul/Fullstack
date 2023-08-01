using backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repositories
{
    public interface IShoppingCartRepo
    {
        Task<ActionResult<IEnumerable<ShoppingCart>>> GetAllShoppingCarts();
        Task<ActionResult<ShoppingCart>> GetShoppingCart(Guid id);
        Task<ActionResult<ShoppingCart>> PostShoppingCart(ShoppingCart ShoppingCart);
        Task<ActionResult<ShoppingCart>> PutShoppingCart(Guid id, ShoppingCart ShoppingCart);
        Task<IActionResult> DeleteShoppingCart(Guid id);
    }
}