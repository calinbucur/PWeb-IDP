using Petaway.Core.DataModel;
using Petaway.Core.SeedWork;
using Petaway.Core.Domain.Transport;

namespace Petaway.Core.Domain.Foster
{
    public class FostersDomain : DomainOfAggregate<Fosters>
    {
        public FostersDomain(Fosters aggregate) : base(aggregate)
        {
        }

        public void UpdateFosterAddress(string address)
        {
            if (!String.Equals(aggregate.Address, address))
            {
                aggregate.Address = address;

                foreach (Animals animal in aggregate.Animals)
                {
                    animal.Location = address;
                }
            }
        }

        public void UpdateFosterProfile(string fosterId, string email, string name, string phoneNumber, string address, string password, int maxCapacity)
        {
            aggregate.UserId = fosterId;
            aggregate.Email = email;
            aggregate.Name = name;
            aggregate.PhoneNumber = phoneNumber;
            aggregate.Password = password;
            aggregate.MaxCapacity = maxCapacity;
            UpdateFosterAddress(address);
        }
        
        public FosterAcceptTransportEvent AcceptTransport(Transports proposedTransport)
        {
            if (proposedTransport == null)
            {
                throw new TransportIsNullException();
            }

            proposedTransport.TransportState = 1;
            proposedTransport.FosterId = aggregate.Id;
            return new FosterAcceptTransportEvent(proposedTransport);
        }
        public FosterRejectTransportEvent RejectTransport(Transports proposedTransport)
        {
            if (proposedTransport == null)
            {
                throw new TransportIsNullException();
            }

//            proposedTransport.TransportState = 0;
            return new FosterRejectTransportEvent(proposedTransport);

        }

        //Ramane de vazut
        public Transports? ProposeTransport(int ownerId)
        {
            Transports? proposedTransport = null;


            return proposedTransport;
        }

    }
}
