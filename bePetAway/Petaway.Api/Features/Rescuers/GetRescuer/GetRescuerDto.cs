using Petaway.Core.Domain.Rescuer;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.Rescuers.GetRescuer
{
    public record GetRescuerDto
    {
        public GetRescuerDto(string email, string name, string phoneNumber, string address, string photoPath)
        {
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            PhotoPath = photoPath;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoPath { get; set; }
    }
}
