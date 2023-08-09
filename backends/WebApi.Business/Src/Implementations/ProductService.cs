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
    public class ProductService : BaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {
        public ProductService(IBaseRepo<Product> baseRepo, IMapper mapper) : base(baseRepo, mapper)
        {
        }
    }
}