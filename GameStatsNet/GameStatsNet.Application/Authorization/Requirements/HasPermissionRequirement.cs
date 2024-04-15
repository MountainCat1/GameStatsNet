using Microsoft.AspNetCore.Authorization;

namespace GameStatsNet.Application.Authorization.Requirements;

public class HasPermissionRequirement : IAuthorizationRequirement
{
    public string Permission { get; }

    public HasPermissionRequirement(string permission)
    {
        Permission = permission;
    }
}