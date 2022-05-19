using Petaway.Api.Features.Rescuers.RegisterRescuer;
using Microsoft.Extensions.DependencyInjection;

namespace Petaway.Api.Features.Rescuers
{
    internal static class RescuersModule
    {
        internal static void AddRescuersHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRegisterRescuerCommandHandler, RegisterRescuerCommandHandler>();
        }
    }
}
