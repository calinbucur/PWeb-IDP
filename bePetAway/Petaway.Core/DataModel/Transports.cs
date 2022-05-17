using Petaway.Core.SeedWork;

namespace Petaway.Core.DataModel
{
    public class Transports : Entity, IAggregateRoot
    {
        public Transports(int ownerId, int animalId, int fosterId, int rescuerId, string startPoint, string endPoint)
        {
            OwnerId = ownerId;
            AnimalId = animalId;
            FosterId = fosterId;
            RescuerId = rescuerId;
            StartingPoint = startPoint;
            EndPoint = endPoint;
        }

        //Set to true if an Owner rejects the transport if there aren't any animals in that transport
        //Set to true if a Foster rejects the transport if there is no Rescuer involved yet (rescuerId = -1)
        //Deleted if RejectedByOwnerOrFoster = true
        public bool RejectedByOwnerOrFoster { get; set; } = false;
        public bool IsFinished { get; set; } = false;
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