using Petaway.Core.Domain;

namespace Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal
{
    public interface IAddAnimalCommandHandler
    {
        public Task HandleAsync(AddAnimalCommand command, string ownerEmail, CancellationToken cancellation);
    }
}
