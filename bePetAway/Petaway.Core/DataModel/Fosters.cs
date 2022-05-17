namespace Petaway.Core.DataModel
{
    public class Fosters : Users
    {
        public Fosters(string fosterId, string email, string name, string phoneNumber, string address, int maxCapacity, Preferences preferences) : base(fosterId, email, name, phoneNumber, address)
        {
            CrtCapacity = 0;
            MaxCapacity = maxCapacity;
            Preferences = preferences;
        }

        public int CrtCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public bool NeedFunds { get; set; } = false;
        public Preferences Preferences { get; set; } /*exemplu isSick : all => Accepta si true si false, type : all => Accepta orice animal/croc => Accepta doar crocodili*/
        public virtual ICollection<Animals> Animals { get; set; } = new List<Animals>();
    }
}
