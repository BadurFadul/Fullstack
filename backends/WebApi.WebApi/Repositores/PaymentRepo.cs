using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
using WebApi.WebApi.Database;

namespace WebApi.WebApi.Repositores
{
    public class PaymentRepo : BaseRepo<Payment>, IPaymentRepo
    {
        private readonly DbSet<Payment> _payment;
        private readonly DatabaseContext _context;
        public PaymentRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _payment = dbContext.Payments;
            _context = dbContext;
        }
    }
}