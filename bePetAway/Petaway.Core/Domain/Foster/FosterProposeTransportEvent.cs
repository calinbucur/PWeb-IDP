using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Foster
{
    public class FosterProposeTransportEvent : INotification
    {
        public int FosterId;
        public int OwnerId;
        public int AnimalId;
        public FosterProposeTransportEvent(int fosterId, int ownerId, int animalId)
        {
            FosterId = fosterId;
            OwnerId = ownerId;
            AnimalId = animalId;
        }
    }
}
