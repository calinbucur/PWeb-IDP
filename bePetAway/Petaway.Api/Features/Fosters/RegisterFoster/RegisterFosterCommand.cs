using Petaway.Core.Domain.Foster;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.Fosters.RegisterFoster
{
   public record RegisterFosterCommand
    {
        public RegisterFosterCommand(string email, string name, string phoneNumber, string address, string photoPath, int maxCapacity)
        {
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            PhotoPath = photoPath;
            MaxCapacity = maxCapacity;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoPath { get; set; }
        public int MaxCapacity { get; set; }
    }
}
