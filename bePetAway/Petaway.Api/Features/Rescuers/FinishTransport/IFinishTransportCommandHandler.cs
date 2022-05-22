using Petaway.Core.Domain;

namespace Petaway.Api.Features.Rescuers.FinishTransport
{
    public interface IFinishTransportCommandHandler
    {
       public Task HandleAsync(string identityId, CancellationToken cancellationToken);
    }
}