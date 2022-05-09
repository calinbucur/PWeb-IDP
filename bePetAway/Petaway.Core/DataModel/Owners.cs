using Petaway.Core.SeedWork;

namespace Petaway.Core.DataModel
{
    public class Owners : Entity, IAggregateRoot
    {
        public Owners(string ownerId, string email, string name, string phoneNumber, string address, string password)
        {
            OwnerId = ownerId;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Password = password;
        }
        public string OwnerId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        private string Password { get; set; }
        public virtual ICollection<Animals> Animals{ get; set; } = new List<Animals>();
    }
}