using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Owner
{
    public record RegisterOwnerProfileCommand : ICreateAggregateCommand
    {
        public RegisterOwnerProfileCommand(string ownerId, string email, string name, string phoneNumber, string address)
        {
            UserId = ownerId;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
