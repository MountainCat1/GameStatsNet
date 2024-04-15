using GameStatsNet.Application.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace GameStatsNet.Application.Authorization.Handlers;

public class HasPermissionAuthorizationHandler : AuthorizationHandler<HasPermissionRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        HasPermissionRequirement requirement)
    {
        var claim = context.User.FindFirst(c => c.Type == requirement.Permission);
        if (claim is null)
        {
            context.Fail();
            return;
        }
        
        if(claim.Value != "true")
        {
            context.Fail();
            return;
        }
        
        
        context.Succeed(requirement);
    }
}