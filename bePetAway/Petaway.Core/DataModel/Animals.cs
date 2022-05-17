using Petaway.Core.SeedWork;

namespace Petaway.Core.DataModel
{
    public class Animals : Entity
    {
        public Animals(string name, string type, string description, int age, string location, bool isAggresive, bool isSick, bool isStray, string status = "home") //, int animalId)
        {
            Name = name;
            Type = type;
            Status = status;
            IsAggresive = isAggresive;
            IsSick = isSick;
            IsStray = isStray;
            Age = age;
            Description = description;
            Location = location;
        }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } /*cat, dog, exotic (zoo animals), etc*/
        public string Status { get; set; } /*home, pending, travelling, foster*/
        public string Description { get; set; }
        public bool IsAggresive { get; set; }
        public bool IsSick { get; set; }
        public bool IsStray { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }

        public int CrtTransportId { get; set; } = -1;
        public int CrtFosterId { get; set; } = -1; 
        public int CrtRescuerId { get; set; } = -1;
    }
}
