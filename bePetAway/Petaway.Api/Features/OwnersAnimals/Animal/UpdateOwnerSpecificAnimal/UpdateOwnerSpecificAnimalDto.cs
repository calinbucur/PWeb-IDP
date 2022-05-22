using Petaway.Core.Domain.Owner;

namespace Petaway.Api.Features.OwnersAnimals.Animal.UpdateOwnerSpecificAnimal
{
    public record UpdateOwnerSpecificAnimalDto
    {
        public UpdateOwnerSpecificAnimalDto(Core.DataModel.Animals animal)
        {
            Id = animal.Id;
            Name = animal.Name;
            Type = animal.Type; /* cat, dog, rodent, bird, domestic, exotic*/
            Age = animal.Age;
            Description = animal.Description;
            AnimalPhotoPath = animal.AnimalPhotoPath;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } /*cat, dog, exotic (zoo animals), etc*/
        public int Age { get; set; }
        public string Description { get; set; }
        public string AnimalPhotoPath { get; set; }
    }
}
