using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repositories
{
    public interface IShippingRepo
    {
        Task<ActionResult<IEnumerable<Shipping>>> GetAllShipping();
        Task<ActionResult<Shipping>> GetShipping(Guid id);
        Task<ActionResult<Shipping>> PostShipping(Shipping Shipping);
        Task<ActionResult<Shipping>> PutShipping(Guid id, Shipping Shipping);
        Task<IActionResult> DeleteShipping(Guid id);
    }
}