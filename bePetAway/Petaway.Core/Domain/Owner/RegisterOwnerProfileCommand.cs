using Newtonsoft.Json;
using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Owner
{
    public record RegisterOwnerProfileCommand : ICreateAggregateCommand
    {
        public RegisterOwnerProfileCommand(string userId, string email, string name, string phoneNumber, string address)
        {
            UserId = userId;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
