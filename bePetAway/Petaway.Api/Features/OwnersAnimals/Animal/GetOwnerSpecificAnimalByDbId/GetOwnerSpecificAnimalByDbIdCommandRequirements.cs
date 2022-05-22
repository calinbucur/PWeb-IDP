using Petaway.Core.Domain.Foster;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.OwnersAnimals.Animal.GetOwnerSpecificAnimalByDbId
{
    public record GetOwnerSpecificAnimalByDbIdCommandRequirements
    {
        public GetOwnerSpecificAnimalByDbIdCommandRequirements(string ownerEmail, int animalId)
        {
            OwnerEmail = ownerEmail;
            AnimalId = animalId;
        }

        public string OwnerEmail { get; set; }
        public int AnimalId { get; set; }
    }
}
