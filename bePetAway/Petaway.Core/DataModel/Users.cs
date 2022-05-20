using Petaway.Core.SeedWork;

namespace Petaway.Core.DataModel
{
    public class Users : Entity, IAggregateRoot
    {
        public Users(string identityId,  string email, string name, string phoneNumber, string address, string photoPath)
        {
            IdentityId = identityId;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            PhotoPath = photoPath;
        }

        public string IdentityId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoPath { get; set; }

    }
}