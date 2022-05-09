using Petaway.Core.SeedWork;

namespace Petaway.Core.DataModel
{
    public class Animals : Entity
    {
        public Animals(string animalId, string name, string type, string description, int age, string location, bool _isAgg, bool _isSick, bool _isStray)
        {
            AnimalId = animalId;
            Name = name;
            Type = type;
            isAggresive = _isAgg;
            isSick = _isSick;
            isStray = _isStray;
            Age = age;
            Description = description;
            Location = location;
        }
        public string AnimalId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } /*cat, dog, exotic (zoo animals), etc*/
        public string Description { get; set; }
        public bool isAggresive { get; set; }
        public bool isSick { get; set; }
        public bool isStray { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }

        public Transports? crtTransport;
    }
}
