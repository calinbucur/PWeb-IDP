using Petaway.Core.SeedWork;

namespace Petaway.Core.DataModel
{
    public class Animals : Entity
    {
        public Animals(string name, string type, int age, string status, string description) //, bool isAggresive, bool isSick, bool isStray)
        {
            Name = name;
            Type = type; /* cat, dog, rodent, bird, domestic, exotic*/
            Age = age; 
            Status = status;
            Description = description;

/*            IsAggresive = isAggresive;
            IsSick = isSick;
            IsStray = isStray; */
        }
        public string Name { get; set; }
        public string Type { get; set; } /*cat, dog, exotic (zoo animals), etc*/
        public int Age { get; set; }
        public string Status { get; set; } = "home";  /*home, pending, travelling, foster*/
        public string Description { get; set; }

        /*        public bool IsAggresive { get; set; }
                public bool IsSick { get; set; }
                public bool IsStray { get; set; }*/

        public int OwnerId { get; set; } = -1;
        public int CrtTransportId { get; set; } = -1;
        public int CrtFosterId { get; set; } = -1; 
        public int CrtRescuerId { get; set; } = -1;
    }
}
