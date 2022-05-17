using Petaway.Core.SeedWork;
using Petaway.Core.DataModel;

namespace Petaway.Core.Domain.Foster
{
    public record RegisterFosterProfileCommand : ICreateAggregateCommand
    {
        public RegisterFosterProfileCommand(string userId, string email, string name, string phoneNumber, string address, int maxCapacity, string animalType = "all", string isAggresive = "all", string isSick = "all", string isStray = "all")
        {
            UserId = userId;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            CrtCapacity = 0;
            VirtualCapacity = 0;
            MaxCapacity = maxCapacity;

            //In case we don't use PREFERENCES keyword to search: NOPREFS
            AnimalType = animalType; /*all, cat, dog, rodent, bird, domestic, exotic*/
            IsAggresive = isAggresive; /*all, aggressive, calm*/
            IsSick = isSick; /*all, healthy, sick*/
            IsStray = isStray; /*all, healthy, sick*/
        }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CrtCapacity { get; set; }
        public int VirtualCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public string AnimalType { get; set; }
        public string IsAggresive { get; set; }
        public string IsSick { get; set; }
        public string IsStray { get; set; }
    }
}
