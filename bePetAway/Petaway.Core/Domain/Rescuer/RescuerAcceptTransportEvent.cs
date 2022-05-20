using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Rescuer
{
    public class RescuerAcceptTransportEvent : INotification
    {
        public int TransportId;
        public RescuerAcceptTransportEvent(int transportId)
        {
            TransportId = transportId;
        }
    }
}
