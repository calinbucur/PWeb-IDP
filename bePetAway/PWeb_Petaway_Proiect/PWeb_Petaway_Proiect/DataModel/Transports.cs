using Petaway.Core.SeedWork;

namespace Petaway.Core.DataModel
{
    public class Transports : Entity
    {
        public Transports(int ownerId, int animalId, int fosterId, int rescuerId)
        {
            OwnerId = ownerId;
            AnimalId = animalId;
            FosterId = fosterId;
            RescuerId = rescuerId;
        }

        public int OwnerId { get; set; }
        public int AnimalId { get; set; }
        public int FosterId { get; set; }
        public int RescuerId { get; set; }
        public string StartingPoint { get; set; }
        public string EndPoint { get; set; }
        public string? CrtLocation { get; set; }
        public virtual Animals Animal{ get; set; } = null!;
    }
}
