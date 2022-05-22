using Petaway.Core.Domain.Owner;
using Petaway.Api.Web;
using System.Net;
using MediatR;
using Petaway.Api.Infrastructure.RabbitMQ;

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

        public async Task HandleAsync(AddAnimalCommand command, string identityId, CancellationToken cancellationToken)
        {
            var ownerDomain = await OwnersAnimalsRepository.GetByIdentityIdAsync(identityId, cancellationToken) as OwnersAnimalsDomain;

            if (ownerDomain == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Owner with identity {identityId} does not have a registered profile");
            }

            var addAnimalEvent = ownerDomain.AddAnimal(command.Name, command.Type, command.Age, command.Description, command.AnimalPhotoPath, "home");
            await mediator.Publish(addAnimalEvent, cancellationToken);

            await OwnersAnimalsRepository.SaveAsync(cancellationToken);

            //_rabbitMqService.sendMail("petaway.test@gmail.com", "TEST EMAIL", "SUBJECT");
        }
        
    }

}
