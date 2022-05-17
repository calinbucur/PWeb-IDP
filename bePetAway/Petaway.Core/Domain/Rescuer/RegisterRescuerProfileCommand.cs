using Petaway.Core.SeedWork;
using Petaway.Core.DataModel;

namespace Petaway.Core.Domain.Rescuer
{
    public record RegisterRescuerProfileCommand : ICreateAggregateCommand
    {
        public RegisterRescuerProfileCommand(string rescuerId, string email, string name, string phoneNumber, string address, string password, int maxCapacity, string type = "all", string isAgg = "all", string isSick = "all", string isStray = "all")
        {
            UserId = rescuerId;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            CrtCapacity = 0;
            VirtualCapacity = 0;
            MaxCapacity = maxCapacity;

            //In case we don't use PREFERENCES keyword to search: NOPREFS
            /*if ((type == null) || (isAgg == null) || (isSick == null) || (isStray == null)) {
                Preferences = null;
            }*/

            Preferences = new Preferences(type, isAgg, isSick, isStray);
        }

        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CrtCapacity { get; set; }
        public int VirtualCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public Preferences Preferences { get; set; }
    }
}
