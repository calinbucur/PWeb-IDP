using Petaway.Core.SeedWork;

namespace Petaway.Core.DataModel
{
    public class Users : Entity, IAggregateRoot
    {
        public Users(string userId, string email, string name, string phoneNumber, string address)
        {
            UserId = userId;
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