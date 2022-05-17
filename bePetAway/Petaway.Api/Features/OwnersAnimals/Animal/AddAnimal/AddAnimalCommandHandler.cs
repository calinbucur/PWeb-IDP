using Petaway.Core.Domain.Owner;

namespace Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal
{
/*    public class AddAnimalCommandHandler : IAddAnimalCommandHandler
    {
        private readonly IOwnersAnimalsRepository OwnersAnimalsRepository;

        public AddAnimalCommandHandler(IOwnersAnimalsRepository OwnersAnimalsRepository)
        {
            this.OwnersAnimalsRepository = OwnersAnimalsRepository;
        }

        public Task HandleAsync(AddAnimalCommand command, CancellationToken cancellationToken)
            => OwnersAnimalsRepository.AddAsync(
                new AddAnimalToOwnerCommand(command.OwnerId, command.Name, command.Type, command.Description, command.Age, command.Location, command.IsAggresive, command.IsSick, command.IsStray),
                cancellationToken);
    }
*/
}
