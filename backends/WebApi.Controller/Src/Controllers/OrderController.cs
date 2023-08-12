using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;

namespace WebApi.Controller.Src.Controllers
{
    public class OrderController: CrudController<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        public OrderController(IOrderService orderService): base(orderService)
        {}
    }
}