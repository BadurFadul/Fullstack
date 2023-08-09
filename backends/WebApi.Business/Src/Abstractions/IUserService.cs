using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Abstractions
{
    public interface IUserService: IBaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        Task<UserReadDto> UpdatePassword(string id, string password);
    }
}