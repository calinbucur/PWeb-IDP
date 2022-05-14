namespace Petaway.Core.DataModel
{
    public class Rescuers : Users
    {
        public Rescuers(string rescuerId, string email, string name, string phoneNumber, string address, string password, int maxCapacity) : base(rescuerId, email, name, phoneNumber, address, password)
        {
            CrtCapacity = 0;
            VirtualCapacity = 0;
            MaxCapacity = maxCapacity;
        }

        public int CrtCapacity { get; set; }        
        public int VirtualCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public bool needFunds { get; set; } = false;
        public Dictionary<string, string> Requirements { get; set; } = new Dictionary<string, string>(); /*exemplu isSick : all => Accepta si true si false, type : all => Accepta orice animal/croc => Accepta doar crocodili*/
        public Transports? CrtTransport { get; set; }
        public virtual ICollection<Transports> TransportHistory { get; set; } = new List<Transports>();
    }
}
