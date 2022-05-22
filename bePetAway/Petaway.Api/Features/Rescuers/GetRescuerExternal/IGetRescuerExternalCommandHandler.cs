using Petaway.Core.Domain;

namespace Petaway.Api.Features.Rescuers.GetRescuerExternal
{
    public interface IGetRescuerExternalCommandHandler
    {
        public Task<GetRescuerExternalDto> HandleAsync(string rescuerEmail, CancellationToken cancellation);
    }
}
