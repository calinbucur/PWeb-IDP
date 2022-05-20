using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Owner
{
    public class OwnerRejectTransportEvent : INotification
    {
        public int TransportId;
        public int FosterId;
        public int AnimalId;
        public OwnerRejectTransportEvent(int transportId, int fosterId, int animalId)
        {
            TransportId = transportId;
            FosterId = fosterId;
            AnimalId = animalId;
        }
    }
}