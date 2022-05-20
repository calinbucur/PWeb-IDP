using Petaway.Core.SeedWork;

namespace Petaway.Core.DataModel
{
    public class Users : Entity, IAggregateRoot
    {
        public Users(string email, string name, string phoneNumber, string address, string photoPath)
        {
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            PhotoPath = photoPath;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoPath { get; set; }

    }
}