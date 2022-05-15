using Petaway.Core.SeedWork;

namespace Petaway.Core.DataModel
{
    public class Animals : Entity
    {
        public Animals(string name, string type, string description, int age, string location, bool isAgg, bool isSick, bool isStray, bool isHome = true) //, int animalId)
        {
            //AnimalId = animalId;
            Name = name;
            Type = type;
            IsHome = isHome;
            IsAggresive = isAgg;
            IsSick = isSick;
            IsStray = isStray;
            Age = age;
            Description = description;
            Location = location;
        }
//        public int AnimalId { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } /*cat, dog, exotic (zoo animals), etc*/
        public bool IsHome { get; set; }
        public string Description { get; set; }
        public bool IsAggresive { get; set; }
        public bool IsSick { get; set; }
        public bool IsStray { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }

        public Transports? crtTransport;

        public Fosters? crtFoster;
    }
}
