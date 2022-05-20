using Petaway.Core.Domain.Owner;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.OwnersAnimals.Owner.RegisterOwner
{
    public record RegisterOwnerCommand : RegisterOwnerProfileCommand
    {
        public RegisterOwnerCommand(string email, string name, string phoneNumber, string address, string photoPath) : base(email, name, phoneNumber, address, photoPath)
        {

        }
    }
}
