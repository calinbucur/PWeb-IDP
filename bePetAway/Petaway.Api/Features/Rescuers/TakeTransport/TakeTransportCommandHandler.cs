using Petaway.Core.Domain.Rescuer;
using Petaway.Core.Domain.Owner;
using Petaway.Core.Domain.Transport;
using Petaway.Api.Web;
using System.Net;
using Petaway.Api.Infrastructure.RabbitMQ;

namespace Petaway.Api.Features.Rescuers.TakeTransport
{
    public class TakeTransportCommandHandler : ITakeTransportCommandHandler
    {
        private readonly IOwnersAnimalsRepository ownersAnimalsRepository;
        private readonly IRescuersRepository rescuersRepository;
        private readonly ITransportsRepository transportsRepository;


        public TakeTransportCommandHandler(IOwnersAnimalsRepository ownersAnimalsRepository, IRescuersRepository rescuersRepository, ITransportsRepository transportRepository)
        {
            this.ownersAnimalsRepository = ownersAnimalsRepository;
            this.rescuersRepository = rescuersRepository;
            this.transportsRepository = transportRepository;
        }

        public async Task HandleAsync(TakeTransportCommand command, string identityId, CancellationToken cancellationToken)
        {
            var rescuerDomain = await rescuersRepository.GetByIdentityIdAsync(identityId, cancellationToken) as RescuersDomain;

            if (rescuerDomain == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Rescuer with identity {identityId} does not have a registered profile");
            }

            var rescuer = rescuerDomain.GetAggregate();
            if (rescuer.CrtTransportId != -1)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Rescuer with identity {identityId} is already taking another transport");
            }

            var transportsDomain = await transportsRepository.GetAsync(command.TransportId, cancellationToken) as TransportsDomain;

            if (transportsDomain == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Transport with id {command.TransportId} does not exist");
            }

            string ownerEmail = transportsDomain.GetAggregate().OwnerEmail;
            string fosterEmail = transportsDomain.GetAggregate().FosterEmail;
            int animalId = transportsDomain.GetAggregate().AnimalId;


            if (String.Equals(ownerEmail, "none") || String.Equals(fosterEmail, "none") || (animalId == -1))
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Transport with id {command.TransportId} is broken; One of its fields is null!");
            }

            var ownerDomain = await ownersAnimalsRepository.GetByEmailAsync(ownerEmail, cancellationToken) as OwnersAnimalsDomain;

            if (ownerDomain == null)
            {
                throw new ApiException(HttpStatusCode.NotFound, $"Owner with Email {ownerEmail} not found!");
            }

            ownerDomain.AnimalAcceptedByRescuer(animalId, rescuer.Email, command.TransportId);

            await ownersAnimalsRepository.SaveAsync(cancellationToken);

            rescuerDomain.SetTransport(command.TransportId);
            await rescuersRepository.SaveAsync(cancellationToken);


            transportsDomain.SetRescuerData(rescuer.Email, rescuer.Address);
            await rescuersRepository.SaveAsync(cancellationToken);


            var animal = ownerDomain.GetAnimalById(animalId);
            RabbitMQService.sendMail(ownerEmail, "Rescuer wants to take your animal to the foster", $"Rescuer {rescuer.Email} wants to help your animal: {animal.Name} {animal.Type}, {animal.Age} to get to foster's location: {transportsDomain.GetAggregate().EndPoint}.");
            RabbitMQService.sendMail(fosterEmail, "Rescuer brings you animals", $"Rescuer {rescuer.Email} will transport: {animal.Name} {animal.Type}, {animal.Age} to get to your location.");
        }
    }
    
}
