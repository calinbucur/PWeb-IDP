using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Owner
{
    public record AddAnimalToOwnerCommand : ICreateAggregateCommand
    {
        public AddAnimalToOwnerCommand(string name, string type, string description, int age, string location, bool isAgg, bool isSick, bool isStray, bool isHome = true)
        {
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

        public string Name { get; init; }
        public string Type { get; init; }
        public bool IsHome { get; init; }
        public bool IsAggresive { get; init; }
        public bool IsSick { get; init; }
        public bool IsStray { get; init; }
        public int Age { get; init; }
        public string Description { get; init; }
        public string Location { get; init; }
    }


}
