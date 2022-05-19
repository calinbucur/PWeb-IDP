using Petaway.Core.Domain.Owner;

namespace Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal
{
    public record AddAnimalCommand : AddAnimalToOwnerCommand
    {
        public AddAnimalCommand(int ownerId, string name, string type, int age, string description, string status = "home") : base(ownerId, name, type, age, description, status)
        {

        }
    }
}
