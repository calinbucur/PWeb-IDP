using Microsoft.Extensions.DependencyInjection;
using Petaway.Api.Features.Owner;


namespace Petaway.Api.Web
{
    public static class ApiFeaturesExtensions
    {
        public static void AddApiFeaturesHandlers(this IServiceCollection services)
        {
            // Add Animals Handlers
            services.AddAnimalsHandlers();

        }
    }
}
