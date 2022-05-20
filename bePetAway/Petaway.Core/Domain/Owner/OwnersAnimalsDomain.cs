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
            }
        }

        public void UpdateOwnerProfile(string email, string name, string phoneNumber, string address, string password, string photoPath)
        {
            aggregate.Email = email;
            aggregate.Name = name;
            aggregate.PhoneNumber = phoneNumber;
            aggregate.PhotoPath = photoPath;
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
            animal.Age = age;
            animal.Description = description;
        }

        public AddAnimalToOwnerCommand AddAnimal(string name, string type, int age, string description, string status = "home")
        {
            Animals new_animal = new Animals(name, type, age, status, description)
            {
                OwnerId = aggregate.Id
            };
            aggregate.Animals.Add(new_animal);
            

            return new AddAnimalToOwnerCommand(aggregate.Id, name, type, age, description, status);
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
