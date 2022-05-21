using Petaway.Core.Domain.Foster;
using Petaway.Core.Domain.Owner;
using Petaway.Core.Domain.Transport;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.Fosters.ProposeTransfer
{
    public class ProposeTransferCommandHandler : IProposeTransferCommandHandler
    {
        private readonly IOwnersAnimalsRepository ownersAnimalsRepository;
        private readonly IFostersRepository fostersRepository;
        private readonly ITransportsRepository transportRepository;
        private readonly IMediator mediator;


        public ProposeTransferCommandHandler(IOwnersAnimalsRepository ownersAnimalsRepository, IFostersRepository fostersRepository, ITransportsRepository transportRepository, IMediator mediator)
        {
            this.ownersAnimalsRepository = ownersAnimalsRepository;
            this.fostersRepository = fostersRepository;
            this.transportRepository = transportRepository;
            this.mediator = mediator;
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

            var animal = ownerDomain.GetRescuableAnimal(command.AnimalName, command.AnimalType);

            ownerDomain.AnimalAcceptedByFoster(animal.Id, foster.Id);
            await ownersAnimalsRepository.SaveAsync(cancellationToken);

            fosterDomain.AddAnimal(animal);
            await fostersRepository.SaveAsync(cancellationToken);

            await transportRepository.AddAsync(
                new RegisterTransportProfileCommand(ownerDomain.GetAggregate().Id, animal.Id, foster.Id, -1, "none", foster.Address),
                cancellationToken);
        }
    }
    
}
