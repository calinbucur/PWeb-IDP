using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Transport
{
    public record RegisterTransportProfileCommand : ICreateAggregateCommand
    {
        public RegisterTransportProfileCommand(string ownerEmail, int animalId, string fosterEmail, string rescuerEmail, string startPoint, string endPoint)
        {
            OwnerEmail = ownerEmail;
            AnimalId = animalId;
            FosterEmail = fosterEmail;
            RescuerEmail = rescuerEmail;
            StartingPoint = startPoint;
            EndPoint = endPoint;
        }

        public string OwnerEmail { get; set; } = "none";
        public int AnimalId { get; set; }
        public string FosterEmail { get; set; } = "none";
        public string RescuerEmail { get; set; } = "none";
        public string StartingPoint { get; set; }
        public string EndPoint { get; set; }
    }
}
