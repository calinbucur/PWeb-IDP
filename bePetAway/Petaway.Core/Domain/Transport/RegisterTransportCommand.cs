using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Transport
{
    public record RegisterTransportProfileCommand : ICreateAggregateCommand
    {
        public RegisterTransportProfileCommand(int ownerId, int animalId, int fosterId, int rescuerId, string startPoint, string endPoint)
        {
            TransportState = -1;
            OwnerId = ownerId;
            AnimalId = animalId;
            FosterId = fosterId;
            RescuerId = rescuerId;
            StartingPoint = startPoint;
            EndPoint = endPoint;
        }
        public int TransportState { get; set; }
        public int OwnerId { get; set; }
        public int AnimalId { get; set; }
        public int FosterId { get; set; }
        public int RescuerId { get; set; }
        public string StartingPoint { get; set; }
        public string EndPoint { get; set; }
    }
}
