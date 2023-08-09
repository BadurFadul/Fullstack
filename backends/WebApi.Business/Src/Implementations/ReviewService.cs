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
    public class ReviewService : BaseService<Review, ReviewReadDto, ReviewCreateDto, ReviewUpdateDto>
    {
        public ReviewService(IBaseRepo<Review> baseRepo, IMapper mapper) : base(baseRepo, mapper)
        {
        }
    }
}