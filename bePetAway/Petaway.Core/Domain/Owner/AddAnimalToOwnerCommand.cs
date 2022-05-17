using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Owner
{
    public record AddAnimalToOwnerCommand : ICreateAggregateCommand
    {
        public AddAnimalToOwnerCommand(int ownerId, string name, string type, string description, int age, string location, bool isAgg, bool isSick, bool isStray, string status = "home")
        {
            OwnerId = ownerId;
            Name = name;
            Type = type;
            Status = status;
            IsAggresive = isAgg;
            IsSick = isSick;
            IsStray = isStray;
            Age = age;
            Description = description;
            Location = location;
        }
        public int OwnerId { get; set; }
        public string Name { get; init; }
        public string Type { get; init; }
        public string Status { get; init; }
        public bool IsAggresive { get; init; }
        public bool IsSick { get; init; }
        public bool IsStray { get; init; }
        public int Age { get; init; }
        public string Description { get; init; }
        public string Location { get; init; }
    }
}
