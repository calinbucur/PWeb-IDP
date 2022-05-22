using Petaway.Core.Domain;

namespace Petaway.Api.Features.Fosters.GetFosterExternal
{
    public interface IGetFosterExternalCommandHandler
    {
        public Task<GetFosterExternalDto> HandleAsync(string fosterEmail, CancellationToken cancellation);
    }
}
