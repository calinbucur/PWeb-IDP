using Petaway.Core.Domain;

namespace Petaway.Api.Features.Rescuers.RegisterRescuer
{
    public interface IRegisterRescuerCommandHandler
    {
        public Task HandleAsync(RegisterRescuerCommand command, string identityId, CancellationToken cancellation);
    }
}
