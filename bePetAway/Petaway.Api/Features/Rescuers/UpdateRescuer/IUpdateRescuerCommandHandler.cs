using Petaway.Core.Domain;

namespace Petaway.Api.Features.Rescuers.UpdateRescuer
{
    public interface IUpdateRescuerCommandHandler
    {
        public Task HandleAsync(UpdateRescuerDto command, string identityId, CancellationToken cancellationToken);
    }
}
