using Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal;
using Petaway.Api.Features.OwnersAnimals.Animal.ViewOwnerAnimals;
using Petaway.Api.Features.OwnersAnimals.Animal.ViewRescuableAnimals;
using Petaway.Api.Features.OwnersAnimals.Animal.GetOwnerSpecificAnimal;
using Petaway.Api.Features.OwnersAnimals.Animal.GetOwnerSpecificAnimalByDbId;
using Petaway.Api.Features.OwnersAnimals.Animal.UpdateOwnerSpecificAnimal;

using Petaway.Api.Features.OwnersAnimals.Owner.RegisterOwner;
using Petaway.Api.Features.OwnersAnimals.Owner.GetOwner;
using Petaway.Api.Features.OwnersAnimals.Owner.GetOwnerExternal;
using Petaway.Api.Features.OwnersAnimals.Owner.UpdateOwner;
using Microsoft.Extensions.DependencyInjection;

namespace Petaway.Api.Features.Owners
{
    internal static class OwnersModule
    {
        internal static void AddOwnersAnimalsHandlers(this IServiceCollection services)
        {
            services.AddTransient<IAddAnimalCommandHandler, AddAnimalCommandHandler>();

            services.AddTransient<IRegisterOwnerCommandHandler, RegisterOwnerCommandHandler>();

            services.AddTransient<IViewOwnerAnimalsCommandHandler, ViewOwnerAnimalsCommandHandler>();

            services.AddTransient<IViewRescuableAnimalsCommandHandler, ViewRescuableAnimalsCommandHandler>();

            services.AddTransient<IGetOwnerCommandHandler, GetOwnerCommandHandler>();

            services.AddTransient<IUpdateOwnerCommandHandler, UpdateOwnerCommandHandler>();

            services.AddTransient<IGetOwnerExternalCommandHandler, GetOwnerExternalCommandHandler>();

            services.AddTransient<IGetOwnerSpecificAnimalCommandHandler, GetOwnerSpecificAnimalCommandHandler>();

            services.AddTransient<IGetOwnerSpecificAnimalByDbIdCommandHandler, GetOwnerSpecificAnimalByDbIdCommandHandler>();

            services.AddTransient<IUpdateOwnerSpecificAnimalCommandHandler, UpdateOwnerSpecificAnimalCommandHandler>();
        }
    }
}
