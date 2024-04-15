using GameStatsNet.Application.Authorization.Handlers;
using GameStatsNet.Application.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace GameStatsNet.Application.Authorization.Extensions
{
    public static class AuthorizationPoliciesDefiner
    {
        public static IServiceCollection DefineAuthorizationPolicies(this IServiceCollection services)
        {
            // TODO: Replace placeholder
            // Example:
            // services.AddSingleton<IAuthorizationHandler, IsOrganizerOfHandler>();
            services.AddSingleton<IAuthorizationHandler, HasPermissionAuthorizationHandler>();

            services.AddAuthorization(DefineAuthorizationPolicies);

            return services;
        }


        private static void AddPolicyWithRequirements(
            this AuthorizationOptions policyBuilder,
            string policyName,
            IAuthorizationRequirement[] requirements)
        {
            policyBuilder.AddPolicy(policyName, builder => { builder.AddRequirements(requirements); });
        }

        private static void DefineAuthorizationPolicies(AuthorizationOptions options)
        {
            options.AddPolicyWithRequirements(Policies.CreateGameMatch, new IAuthorizationRequirement[]
            {
                new HasPermissionRequirement(Permissions.CreateGameMatch)
            });
        }
    }
}