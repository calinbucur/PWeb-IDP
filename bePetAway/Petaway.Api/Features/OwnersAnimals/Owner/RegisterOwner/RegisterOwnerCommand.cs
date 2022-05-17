using Petaway.Core.Domain.Owner;

namespace Petaway.Api.Features.OwnersAnimals.Owner.RegisterOwner
{
    public record RegisterOwnerCommand : RegisterOwnerProfileCommand
    {
        public RegisterOwnerCommand(string ownerId, string email, string name, string phoneNumber, string address) : base(ownerId, email, name, phoneNumber, address)
        {

        }
    }
}
