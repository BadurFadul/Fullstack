using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Implementations
{
    public class ShoppingCartService : BaseService<ShoppingCart, ShoppingCartDto>
    {
        public ShoppingCartService(IBaseRepo<ShoppingCart> baseRepo, IMapper mapper) : base(baseRepo, mapper)
        {
        }
    }
}