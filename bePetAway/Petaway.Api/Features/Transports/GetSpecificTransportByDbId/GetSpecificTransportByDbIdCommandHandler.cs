using Petaway.Core.Domain.Owner;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.Transports.GetSpecificTransportByDbId
{
    public class GetSpecificTransportByDbIdCommandHandler : IGetSpecificTransportByDbIdCommandHandler
    {
        private readonly PetawayContext dbContext;

        public GetSpecificTransportByDbIdCommandHandler(PetawayContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GetSpecificTransportByDbIdDto>> HandleAsync(int transportId, CancellationToken cancellationToken)
        {
            var query = from transport in dbContext.Transports
                        where (transport.Id == transportId)
                        select new GetSpecificTransportByDbIdDto(transport);

            var result = await query
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return result;
        }
        
    }

}
