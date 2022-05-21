using Petaway.Core.Domain;

namespace Petaway.Api.Features.Rescuers.GetRescuer
{
    public interface IGetRescuerCommandHandler
    {
        public Task<GetRescuerDto> HandleAsync(string identityId, CancellationToken cancellation);
    }
}
