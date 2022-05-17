namespace Petaway.Core.DataModel
{
    public class Owners : Users
    {
        public Owners(string userId, string email, string name, string phoneNumber, string address) : base(userId, email, name, phoneNumber, address)
        {
            NumberOfAnimals = 0;
        }

        public int NumberOfAnimals { get; set; }
        public virtual ICollection<Animals> Animals{ get; set; } = new List<Animals>();
    }
}