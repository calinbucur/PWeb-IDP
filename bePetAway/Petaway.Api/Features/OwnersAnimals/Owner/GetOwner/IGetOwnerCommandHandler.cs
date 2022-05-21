using Petaway.Core.Domain;

namespace Petaway.Api.Features.OwnersAnimals.Owner.GetOwner
{
    public interface IGetOwnerCommandHandler
    {
        public Task<GetOwnerDto> HandleAsync(string identityId, CancellationToken cancellation);
    }
}
