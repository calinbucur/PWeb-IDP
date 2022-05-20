namespace Petaway.Core.DataModel
{
    public class Rescuers : Users
    {
        public Rescuers(string email, string name, string phoneNumber, string address, string photoPath) : base(email, name, phoneNumber, address, photoPath) //, int maxCapacity, string animalType = "all", string isAggresive = "all", string isSick = "all", string isStray = "all"
        {

            /*AnimalType = animalType; *//*all, cat, dog, rodent, bird, domestic, exotic*//*
            CrtCapacity = 0;
            MaxCapacity = maxCapacity;
            IsAggresive = isAggresive; *//*all, aggressive, calm*//*
            IsSick = isSick; *//*all, healthy, sick*//*
            IsStray = isStray; *//*all, healthy, sick*/
        }

        
        //Preferences
        /*exemplu isSick : all => Accepta si true si false, type : all => Accepta orice animal/croc => Accepta doar crocodili*/
/*        public string AnimalType { get; set; }
        public int CrtCapacity { get; set; }        
        public int MaxCapacity { get; set; }
        public bool NeedFunds { get; set; } = false;
        public string IsAggresive { get; set; }
        public string IsSick { get; set; }
        public string IsStray { get; set; }*/
        public int CrtTransportId { get; set; } = -1;
        public virtual ICollection<Transports> TransportHistory { get; set; } = new List<Transports>();
    }
}
