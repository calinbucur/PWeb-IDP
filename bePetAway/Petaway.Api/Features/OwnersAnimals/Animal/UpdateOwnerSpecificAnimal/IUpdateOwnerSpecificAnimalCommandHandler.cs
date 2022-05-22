using Petaway.Core.Domain;

namespace Petaway.Api.Features.OwnersAnimals.Animal.UpdateOwnerSpecificAnimal
{
    public interface IUpdateOwnerSpecificAnimalCommandHandler
    {
        public Task HandleAsync(UpdateOwnerSpecificAnimalDto command, string identityId, CancellationToken cancellation);
    }
}
