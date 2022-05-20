using Petaway.Core.Domain;

namespace Petaway.Api.Features.OwnersAnimals.Animal.ViewRescuableAnimals
{
    public interface IViewRescuableAnimalsCommandHandler
    {
        public Task<IEnumerable<ViewRescuableAnimalsDto>> HandleAsync(CancellationToken cancellation);
    }
}
