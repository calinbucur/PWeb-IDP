using Petaway.Core.Domain;


namespace Petaway.Api.Features.Rescuers.ViewRescuerFinishedTransports
{
    public interface IViewRescuerFinishedTransportsCommandHandler
    {
        public Task<IEnumerable<ViewRescuerFinishedTransportsDto>> HandleAsync(string identityId, CancellationToken cancellation);
    }
}
