using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Foster
{
    public class FosterRejectTransportEvent : INotification
    {
        public int TransportId;
        public int OwnerId;
        public int AnimalId;
        public FosterRejectTransportEvent(int transportId, int ownerId, int animalId)
        {
            TransportId = transportId;
            OwnerId = ownerId;
            AnimalId = animalId;
        }
    }
}
