using Petaway.Core.Domain;

namespace Petaway.Api.Features.OwnersAnimals.Animal.GetOwnerSpecificAnimal
{
    public interface IGetOwnerSpecificAnimalCommandHandler
    {
        public Task<IEnumerable<GetOwnerSpecificAnimalDto>> HandleAsync(GetOwnerSpecificAnimalCommandRequirements command, CancellationToken cancellation);
    }
}
