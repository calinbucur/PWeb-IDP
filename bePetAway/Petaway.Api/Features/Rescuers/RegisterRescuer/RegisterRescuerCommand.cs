using Petaway.Core.Domain.Rescuer;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.Rescuers.RegisterRescuer
{
    public record RegisterRescuerCommand
    {
        public RegisterRescuerCommand(string email, string name, string phoneNumber, string address, string photoPath)
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
