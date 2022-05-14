using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Foster
{
    public class FosterAcceptTransportEvent : INotification
    {
        public Transports Transport;
        public FosterAcceptTransportEvent(Transports transport)
        {
            Transport = transport;
        }
    }
}
