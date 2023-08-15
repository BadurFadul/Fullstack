using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApi.Business.Src.Dtos;

namespace WebApi.WebApi.AuthorizationRequirement
{
    public class OrderOwerOnly: IAuthorizationRequirement
    {
        
    }
    public class OrderOwerOnlyHandler : AuthorizationHandler<OrderOwerOnly, OrderReadDto>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OrderOwerOnly requirement, OrderReadDto resource)
        {
            var authenticatedUser = context.User;
            var userId = authenticatedUser.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            if(resource.user.UserId.ToString() == userId)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}