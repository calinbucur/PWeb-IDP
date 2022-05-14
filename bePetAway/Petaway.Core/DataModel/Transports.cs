using Petaway.Core.SeedWork;

namespace Petaway.Core.DataModel
{
    public class Transports : Entity, IAggregateRoot
    {
        public Transports(int ownerId, int animalId, int fosterId, int rescuerId, string startPoint, string endPoint)
        {
            TransportState = -1;
            OwnerId = ownerId;
            AnimalId = animalId;
            FosterId = fosterId;
            RescuerId = rescuerId;
            StartingPoint = startPoint;
            EndPoint = endPoint;
        }

        //Shows if the transport is accepted(1), rejected(0) or pending(-1)
        public int TransportState { get; set; }
        public int OwnerId { get; set; }
        public int AnimalId { get; set; }
        public int FosterId { get; set; }
        public int RescuerId { get; set; }
        public string StartingPoint { get; set; }
        public string EndPoint { get; set; }
        public string? CrtLocation { get; set; }
        public virtual ICollection<Animals> Animals { get; set; } = new List<Animals>();
    }
}