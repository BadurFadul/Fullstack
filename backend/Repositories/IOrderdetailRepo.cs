using backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repositories
{
    public interface IOrderdetailRepo
    {
        Task<ActionResult<IEnumerable<OrderDetail>>> GetAllOrderDetails();
        Task<ActionResult<OrderDetail>> GetOrderDetail(Guid id);
        Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail OrderDetail);
        Task<ActionResult<OrderDetail>> PutOrderDetail(Guid id, OrderDetail OrderDetail);
        Task<IActionResult> DeleteOrderDetail(Guid id);
    }
}