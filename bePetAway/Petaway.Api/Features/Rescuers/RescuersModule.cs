using Petaway.Api.Features.Rescuers.RegisterRescuer;
using Petaway.Api.Features.Rescuers.GetRescuer;
using Petaway.Api.Features.Rescuers.GetRescuerExternal;
using Petaway.Api.Features.Rescuers.UpdateRescuer;
using Petaway.Api.Features.Rescuers.ViewRescuerFinishedTransports;
using Petaway.Api.Features.Rescuers.ViewRescuerPendingTransports;
using Petaway.Api.Features.Rescuers.TakeTransport;
using Petaway.Api.Features.Rescuers.FinishTransport;

using Microsoft.Extensions.DependencyInjection;

namespace Petaway.Api.Features.Rescuers
{
    internal static class RescuersModule
    {
        internal static void AddRescuersHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRegisterRescuerCommandHandler, RegisterRescuerCommandHandler>();
            services.AddTransient<IGetRescuerCommandHandler, GetRescuerCommandHandler>();
            services.AddTransient<IGetRescuerExternalCommandHandler, GetRescuerExternalCommandHandler>();
            services.AddTransient<IUpdateRescuerCommandHandler, UpdateRescuerCommandHandler>();
            services.AddTransient<IViewRescuerFinishedTransportsCommandHandler, ViewRescuerFinishedTransportsCommandHandler>();
            services.AddTransient<IViewRescuerPendingTransportsCommandHandler, ViewRescuerPendingTransportsCommandHandler>();
            services.AddTransient<IViewRescuerFinishedTransportsCommandHandler, ViewRescuerFinishedTransportsCommandHandler>();
            services.AddTransient<IViewRescuerPendingTransportsCommandHandler, ViewRescuerPendingTransportsCommandHandler>();
            services.AddTransient<ITakeTransportCommandHandler, TakeTransportCommandHandler>();
            services.AddTransient<IFinishTransportCommandHandler, FinishTransportCommandHandler>();
        }
    }
}
