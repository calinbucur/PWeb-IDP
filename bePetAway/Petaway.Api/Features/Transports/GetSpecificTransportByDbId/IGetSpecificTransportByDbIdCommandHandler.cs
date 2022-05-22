using Petaway.Core.Domain;

namespace Petaway.Api.Features.Transports.GetSpecificTransportByDbId
{
    public interface IGetSpecificTransportByDbIdCommandHandler
    {
        public Task<IEnumerable<GetSpecificTransportByDbIdDto>> HandleAsync(int transportId, CancellationToken cancellation);
    }
}
