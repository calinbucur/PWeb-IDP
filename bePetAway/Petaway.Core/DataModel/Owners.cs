namespace Petaway.Core.DataModel
{
    public class Owners : Users
    {
        public Owners(string ownerId, string email, string name, string phoneNumber, string address) : base(ownerId, email, name, phoneNumber, address)
        {
            NumberOfAnimals = 0;
        }

        public int NumberOfAnimals { get; set; }
        public virtual ICollection<Animals> Animals{ get; set; } = new List<Animals>();
    }
}