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
            aggregate.MaxCapacity = maxCapacity;
            UpdateFosterAddress(address);
        }

        public FosterAcceptTransportEvent AcceptTransport(int transportId, int ownerId, int animalId)
        {
            if (aggregate.MaxCapacity < aggregate.CrtCapacity + 1)
            {
                throw new FosterFullCapacityException(aggregate.Id);
            }

            aggregate.CrtCapacity++;

            return new FosterAcceptTransportEvent(transportId, ownerId, animalId);
        }

        public FosterRejectTransportEvent RejectTransport(int transportId, int ownerId, int animalId)
        {
            return new FosterRejectTransportEvent(transportId, ownerId, animalId);
        }

        public FosterProposeTransportEvent ProposeTransport(int ownerId, int animalId)
        {
            if (aggregate.MaxCapacity < aggregate.CrtCapacity + 1)
            {
                throw new FosterFullCapacityException(aggregate.Id);
            }

            aggregate.CrtCapacity++;
            return new FosterProposeTransportEvent(aggregate.Id, ownerId, animalId);
        }
    }
}
