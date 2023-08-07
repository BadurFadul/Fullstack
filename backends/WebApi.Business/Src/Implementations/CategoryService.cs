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
    public class CategoryService : BaseService<Category, CategoryDto>
    {
        public CategoryService(IBaseRepo<Category> baseRepo, IMapper mapper) : base(baseRepo, mapper)
        {
        }
    }
}