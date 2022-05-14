using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Rescuer
{
    public class RescuerAcceptTransportEvent : INotification
    {
        public Transports Transport;
        public RescuerAcceptTransportEvent(Transports transport)
        {
            Transport = transport;
        }
    }
}
