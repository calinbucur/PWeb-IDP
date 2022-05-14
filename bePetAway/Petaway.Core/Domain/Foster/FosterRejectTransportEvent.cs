using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Foster
{
    public class FosterRejectTransportEvent : INotification
    {
        public Transports Transport;
        public FosterRejectTransportEvent(Transports transport)
        {
            Transport = transport;
        }
    }
}
