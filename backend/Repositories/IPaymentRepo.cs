using backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repositories
{
    public interface IPaymentRepo
    {
        Task<ActionResult<IEnumerable<Payment>>> GetAllPayment();
        Task<ActionResult<Payment>> GetPayment(Guid id);
        Task<ActionResult<Payment>> PostPayment(Payment Payment);
        Task<ActionResult<Payment>> PutPayment(Guid id, Payment Payment);
        Task<IActionResult> DeletePayment(Guid id);
    }
}