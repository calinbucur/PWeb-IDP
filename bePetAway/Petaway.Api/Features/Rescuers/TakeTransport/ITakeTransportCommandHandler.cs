using Petaway.Core.Domain;

namespace Petaway.Api.Features.Rescuers.TakeTransport
{
    public interface ITakeTransportCommandHandler
    {
        public Task HandleAsync(TakeTransportCommand command, string identityId, CancellationToken cancellationToken);
    }
}