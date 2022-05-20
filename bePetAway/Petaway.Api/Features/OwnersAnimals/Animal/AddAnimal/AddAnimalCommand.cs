using Petaway.Core.Domain.Owner;

namespace Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal
{
    public record AddAnimalCommand : AddAnimalToOwnerCommand
    {
        public AddAnimalCommand(string email, string name, string type, int age, string description, string status = "home") : base(email, name, type, age, description, status)
        {

        }
    }
}
