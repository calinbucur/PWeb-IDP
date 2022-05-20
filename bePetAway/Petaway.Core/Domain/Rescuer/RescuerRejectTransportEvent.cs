using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Rescuer
{
    public class RescuerRejectTransportEvent : INotification
    {
        public int TransportId;
        public RescuerRejectTransportEvent(int transportId)
        {
            TransportId = transportId;
        }
    }
}
