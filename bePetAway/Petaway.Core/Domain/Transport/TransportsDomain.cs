using Petaway.Core.DataModel;
using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Transport
{
    public class TransportsDomain : DomainOfAggregate<Transports>
    {
        public TransportsDomain(Transports aggregate) : base(aggregate)
        {
        }

    }
}
