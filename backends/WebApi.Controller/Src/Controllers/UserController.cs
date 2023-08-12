using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Src.Shared;  

namespace WebApi.Controller.Src.Controllers
{
    public class UserController:CrudController<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        private readonly IUserService _userService;
        public UserController(IUserService baseService): base(baseService)
        {
            _userService = baseService;
        }

        [Authorize]
        public override async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll([FromQuery] Options queryOptions)
        {
            return Ok(await _userService.GetAll(queryOptions));
        }
    }
}