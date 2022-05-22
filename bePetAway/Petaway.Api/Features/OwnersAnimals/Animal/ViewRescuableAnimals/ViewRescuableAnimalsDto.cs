using Petaway.Core.Domain.Owner;

namespace Petaway.Api.Features.OwnersAnimals.Animal.ViewRescuableAnimals
{
    public record ViewRescuableAnimalsDto
    {
        public ViewRescuableAnimalsDto(Core.DataModel.Animals animal)
        {
            Name = animal.Name;
            Type = animal.Type; /* cat, dog, rodent, bird, domestic, exotic*/
            Age = animal.Age;
            Status = animal.Status;
            Description = animal.Description;
            AnimalPhotoPath = animal.AnimalPhotoPath;
            OwnerEmail = animal.OwnerEmail;
            CrtTransportId = animal.CrtTransportId;
            CrtFosterEmail = animal.CrtFosterEmail;
            CrtRescuerEmail = animal.CrtRescuerEmail;
        }

        public string Name { get; set; }
        public string Type { get; set; } /*cat, dog, exotic (zoo animals), etc*/
        public int Age { get; set; }
        public string Status { get; set; } /*home, pending, travelling, foster*/
        public string Description { get; set; }
        public string AnimalPhotoPath { get; set; }
        public string OwnerEmail { get; set; }
        public int CrtTransportId { get; set; }
        public string CrtFosterEmail { get; set; }
        public string CrtRescuerEmail { get; set; }
    }
}
