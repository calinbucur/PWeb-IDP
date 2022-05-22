using Petaway.Core.SeedWork;

namespace Petaway.Core.DataModel
{
    public class Transports : Entity, IAggregateRoot
    {
        public Transports(string ownerEmail, int animalId, string fosterEmail, string rescuerEmail, string startPoint, string endPoint)
        {
            OwnerEmail = ownerEmail;
            AnimalId = animalId;
            FosterEmail = fosterEmail;
            RescuerEmail = rescuerEmail;
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        //Set to true if an Owner rejects the transport if there aren't any animals in that transport
        //Set to true if a Foster rejects the transport if there is no Rescuer involved yet (rescuerId = -1)
        //Deleted if RejectedByOwnerOrFoster = true
        public bool RejectedByOwnerOrFoster { get; set; } = false;
        public bool IsFinished { get; set; } = false;
        public string OwnerEmail { get; set; } = "none";
        public int AnimalId { get; set; }
        public string FosterEmail { get; set; } = "none";
        public string RescuerEmail { get; set; } = "none";
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public virtual ICollection<Animals> Animals { get; set; } = new List<Animals>();
    }
}