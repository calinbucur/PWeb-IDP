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
                    if (animal.IsHome)
                    {
                        animal.Location = address;
                    }
                }
            }
        }

        public void UpdateOwnerProfile(string ownerId, string email, string name, string phoneNumber, string address, string password)
        {
            aggregate.UserId = ownerId;
            aggregate.Email = email;
            aggregate.Name = name;
            aggregate.PhoneNumber = phoneNumber;
            aggregate.Password = password;
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
            animal.IsHome = false;
        }

        public OwnerAcceptTransportEvent AcceptTransport(Transports proposedTransport)
        {
            if (proposedTransport == null)
            {
                throw new TransportIsNullException();
            }

            var animal = aggregate.Animals.FirstOrDefault(x => x.Id == proposedTransport.AnimalId);
            if (animal == null)
            {
                throw new AnimalNotFoundException(aggregate.Name, proposedTransport.AnimalId);
            }

            if (!animal.IsHome)
            {
                throw new AnimalNotHomeException(aggregate.Name, proposedTransport.AnimalId);
            }

            proposedTransport.TransportState = 1;
            proposedTransport.OwnerId = aggregate.Id;
            proposedTransport.AnimalId = animal.Id;
            proposedTransport.Animals.Add(animal);
            return new OwnerAcceptTransportEvent(proposedTransport);
        }
        public OwnerRejectTransportEvent RejectTransport(Transports proposedTransport)
        {
            if (proposedTransport == null)
            {
                throw new TransportIsNullException();
            }

            var animal = aggregate.Animals.FirstOrDefault(x => x.Id == proposedTransport.AnimalId);
            if (animal == null)
            {
                throw new AnimalNotFoundException(aggregate.Name, proposedTransport.AnimalId);
            }

            if (!animal.IsHome)
            {
                throw new AnimalNotHomeException(aggregate.Name, proposedTransport.AnimalId);
            }

            proposedTransport.TransportState = 0;
            return new OwnerRejectTransportEvent(proposedTransport);

        }

        //Ramane de vazut (Propune doar spre Foster)
        public Transports? ProposeTransport(int ownerId)
        {
            Transports? proposedTransport = null;


            return proposedTransport;
        }
    }
}
