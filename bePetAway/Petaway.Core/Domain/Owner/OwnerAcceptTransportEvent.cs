using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Owner
{
    public class OwnerAcceptTransportEvent : INotification
    {
        public int TransportId;
        public int FosterId;
        public int AnimalId;
        public OwnerAcceptTransportEvent(int transportId, int fosterId, int animalId)
        {
            TransportId = transportId;
            FosterId = fosterId;
            AnimalId = animalId;
        }
    }
}
