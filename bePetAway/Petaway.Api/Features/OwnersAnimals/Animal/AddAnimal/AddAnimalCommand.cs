using Petaway.Core.Domain.Owner;

namespace Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal
{
    public record AddAnimalCommand : AddAnimalToOwnerCommand
    {
        public AddAnimalCommand(int ownerId, string name, string type, string description, int age, string location, bool isAgg, bool isSick, bool isStray, string status = "home") : base(ownerId, name, type, description, age, location, isAgg, isSick, isStray, status)
        {

        }
    }
}
