using Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal;
using Petaway.Api.Features.OwnersAnimals.Owner.RegisterOwner;
using Microsoft.Extensions.DependencyInjection;

namespace Petaway.Api.Features.Owners
{
    internal static class OwnersModule
    {
        internal static void AddOwnersAnimalsHandlers(this IServiceCollection services)
        {
            services.AddTransient<IAddAnimalCommandHandler, AddAnimalCommandHandler>();

            services.AddTransient<IRegisterOwnerCommandHandler, RegisterOwnerCommandHandler>();
        }
    }
}
