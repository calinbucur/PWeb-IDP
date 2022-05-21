using Petaway.Core.Domain;

namespace Petaway.Api.Features.Fosters.ViewFosterAnimals
{
    public interface IViewFosterAnimalsCommandHandler
    {
        public Task<IEnumerable<ViewFosterAnimalsDto>> HandleAsync(string identityId, CancellationToken cancellation);
    }
}
