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
        private readonly IAuthorizationService _authorizationService;

        public UserController(IUserService baseService, IAuthorizationService AuthService): base(baseService)
        {
            _userService = baseService;
            _authorizationService = AuthService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("admin")]
        public async Task<ActionResult<UserReadDto>> CreateAdmin([FromBody] UserCreateDto user)
        {
            return CreatedAtAction(nameof(CreateAdmin), await _userService.CreateAdmin(user));
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll([FromQuery] Options queryOptions)
        {
            return Ok(await _userService.GetAll(queryOptions));
        }

        [Authorize]
        public override async Task<ActionResult<UserReadDto>> Update([FromRoute]Guid id,[FromBody] UserUpdateDto updateItem)
        {
            var user = HttpContext.User;
            var order = await _userService.GetById(id);
            /* resource based authorization here */
            var authorizeOwner = await _authorizationService.AuthorizeAsync(user,order, "UserOnly");
             if(authorizeOwner.Succeeded)
            {
                return await _userService.UpdateItem(id, updateItem);
            }
            else
            {
                return new ForbidResult();
            } 
        }

        [Authorize]
        public override async Task<ActionResult<UserReadDto>> DeleteById([FromRoute]Guid id)
        {
            var user = HttpContext.User;
            var order = await _userService.GetById(id);
            /* resource based authorization here */
            var authorizeOwner = await _authorizationService.AuthorizeAsync(user,order, "UserOnly");
             if(authorizeOwner.Succeeded)
            {
                await _userService.DeleteItem(id);
                return StatusCode(204);
            }
            else
            {
                return new ForbidResult();
            } 
        }
        
    }
}