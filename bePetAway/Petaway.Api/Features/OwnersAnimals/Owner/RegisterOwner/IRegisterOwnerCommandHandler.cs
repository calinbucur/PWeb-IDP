using Petaway.Core.Domain;

namespace Petaway.Api.Features.OwnersAnimals.Owner.RegisterOwner
{
    public interface IRegisterOwnerCommandHandler
    {
        public Task HandleAsync(RegisterOwnerCommand command, CancellationToken cancellation);
    }
}
