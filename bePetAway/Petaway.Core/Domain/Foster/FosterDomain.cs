using Petaway.Core.DataModel;
using Petaway.Core.SeedWork;
using Petaway.Core.Domain.Owner;

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
            }
        }

        public void UpdateFosterProfile(string name, string phoneNumber, string address, string photoPath, int maxCapacity)
        {
            aggregate.Name = name;
            aggregate.PhoneNumber = phoneNumber;
            aggregate.MaxCapacity = maxCapacity;
            aggregate.PhotoPath = photoPath;
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

        public bool CheckCapacity()
        {
            return aggregate.CrtCapacity + 1 <= aggregate.MaxCapacity;
        }

        public void AddAnimal(Animals animal)
        {
            if(animal == null)
            {
                throw new NullAnimalException();
            }

            aggregate.Animals.Add(animal);
            aggregate.CrtCapacity++;
        }
        public Fosters GetAggregate()
        {
            return aggregate;
        }
    }
}
