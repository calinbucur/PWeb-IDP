using Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal;
using Petaway.Api.Features.OwnersAnimals.Owner.RegisterOwner;
using Microsoft.Extensions.DependencyInjection;

namespace Petaway.Api.Features.Owner
{
    internal static class OwnersModule
    {
        internal static void AddAnimalsHandlers(this IServiceCollection services)
        {
//            services.AddTransient<IAddAnimalCommandHandler, AddAnimalCommandHandler>();

            services.AddTransient<IRegisterOwnerCommandHandler, RegisterOwnerCommandHandler>();
        }
    }
}
