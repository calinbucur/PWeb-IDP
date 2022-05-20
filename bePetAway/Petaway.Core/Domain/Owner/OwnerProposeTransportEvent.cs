using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Owner
{
    public class OwnerProposeTransportEvent : INotification
    {
        public int TransportId;
        public int OwnerId;
        public int AnimalId;
        public OwnerProposeTransportEvent(int transportId, int ownerId, int animalId)
        {
            TransportId = transportId;
            OwnerId = ownerId;
            AnimalId = animalId;
        }
    }
}
