using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApi.Business.Src.Dtos;

namespace WebApi.WebApi.AuthorizationRequirement
{
    public class UserOnly: IAuthorizationRequirement
    {
        
    }

    public class UserOnlyHandler : AuthorizationHandler<UserOnly, UserReadDto>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserOnly requirement, UserReadDto resource)
        {
            var authenticatedUser = context.User;
            var userId = authenticatedUser.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            if(resource.Id.ToString() == userId)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}