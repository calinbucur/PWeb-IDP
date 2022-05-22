using Petaway.Core.Domain;


namespace Petaway.Api.Features.Transports.ViewDisponibleTransports
{
    public interface IViewDisponibleTransportsCommandHandler
    {
        public Task<IEnumerable<ViewDisponibleTransportsDto>> HandleAsync(CancellationToken cancellation);
    }
}
