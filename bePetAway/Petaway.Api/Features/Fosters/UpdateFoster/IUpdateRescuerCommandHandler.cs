using Petaway.Core.Domain;

namespace Petaway.Api.Features.Fosters.UpdateFoster
{
    public interface IUpdateFosterCommandHandler
    {
        public Task HandleAsync(UpdateFosterDto command, string identityId, CancellationToken cancellationToken);
    }
}