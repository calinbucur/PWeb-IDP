using Petaway.Core.Domain.Foster;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.OwnersAnimals.Animal.GetOwnerSpecificAnimal
{
    public record GetOwnerSpecificAnimalCommandRequirements
    {
        public GetOwnerSpecificAnimalCommandRequirements(string ownerEmail, string animalName, string animalType, int animalAge)
        {
            OwnerEmail = ownerEmail;
            AnimalName = animalName;
            AnimalType = animalType;
            AnimalAge = animalAge;
        }

        public string OwnerEmail { get; set; }
        public string AnimalName { get; set; }
        public string AnimalType { get; set; }
        public int AnimalAge { get; set; }
    }
}
