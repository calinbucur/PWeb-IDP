namespace Petaway.Core.DataModel
{
    public class Owners : Users
    {
        public Owners(string ownerId, string email, string name, string phoneNumber, string address, string password) : base(ownerId, email, name, phoneNumber, address, password)
        {
            NumberOfAnimals = 0;
        }

        public int NumberOfAnimals { get; set; }
        public virtual ICollection<Animals> Animals{ get; set; } = new List<Animals>();
    }
}