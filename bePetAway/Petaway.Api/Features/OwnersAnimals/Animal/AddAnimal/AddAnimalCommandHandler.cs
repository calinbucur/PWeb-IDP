using Petaway.Core.Domain.Owner;
using Petaway.Api.Web;
using System.Net;
using MediatR;

namespace Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal
{
    public class AddAnimalCommandHandler : IAddAnimalCommandHandler
    {
        private readonly IOwnersAnimalsRepository OwnersAnimalsRepository;
        private readonly IMediator mediator;

        public AddAnimalCommandHandler(IOwnersAnimalsRepository OwnersAnimalsRepository, IMediator mediator)
        {
            this.OwnersAnimalsRepository = OwnersAnimalsRepository;
            this.mediator = mediator;
        }

        public async Task HandleAsync(AddAnimalCommand command, int ownerId, CancellationToken cancellationToken)
        {
            var owner = await OwnersAnimalsRepository.GetAsync(ownerId, cancellationToken) as OwnersAnimalsDomain;

            if (owner == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Owner with identity {ownerId} does not have a registered profile");
            }

            var addAnimalEvent = owner.AddAnimal(command.Name, command.Type, command.Age, command.Description, command.Status);
            await mediator.Publish(addAnimalEvent, cancellationToken);

            await OwnersAnimalsRepository.SaveAsync(cancellationToken);
        }
        
    }

}
