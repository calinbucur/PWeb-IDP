using Petaway.Core.DataModel;
using MediatR;

namespace Petaway.Core.Domain.Owner
{
    public class OwnerRejectTransportEvent : INotification
    {
        public Transports Transport;
        public OwnerRejectTransportEvent(Transports transport)
        {
            Transport = transport;
        }
    }
}
