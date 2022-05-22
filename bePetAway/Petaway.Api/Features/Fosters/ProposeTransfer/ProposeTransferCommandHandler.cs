using Petaway.Core.Domain.Foster;
using Petaway.Core.Domain.Owner;
using Petaway.Core.Domain.Transport;
using Petaway.Api.Web;
using System.Net;
using Petaway.Api.Infrastructure.RabbitMQ;

namespace Petaway.Api.Features.Fosters.ProposeTransfer
{
    public class ProposeTransferCommandHandler : IProposeTransferCommandHandler
    {
        private readonly IOwnersAnimalsRepository ownersAnimalsRepository;
        private readonly IFostersRepository fostersRepository;
        private readonly ITransportsRepository transportRepository;


        public ProposeTransferCommandHandler(IOwnersAnimalsRepository ownersAnimalsRepository, IFostersRepository fostersRepository, ITransportsRepository transportRepository)
        {
            this.ownersAnimalsRepository = ownersAnimalsRepository;
            this.fostersRepository = fostersRepository;
            this.transportRepository = transportRepository;
        }

        public async Task HandleAsync(ProposeTransferCommand command, string identityId, CancellationToken cancellationToken)
        {
            var fosterDomain = await fostersRepository.GetByIdentityIdAsync(identityId, cancellationToken) as FostersDomain;

            if (fosterDomain == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Foster with identity {identityId} does not have a registered profile");
            }

            if (!fosterDomain.CheckCapacity())
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Foster with identity {identityId} is at full capacity");
            }
            var foster = fosterDomain.GetAggregate();

            var ownerDomain = await ownersAnimalsRepository.GetByEmailAsync(command.OwnerEmail, cancellationToken) as OwnersAnimalsDomain;

            if (ownerDomain == null)
            {
                throw new ApiException(HttpStatusCode.NotFound, $"Owner with Email {command.OwnerEmail} not found!");
            }

            var animal = ownerDomain.GetRescuableAnimal(command.AnimalName, command.AnimalType, command.AnimalAge);

            ownerDomain.AnimalAcceptedByFoster(animal.Id, foster.Email);
            await ownersAnimalsRepository.SaveAsync(cancellationToken);

            fosterDomain.AddAnimal(animal);
            await fostersRepository.SaveAsync(cancellationToken);

            await transportRepository.AddAsync(
                new RegisterTransportProfileCommand(ownerDomain.GetAggregate().Email, animal.Id, foster.Email, "none", "none", foster.Address),
                cancellationToken);

            RabbitMQService.sendMail(command.OwnerEmail, "Foster rescue for your animal", $"Foster {foster.Name} wants to help your animal: {animal.Name} {animal.Type}, {animal.Age} to get out of the danger zone");
        }
    }
    
}
