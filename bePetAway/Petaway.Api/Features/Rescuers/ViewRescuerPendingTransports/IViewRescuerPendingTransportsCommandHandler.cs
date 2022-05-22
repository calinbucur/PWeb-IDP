using Petaway.Core.Domain;


namespace Petaway.Api.Features.Rescuers.ViewRescuerPendingTransports
{
    public interface IViewRescuerPendingTransportsCommandHandler
    {
        public Task<IEnumerable<ViewRescuerPendingTransportsDto>> HandleAsync(string identityId, CancellationToken cancellation);
    }
}
