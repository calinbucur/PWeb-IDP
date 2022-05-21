using Newtonsoft.Json;
using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Owner
{
    public record RegisterOwnerProfileCommand : ICreateAggregateCommand
    {
        public RegisterOwnerProfileCommand(string identityId, string email, string name, string phoneNumber, string address, string photoPath)
        {
            IdentityId = identityId;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            PhotoPath = photoPath;
        }

        public string IdentityId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("photoPath")]
        public string PhotoPath { get; set; }

    }
}
