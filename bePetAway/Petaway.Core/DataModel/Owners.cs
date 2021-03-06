namespace Petaway.Core.DataModel
{
    public class Owners : Users
    {
        public Owners(string identityId, string email, string name, string phoneNumber, string address, string photoPath) : base(identityId, email, name, phoneNumber, address, photoPath)
        {
            NumberOfAnimals = 0;
        }

        public int NumberOfAnimals { get; set; }
        public virtual ICollection<Animals> Animals{ get; set; } = new List<Animals>();
    }
}