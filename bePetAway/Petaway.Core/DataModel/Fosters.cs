using Petaway.Core.SeedWork;

namespace Petaway.Core.DataModel
{
    public class Fosters : Entity
    {
        public Fosters(string fosterId,
                       string email,
                       string name,
                       string phoneNumber,
                       string address,
                       string password,
                       int _maxCapacity)
        {
            FosterId = fosterId;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Password = password;
            CrtCapacity = 0;
            MaxCapacity = _maxCapacity;
        }

        public string FosterId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int CrtCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public bool NeedFunds { get; set; } = false;
        public Dictionary<string, string> Requirements { get; set; } = new Dictionary<string, string>(); /*exemplu isSick : all => Accepta si true si false, type : all => Accepta orice animal/croc => Accepta doar crocodili*/
        public virtual ICollection<Animals> Animals { get; set; } = new List<Animals>();
    }
}
