using Petaway.Core.DataModel;
using Petaway.Core.SeedWork;
using Petaway.Core.Domain.Transport;

namespace Petaway.Core.Domain.Rescuer
{
    public class RescuersDomain : DomainOfAggregate<Rescuers>
    {
        public RescuersDomain(Rescuers aggregate) : base(aggregate)
        {
        }

        public void UpdateRescuerAddress(string address)
        {
            aggregate.Address = address;
        }

        public void UpdateRescuerProfile(string name, string phoneNumber, string address, string photoPath)
        {
            aggregate.Name = name;
            aggregate.PhoneNumber = phoneNumber;
            aggregate.Address = address;
            aggregate.PhotoPath = photoPath;
        }

        public RescuerAcceptTransportEvent AcceptTransport(int transportId)
        {
            /*if (aggregate.MaxCapacity < aggregate.CrtCapacity + 1)
            {
                throw new RescuerFullCapacityException(aggregate.Id);
            }*/

            aggregate.CrtTransportId = transportId;
            return new RescuerAcceptTransportEvent(transportId);
        }
        public RescuerRejectTransportEvent RejectTransport(int transportId)
        {
            return new RescuerRejectTransportEvent(transportId);
        }

        public RescuerFinishTransportEvent FinishTransport(int transportId)
        {
//            aggregate.CrtCapacity = 0;
            return new RescuerFinishTransportEvent(transportId);
        }

        public void SetTransport(int transportId) => aggregate.CrtTransportId = transportId;

        public void FinishedTransport(Transports transport)
        {
            if (transport == null)
            {
                throw new NullTransportException();
            }

            if ((transport.EndPoint == null) || (transport.EndPoint == "none"))
            {
                throw new NullTransportException();
            }

            AddTransportToHistory(transport);
            aggregate.CrtTransportId = -1;
            aggregate.Address = transport.EndPoint;
        }
        
        public void AddTransportToHistory(Transports transport) => aggregate.TransportHistory.Add(transport);
        public Rescuers GetAggregate()
        {
            return aggregate;
        }

    }
}
