using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Owner
{
    public record AddAnimalToOwnerCommand : ICreateAggregateCommand
    {
        public AddAnimalToOwnerCommand(int ownerId, string name, string type, int age, string description, string status = "home")
        {
            OwnerId = ownerId;
            Name = name;
            Type = type;
            Age = age;
            Description = description;
            Status = status;
        }
        public int OwnerId { get; set; }
        public string Name { get; init; }
        public string Type { get; init; }
        public string Status { get; init; }
        public int Age { get; init; }
        public string Description { get; init; }
    }
}
