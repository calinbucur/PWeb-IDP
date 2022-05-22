using Petaway.Core.Domain.Rescuer;
using Petaway.Core.Domain.Owner;
using Petaway.Core.Domain.Transport;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Petaway.Api.Infrastructure.RabbitMQ;


namespace Petaway.Api.Features.Rescuers.FinishTransport
{
    public class FinishTransportCommandHandler : IFinishTransportCommandHandler
    {
        private readonly IOwnersAnimalsRepository ownersAnimalsRepository;
        private readonly IRescuersRepository rescuersRepository;
        private readonly ITransportsRepository transportsRepository;


        public FinishTransportCommandHandler(IOwnersAnimalsRepository ownersAnimalsRepository, IRescuersRepository rescuersRepository, ITransportsRepository transportRepository)
        {
            this.ownersAnimalsRepository = ownersAnimalsRepository;
            this.rescuersRepository = rescuersRepository;
            this.transportsRepository = transportRepository;
        }

        public async Task HandleAsync(string identityId, CancellationToken cancellationToken)
        {
            var rescuerDomain = await rescuersRepository.GetByIdentityIdAsync(identityId, cancellationToken) as RescuersDomain;

            if (rescuerDomain == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Rescuer with identity {identityId} does not have a registered profile");
            }

            var rescuer = rescuerDomain.GetAggregate();

            if (rescuer.CrtTransportId == -1)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Rescuer with identity {identityId} is not involved in any transfer at the moment");
            }

            var transportsDomain = await transportsRepository.GetAsync(rescuer.CrtTransportId, cancellationToken) as TransportsDomain;

            if (transportsDomain == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Transport with id {rescuer.CrtTransportId} does not exist");
            }

            string ownerEmail = transportsDomain.GetAggregate().OwnerEmail;
            string fosterEmail = transportsDomain.GetAggregate().FosterEmail;
            string rescuerEmail = transportsDomain.GetAggregate().RescuerEmail;
            int animalId = transportsDomain.GetAggregate().AnimalId;


            if (String.Equals(ownerEmail, "none") || String.Equals(fosterEmail, "none") || String.Equals(rescuerEmail, "none") || (animalId == -1))
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Transport with id {rescuer.CrtTransportId} is broken; One of its fields is null!");
            }

            var ownerDomain = await ownersAnimalsRepository.GetByEmailAsync(ownerEmail, cancellationToken) as OwnersAnimalsDomain;

            if (ownerDomain == null)
            {
                throw new ApiException(HttpStatusCode.NotFound, $"Owner with Email {ownerEmail} not found!");
            }

            ownerDomain.AnimalArrivedAtDestination(animalId);
            await ownersAnimalsRepository.SaveAsync(cancellationToken);

            rescuerDomain.FinishedTransport(transportsDomain.GetAggregate());
            await rescuersRepository.SaveAsync(cancellationToken);


            transportsDomain.MarkTransferAsFinished();
            await rescuersRepository.SaveAsync(cancellationToken);

            var animal = ownerDomain.GetAnimalById(animalId);
            RabbitMQService.sendMail(ownerEmail, "Rescuer arrived at foster's destination", $"Rescuer {rescuer.Email} has arrived with your animal: {animal.Name} {animal.Type}, {animal.Age} at foster's ({fosterEmail}) location: {transportsDomain.GetAggregate().EndPoint}.");
            RabbitMQService.sendMail(fosterEmail, "Rescuer arrived at your location", $"Rescuer {rescuer.Email} has arrived with animal: {animal.Name} {animal.Type}, {animal.Age} to your location.");
        }
    }
    
}
