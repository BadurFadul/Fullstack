using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Implementations
{
    public class ShippingService : BaseService<Shipping, ShippingReadDto, ShippingCreateDto, ShippingUpdateDto>
    {
        public ShippingService(Domain.Src.Abstractions.IBaseRepo<Shipping> baseRepo, IMapper mapper) : base(baseRepo, mapper)
        {
        }
    }
}