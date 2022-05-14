using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Rescuer
{
    public class RescuerRejectTransportEvent : INotification
    {
        public Transports Transport;
        public RescuerRejectTransportEvent(Transports transport)
        {
            Transport = transport;
        }
    }
}
