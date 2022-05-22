using Petaway.Core.Domain.Owner;

namespace Petaway.Api.Features.OwnersAnimals.Animal.UpdateOwnerSpecificAnimal
{
    public record UpdateOwnerSpecificAnimalDto
    {
        public UpdateOwnerSpecificAnimalDto(int animalId, string name, string type, int age, string description, string animalPhotoPath)
        {
            AnimalId = animalId;
            Name = name;
            Type = type; /* cat, dog, rodent, bird, domestic, exotic*/
            Age = age;
            Description = description;
            AnimalPhotoPath = animalPhotoPath;
        }

        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } /*cat, dog, exotic (zoo animals), etc*/
        public int Age { get; set; }
        public string Description { get; set; }
        public string AnimalPhotoPath { get; set; }
    }
}
