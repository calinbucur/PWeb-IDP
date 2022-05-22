using Petaway.Core.Domain;

namespace Petaway.Api.Features.OwnersAnimals.Owner.GetOwnerExternal
{
    public interface IGetOwnerExternalCommandHandler
    {
        public Task<GetOwnerExternalDto> HandleAsync(string ownerEmail, CancellationToken cancellation);
    }
}
