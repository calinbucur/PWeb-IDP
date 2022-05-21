using Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal;
using Petaway.Api.Features.OwnersAnimals.Animal.ViewOwnerAnimals;
using Petaway.Api.Features.OwnersAnimals.Animal.ViewRescuableAnimals;
using Petaway.Api.Features.OwnersAnimals.Owner.RegisterOwner;
using Microsoft.Extensions.DependencyInjection;

namespace Petaway.Api.Features.Owners
{
    internal static class OwnersModule
    {
        internal static void AddOwnersAnimalsHandlers(this IServiceCollection services)
        {
            var a = 2;

            services.AddTransient<IAddAnimalCommandHandler, AddAnimalCommandHandler>();

            services.AddTransient<IRegisterOwnerCommandHandler, RegisterOwnerCommandHandler>();

            services.AddTransient<IViewOwnerAnimalsCommandHandler, ViewOwnerAnimalsCommandHandler>();

            services.AddTransient<IViewRescuableAnimalsCommandHandler, ViewRescuableAnimalsCommandHandler>();

        }
    }
}
