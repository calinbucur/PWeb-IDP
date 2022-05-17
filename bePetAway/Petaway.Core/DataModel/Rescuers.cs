namespace Petaway.Core.DataModel
{
    public class Rescuers : Users
    {
        public Rescuers(string rescuerId, string email, string name, string phoneNumber, string address, int maxCapacity, Preferences preferences) : base(rescuerId, email, name, phoneNumber, address)
        {
            CrtCapacity = 0;
            MaxCapacity = maxCapacity;

            Preferences = preferences;
        }

        public int CrtCapacity { get; set; }        
        public int MaxCapacity { get; set; }
        public bool NeedFunds { get; set; } = false;
        public Preferences Preferences { get; set; } /*exemplu isSick : all => Accepta si true si false, type : all => Accepta orice animal/croc => Accepta doar crocodili*/
        public int CrtTransportId { get; set; } = -1;
        public virtual ICollection<Transports> TransportHistory { get; set; } = new List<Transports>();
    }
}
