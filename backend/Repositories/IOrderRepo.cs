using backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repositories
{
    public interface IOrderRepo
    {
        Task<ActionResult<IEnumerable<Order>>> GetAllOrders();
        Task<ActionResult<Order>> GetOrder(Guid id);
        Task<ActionResult<Order>> PostOrder(Order Order);
        Task<ActionResult<Order>> PutOrder(Guid id, Order Order);
        Task<IActionResult> DeleteOrder(Guid id);
    }
}