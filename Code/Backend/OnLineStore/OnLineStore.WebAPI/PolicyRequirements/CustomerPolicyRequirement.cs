﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace OnLineStore.WebAPI.PolicyRequirements
{
#pragma warning disable CS1591
    public class CustomerPolicyRequirement : AuthorizationHandler<CustomerPolicyRequirement>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomerPolicyRequirement requirement)
        {
            if (context.User.HasClaim(claim => claim.Type == "role" && claim.Value == "Customer"))
                context.Succeed(requirement);
            else
                context.Fail();

            return Task.FromResult(0);
        }
    }
#pragma warning restore CS1591
}
