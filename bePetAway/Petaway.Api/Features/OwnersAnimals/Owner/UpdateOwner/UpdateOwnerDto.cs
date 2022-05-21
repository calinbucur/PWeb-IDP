using Petaway.Core.Domain.Owner;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.OwnersAnimals.Owner.UpdateOwner
{
    public record UpdateOwnerDto
    {
        public UpdateOwnerDto(string name, string phoneNumber, string address, string photoPath)
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
