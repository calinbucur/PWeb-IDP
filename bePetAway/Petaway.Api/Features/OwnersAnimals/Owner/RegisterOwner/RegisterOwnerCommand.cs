using Petaway.Core.Domain.Owner;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.OwnersAnimals.Owner.RegisterOwner
{
    public record RegisterOwnerCommand : RegisterOwnerProfileCommand
    {
        public RegisterOwnerCommand(string userId, string email, string name, string phoneNumber, string address) : base(userId, email, name, phoneNumber, address)
        {

        }
    }
}
