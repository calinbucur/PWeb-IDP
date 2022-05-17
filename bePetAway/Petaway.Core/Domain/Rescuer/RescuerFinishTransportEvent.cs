using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Rescuer
{
    public class RescuerFinishTransportEvent : INotification
    {
        public int TransportId;
        public RescuerFinishTransportEvent(int transportId)
        {
            TransportId = transportId;
        }
    }
}
