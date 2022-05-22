using Petaway.Core.Domain.Foster;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.Fosters.GetFoster
{
    public record GetFosterDto
    {
        public GetFosterDto(string email, string name, string phoneNumber, string address, string photoPath, int crtCapacity, int maxCapacity)
        {
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            PhotoPath = photoPath;
            CrtCapacity = crtCapacity;
            MaxCapacity = maxCapacity;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoPath { get; set; }
        public int CrtCapacity { get; set; }
        public int MaxCapacity { get; set; }
    }
}
