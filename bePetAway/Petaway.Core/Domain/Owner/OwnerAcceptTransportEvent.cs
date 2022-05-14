using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Owner
{
    public class OwnerAcceptTransportEvent : INotification
    {
        public Transports Transport;
        public OwnerAcceptTransportEvent(Transports transport)
        {
            Transport = transport;
        }
    }
}
