using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Petaway.Api.Authorization
{
    public static class AuthorizationExtensions
    {
        public static void AddAuthenticationAndAuthorization(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = builder.Configuration["Auth:Authority"];
                options.Audience = builder.Configuration["Auth:Audience"];
            });

            // Add Authorization configuration: TODO => Pentru Foster/Rescuer/Owner
            builder.Services.AddAuthorization(configure =>
            {
                configure.AddPolicy("FosterAccess", policy => policy.RequireClaim("permissions", "access::foster"));
                configure.AddPolicy("OwnerAccess", policy => policy.RequireClaim("permissions", "access::owner"));
                configure.AddPolicy("RescuerAccess", policy => policy.RequireClaim("permissions", "access::rescuer"));
            });

        }

        public static void UseAuthenticationAndAuthorization(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
