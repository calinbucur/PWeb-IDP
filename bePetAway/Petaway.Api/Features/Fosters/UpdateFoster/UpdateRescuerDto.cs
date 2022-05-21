using Petaway.Core.Domain.Foster;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.Fosters.UpdateFoster
{
    public record UpdateFosterDto
    {
        public UpdateFosterDto(string name, string phoneNumber, string address, string photoPath, int maxCapacity)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            PhotoPath = photoPath;
            MaxCapacity = maxCapacity;
        }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoPath { get; set; }
        public int MaxCapacity { get; set; }
    }
}
