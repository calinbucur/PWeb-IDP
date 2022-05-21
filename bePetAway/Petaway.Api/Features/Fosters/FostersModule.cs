using Petaway.Api.Features.Fosters.RegisterFoster;
using Petaway.Api.Features.Fosters.GetFoster;
using Petaway.Api.Features.Fosters.UpdateFoster;
using Microsoft.Extensions.DependencyInjection;

namespace Petaway.Api.Features.Fosters
{
    internal static class FostersModule
    {
        internal static void AddFostersHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRegisterFosterCommandHandler, RegisterFosterCommandHandler>();
            services.AddTransient<IUpdateFosterCommandHandler, UpdateFosterCommandHandler>();
            services.AddTransient<IGetFosterCommandHandler, GetFosterCommandHandler>();
        }
    }
}
