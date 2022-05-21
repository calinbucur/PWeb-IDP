using Petaway.Core.Domain.Owner;

namespace Petaway.Api.Features.OwnersAnimals.Animal.ViewOwnerAnimals
{
    public record ViewOwnerAnimalsDto
    {
        public ViewOwnerAnimalsDto(Core.DataModel.Animals animal)
        {
            Name = animal.Name;
            Type = animal.Type; /* cat, dog, rodent, bird, domestic, exotic*/
            Age = animal.Age;
            Status = animal.Status;
            Description = animal.Description;
            AnimalPhotoPath = animal.AnimalPhotoPath;
            OwnerId = animal.OwnerId;
            CrtTransportId = animal.CrtTransportId;
            CrtFosterId = animal.CrtFosterId;
            CrtRescuerId = animal.CrtRescuerId;
        }

        public string Name { get; set; }
        public string Type { get; set; } /*cat, dog, exotic (zoo animals), etc*/
        public int Age { get; set; }
        public string Status { get; set; } /*home, pending, travelling, foster*/
        public string Description { get; set; }
        public string AnimalPhotoPath { get; set; }
        public int OwnerId { get; set; }
        public int CrtTransportId { get; set; }
        public int CrtFosterId { get; set; }
        public int CrtRescuerId { get; set; }
    }
}
