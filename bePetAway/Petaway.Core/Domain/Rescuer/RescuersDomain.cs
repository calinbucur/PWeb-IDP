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

        public void UpdateRescuerProfile(string ownerId, string email, string name, string phoneNumber, string address, string password)
        {
            aggregate.UserId = ownerId;
            aggregate.Email = email;
            aggregate.Name = name;
            aggregate.PhoneNumber = phoneNumber;
            aggregate.Address = address;
            aggregate.Password = password;
        }

        public RescuerAcceptTransportEvent AcceptTransport(Transports proposedTransport)
        {
            if (proposedTransport == null)
            {
                throw new TransportIsNullException();
            }

            proposedTransport.TransportState = 1;
            proposedTransport.RescuerId = aggregate.Id;
            return new RescuerAcceptTransportEvent(proposedTransport);
        }
        public RescuerRejectTransportEvent RejectTransport(Transports proposedTransport)
        {
            if (proposedTransport == null)
            {
                throw new TransportIsNullException();
            }

            return new RescuerRejectTransportEvent(proposedTransport);
        }

        //Ramane de vazut (Ar trebui o functie si de Propose curentTransport)
        public Transports? ProposeTransport(int ownerId)
        {
            Transports? proposedTransport = null;


            return proposedTransport;
        }
    }
}
