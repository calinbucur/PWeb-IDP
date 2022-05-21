using Petaway.Core.Domain;

namespace Petaway.Api.Features.OwnersAnimals.Owner.UpdateOwner
{
    public interface IUpdateOwnerCommandHandler
    {
        public Task HandleAsync(UpdateOwnerDto command, string identityId, CancellationToken cancellationToken);
    }
}
