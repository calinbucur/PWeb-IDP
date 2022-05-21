using Petaway.Core.Domain;

namespace Petaway.Api.Features.Fosters.GetFoster
{
    public interface IGetFosterCommandHandler
    {
        public Task<GetFosterDto> HandleAsync(string identityId, CancellationToken cancellation);
    }
}
