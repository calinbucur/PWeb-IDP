using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Owner
{
    public class OwnerAcceptTransportEvent : INotification
    {
        public int TransportId;
        public string FosterEmail;
        public int AnimalId;
        public OwnerAcceptTransportEvent(int transportId, string fosterEmail, int animalId)
        {
            TransportId = transportId;
            FosterEmail = fosterEmail;
            AnimalId = animalId;
        }
    }
}
