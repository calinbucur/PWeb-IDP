using Petaway.Core.Domain;

namespace Petaway.Api.Features.OwnersAnimals.Animal.ViewOwnerAnimals
{
    public interface IViewOwnerAnimalsCommandHandler
    {
        public Task<IEnumerable<ViewOwnerAnimalsDto>> HandleAsync(string ownerEmail, CancellationToken cancellation);
    }
}
