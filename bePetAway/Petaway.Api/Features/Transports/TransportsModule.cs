using Petaway.Api.Features.Transports.ViewDisponibleTransports;
using Petaway.Api.Features.Transports.GetSpecificTransportByDbId;
using Microsoft.Extensions.DependencyInjection;

namespace Petaway.Api.Features.Transports
{
    internal static class TransportsModule
    {
        internal static void AddTransportsHandlers(this IServiceCollection services)
        {
            services.AddTransient<IViewDisponibleTransportsCommandHandler, ViewDisponibleTransportsCommandHandler>();
            services.AddTransient<IGetSpecificTransportByDbIdCommandHandler, GetSpecificTransportByDbIdCommandHandler>();

        }
    }
}
