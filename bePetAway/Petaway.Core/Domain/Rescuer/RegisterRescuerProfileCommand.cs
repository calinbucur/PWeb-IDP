using Petaway.Core.SeedWork;
using Petaway.Core.DataModel;

namespace Petaway.Core.Domain.Rescuer
{
    public record RegisterRescuerProfileCommand : ICreateAggregateCommand
    {
        public RegisterRescuerProfileCommand(string email, string name, string phoneNumber, string address, string photoPath) //, int maxCapacity, string animalType = "all", string isAggresive = "all", string isSick = "all", string isStray = "all")
        {
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            PhotoPath = photoPath;

/*            CrtCapacity = 0;
            MaxCapacity = maxCapacity;
            AnimalType = animalType; *//*all, cat, dog, rodent, bird, domestic, exotic*//*
            IsAggresive = isAggresive; *//*all, aggressive, calm*//*
            IsSick = isSick; *//*all, healthy, sick*//*
            IsStray = isStray; *//*all, healthy, sick*/
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoPath { get; set; }

/*        public int CrtCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public string AnimalType { get; set; }
        public string IsAggresive { get; set; }
        public string IsSick { get; set; }
        public string IsStray { get; set; }*/
    }
}
