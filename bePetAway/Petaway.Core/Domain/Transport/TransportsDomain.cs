using Petaway.Core.DataModel;
using Petaway.Core.SeedWork;
using Petaway.Core.Domain.Transport;

namespace Petaway.Core.Domain.Owner
{
    public class TransportsDomain : DomainOfAggregate<Transports>
    {
        public TransportsDomain(Transports aggregate) : base(aggregate)
        {
        }

    }
}
