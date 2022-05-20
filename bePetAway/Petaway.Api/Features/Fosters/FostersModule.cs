using Petaway.Api.Features.Fosters.RegisterFoster;
using Microsoft.Extensions.DependencyInjection;

namespace Petaway.Api.Features.Fosters
{
    internal static class FostersModule
    {
        internal static void AddFostersHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRegisterFosterCommandHandler, RegisterFosterCommandHandler>();
        }
    }
}
