using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;

namespace WebApi.WebApi.Configuration
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<User,UserReadDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserCreateDto, User>();
        }
    }
}