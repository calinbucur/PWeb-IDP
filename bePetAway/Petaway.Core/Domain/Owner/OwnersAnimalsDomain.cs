using Petaway.Core.DataModel;
using Petaway.Core.SeedWork;
using Petaway.Core.Domain.Transport;

namespace Petaway.Core.Domain.Owner
{
    public class OwnersAnimalsDomain : DomainOfAggregate<Owners>
    {
        public OwnersAnimalsDomain(Owners aggregate) : base(aggregate)
        {
        }

        public void UpdateOwnerAddress(string address)
        {
            if (!String.Equals(aggregate.Address, address))
            {
                aggregate.Address = address;

                foreach (Animals animal in aggregate.Animals)
                {
                    if (animal.Status == "home")
                    {
                        animal.Location = address;
                    }
                }
            }
        }

        public void UpdateOwnerProfile(string userId, string email, string name, string phoneNumber, string address, string password)
        {
            aggregate.UserId = userId;
            aggregate.Email = email;
            aggregate.Name = name;
            aggregate.PhoneNumber = phoneNumber;
            UpdateOwnerAddress(address);
        }

        public void UpdateAnimalInfo(int animalId, string name, string type, bool isAgg, bool isSick, bool isStray, int age, string description)
        {
            var animal = aggregate.Animals.FirstOrDefault(x => x.Id == animalId);
            if (animal == null)
            {
                throw new AnimalNotFoundException(aggregate.Name, animalId);
            }

            animal.Name = name;
            animal.Type = type;
            animal.IsAggresive = isAgg;
            animal.IsSick = isSick;
            animal.IsStray = isStray;
            animal.Age = age;
            animal.Description = description;
        }

        public void MarkAnimalAsTaken(int animalId) {
            var animal = aggregate.Animals.FirstOrDefault(x => x.Id == animalId);
            if (animal == null)
            {
                throw new AnimalNotFoundException(aggregate.Name, animalId);
            }

            animal.Status = "pending";
        }

        public OwnerAcceptTransportEvent AcceptTransport(int transportId, int fosterId, int animalId)
        {
            var animal = aggregate.Animals.FirstOrDefault(x => x.Id == animalId);
            if (animal == null)
            {
                throw new AnimalNotFoundException(aggregate.Name, animalId);
            }

            if (animal.Status != "home")
            {
                throw new AnimalNotHomeException(aggregate.Name, animalId);
            }

            animal.CrtTransportId = transportId;
            animal.CrtFosterId = fosterId;
            
            return new OwnerAcceptTransportEvent(transportId, fosterId, animalId);
        }
        public OwnerRejectTransportEvent RejectTransport(int transportId, int fosterId, int animalId)
        {
            var animal = aggregate.Animals.FirstOrDefault(x => x.Id == animalId);
            if (animal == null)
            {
                throw new AnimalNotFoundException(aggregate.Name, animalId);
            }

            if (animal.Status != "home")
            {
                throw new AnimalNotHomeException(aggregate.Name, animalId);
            }

            return new OwnerRejectTransportEvent(transportId, fosterId, animalId);
        }

        public OwnerProposeTransportEvent ProposeTransport(int fosterId, int animalId)
        {
            var animal = aggregate.Animals.FirstOrDefault(x => x.Id == animalId);
            if (animal == null)
            {
                throw new AnimalNotFoundException(aggregate.Name, animalId);
            }

            return new OwnerProposeTransportEvent(fosterId, aggregate.Id, animalId);
        }
    }
}
