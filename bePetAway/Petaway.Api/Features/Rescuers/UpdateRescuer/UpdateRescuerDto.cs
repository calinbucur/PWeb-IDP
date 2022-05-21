using Petaway.Core.Domain.Rescuer;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.Rescuers.UpdateRescuer
{
    public record UpdateRescuerDto
    {
        public UpdateRescuerDto(string name, string phoneNumber, string address, string photoPath, int maxCapacity)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            PhotoPath = photoPath;
        }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoPath { get; set; }
    }
}
