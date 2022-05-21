using Petaway.Core.Domain.Owner;

namespace Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal
{
    public record AddAnimalCommand : AddAnimalToOwnerCommand
    {
        public AddAnimalCommand(string name, string type, int age, string description, string status = "home") : base(name, type, age, description, status)
        {

        }
    }
}
