using Petaway.Core.Domain.Owner;

namespace Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal
{
    public record AddAnimalCommand
    {
        public AddAnimalCommand(string name, string type, int age, string description, string animalPhotoPath)
        {
            Name = name;
            Type = type;
            Age = age;
            Description = description;
            AnimalPhotoPath = animalPhotoPath;
        }

        public string Name { get; init; }
        public string Type { get; init; }
        public int Age { get; init; }
        public string Description { get; init; }
        public string AnimalPhotoPath { get; init; }

    }
}
