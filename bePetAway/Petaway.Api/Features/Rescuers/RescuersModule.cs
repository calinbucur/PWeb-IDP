using Petaway.Api.Features.Rescuers.RegisterRescuer;
using Petaway.Api.Features.Rescuers.GetRescuer;
using Petaway.Api.Features.Rescuers.UpdateRescuer;
using Microsoft.Extensions.DependencyInjection;

namespace Petaway.Api.Features.Rescuers
{
    internal static class RescuersModule
    {
        internal static void AddRescuersHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRegisterRescuerCommandHandler, RegisterRescuerCommandHandler>();
            services.AddTransient<IGetRescuerCommandHandler, GetRescuerCommandHandler>();
            services.AddTransient<IUpdateRescuerCommandHandler, UpdateRescuerCommandHandler>();
        }
    }
}
