namespace Petaway.Core.DataModel
{
    public class Fosters : Users
    {
        public Fosters(string userId, string email, string name, string phoneNumber, string address, int maxCapacity, string animalType = "all", string isAggresive = "all", string isSick = "all", string isStray = "all") : base(userId, email, name, phoneNumber, address)
        {
            CrtCapacity = 0;
            MaxCapacity = maxCapacity;

            AnimalType = animalType; /*all, cat, dog, rodent, bird, domestic, exotic*/
            IsAggresive = isAggresive; /*all, aggressive, calm*/
            IsSick = isSick; /*all, healthy, sick*/
            IsStray = isStray; /*all, healthy, sick*/
        }

        public int CrtCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public bool NeedFunds { get; set; } = false;

        //Preferences
        /*exemplu isSick : all => Accepta si true si false, type : all => Accepta orice animal/croc => Accepta doar crocodili*/
        public string AnimalType { get; set; }
        public string IsAggresive { get; set; }
        public string IsSick { get; set; }
        public string IsStray { get; set; }
        public virtual ICollection<Animals> Animals { get; set; } = new List<Animals>();
    }
}
