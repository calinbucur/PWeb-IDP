using Petaway.Core.SeedWork;
using MediatR;

namespace Petaway.Core.Domain.Owner
{
    public record AddAnimalToOwnerCommand : INotification //ICreateAggregateCommand
    {
        public AddAnimalToOwnerCommand(string email, string name, string type, int age, string description, string status = "home")
        {
//            OwnerId = ownerId;
            Email = email;
            Name = name;
            Type = type;
            Age = age;
            Description = description;
            Status = status;
        }
//        public int OwnerId { get; set; }

        public string Email { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }
        public string Status { get; init; }
        public int Age { get; init; }
        public string Description { get; init; }
    }
}
