using Petaway.Core.Domain.Owner;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.Transports.ViewDisponibleTransports
{
    public class ViewDisponibleTransportsCommandHandler : IViewDisponibleTransportsCommandHandler
    {
        private readonly PetawayContext dbContext;

        public ViewDisponibleTransportsCommandHandler(PetawayContext dbContext, IMediator mediator)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ViewDisponibleTransportsDto>> HandleAsync(CancellationToken cancellationToken)
        {
            var query = from transport in dbContext.Transports
                        where transport.RescuerEmail == "none"
                        select new ViewDisponibleTransportsDto(transport);

            var result = await query
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return result;
        }
        
    }

}
