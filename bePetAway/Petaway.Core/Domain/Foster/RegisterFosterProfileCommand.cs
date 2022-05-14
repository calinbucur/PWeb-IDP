using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Foster
{
    public record RegisterFosterProfileCommand : ICreateAggregateCommand
    {
        public RegisterFosterProfileCommand(string fosterId, string email, string name, string phoneNumber, string address, string password, int maxCapacity)
        {
            UserId = fosterId;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Password = password;
            CrtCapacity = 0;
            VirtualCapacity = 0;
            MaxCapacity = maxCapacity;
        }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int CrtCapacity { get; set; }
        public int VirtualCapacity { get; set; }
        public int MaxCapacity { get; set; }
    }
}
