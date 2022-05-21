using Petaway.Core.Domain;

namespace Petaway.Api.Features.Fosters.ProposeTransfer
{
    public interface IProposeTransferCommandHandler
    {
        public Task HandleAsync(ProposeTransferCommand command, string identityId, CancellationToken cancellationToken);
    }
}