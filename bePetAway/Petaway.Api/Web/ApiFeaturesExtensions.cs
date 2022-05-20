using Microsoft.Extensions.DependencyInjection;
using Petaway.Api.Features.Owners;
using Petaway.Api.Features.Fosters;
using Petaway.Api.Features.Rescuers;


namespace Petaway.Api.Web
{
    public static class ApiFeaturesExtensions
    {
        public static void AddApiFeaturesHandlers(this IServiceCollection services)
        {
            // Add Animals Handlers
            services.AddOwnersAnimalsHandlers();
            
            services.AddFostersHandlers();

            services.AddRescuersHandlers();

        }
    }
}
