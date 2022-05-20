﻿using System.Security.Claims;

namespace Petaway.Api.Authorization
{
    public static class UserIdentityExtensions
    {
        public static string? GetUserIdentityId(this ClaimsPrincipal user) => user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value.Split("|")[1];
    }
}
