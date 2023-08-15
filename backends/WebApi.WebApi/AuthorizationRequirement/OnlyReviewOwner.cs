using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApi.Business.Src.Dtos;

namespace WebApi.WebApi.AuthorizationRequirement
{
    public class OnlyReviewOwner: IAuthorizationRequirement
    {
        
    }

    public class OnlyReviewOwnerHandler : AuthorizationHandler<OnlyReviewOwner, ReviewReadDto>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyReviewOwner requirement, ReviewReadDto resource)
        {
            var authenticatedUser = context.User;
            var userId = authenticatedUser.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            if(resource.Users.UserId.ToString() == userId)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}