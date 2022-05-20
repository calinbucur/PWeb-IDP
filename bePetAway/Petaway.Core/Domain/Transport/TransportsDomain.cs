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
        public void MarkTransferAsAcceptedByFosterOwner(int fosterId, int ownerId, int animalId)
        {
            aggregate.OwnerId = ownerId;
            aggregate.AnimalId = animalId;
            aggregate.FosterId = fosterId;
        }
        public void MarkTransferAsAcceptedByRescuer(int rescuerId) => aggregate.RescuerId = rescuerId;

        public bool TransferCanBeDeleted() => aggregate.RejectedByOwnerOrFoster; //|| aggregate.IsFinished;
    }
}
