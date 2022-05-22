using Petaway.Core.DataModel;
using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Transport
{
    public class TransportsDomain : DomainOfAggregate<Transports>
    {
        public TransportsDomain(Transports aggregate) : base(aggregate)
        {

        }

        public void MarkTransferAsRejected() => aggregate.RejectedByOwnerOrFoster = true;
        public void MarkTransferAsFinished() => aggregate.IsFinished = true;
        public void MarkTransferAsAcceptedByFosterOwner(string fosterEmail, string ownerEmail, int animalId)
        {
            aggregate.OwnerEmail = ownerEmail;
            aggregate.AnimalId = animalId;
            aggregate.FosterEmail = fosterEmail;
        }

        public void MarkTransferAsAcceptedByRescuer(string rescuerEmail) => aggregate.RescuerEmail = rescuerEmail;

        public bool TransferCanBeDeleted() => aggregate.RejectedByOwnerOrFoster; //|| aggregate.IsFinished;
    }
}
