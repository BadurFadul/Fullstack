using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Implementations
{
    public class OrderService : BaseService<Order, OrderDto>
    {
        public OrderService(Domain.Src.Abstractions.IBaseRepo<Order> baseRepo, IMapper mapper) : base(baseRepo, mapper)
        {
        }
    }
}