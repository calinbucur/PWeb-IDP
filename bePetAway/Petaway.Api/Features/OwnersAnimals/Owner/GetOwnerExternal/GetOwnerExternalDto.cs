using Petaway.Core.Domain.Owner;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.OwnersAnimals.Owner.GetOwnerExternal
{
    public record GetOwnerExternalDto
    {
        public GetOwnerExternalDto(string email, string name, string phoneNumber, string address, string photoPath, int numberOfAnimals)
        {
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            PhotoPath = photoPath;
            NumberOfAnimals = numberOfAnimals;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoPath { get; set; }
        public int NumberOfAnimals { get; set; }
    }
}
