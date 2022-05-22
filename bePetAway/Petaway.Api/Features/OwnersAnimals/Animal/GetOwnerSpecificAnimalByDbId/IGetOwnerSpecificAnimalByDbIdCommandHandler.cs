using Petaway.Core.Domain;

namespace Petaway.Api.Features.OwnersAnimals.Animal.GetOwnerSpecificAnimalByDbId
{
    public interface IGetOwnerSpecificAnimalByDbIdCommandHandler
    {
        public Task<IEnumerable<GetOwnerSpecificAnimalByDbIdDto>> HandleAsync(GetOwnerSpecificAnimalByDbIdCommandRequirements command, CancellationToken cancellation);
    }
}
