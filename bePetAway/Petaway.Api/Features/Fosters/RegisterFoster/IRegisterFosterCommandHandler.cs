using Petaway.Core.Domain;

namespace Petaway.Api.Features.Fosters.RegisterFoster
{
    public interface IRegisterFosterCommandHandler
    {
        public Task HandleAsync(RegisterFosterCommand command, CancellationToken cancellation);
    }
}
