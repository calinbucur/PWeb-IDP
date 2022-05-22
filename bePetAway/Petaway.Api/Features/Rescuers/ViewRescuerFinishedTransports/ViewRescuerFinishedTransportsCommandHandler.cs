using Petaway.Core.Domain.Rescuer;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.Rescuers.ViewRescuerFinishedTransports
{
    public class ViewRescuerFinishedTransportsCommandHandler : IViewRescuerFinishedTransportsCommandHandler
    {
        private readonly PetawayContext dbContext;
        private readonly IRescuersRepository rescuersRepository;

        public ViewRescuerFinishedTransportsCommandHandler(PetawayContext dbContext, IRescuersRepository rescuersRepository)
        {
            this.dbContext = dbContext;
            this.rescuersRepository = rescuersRepository;
        }

        public async Task<IEnumerable<ViewRescuerFinishedTransportsDto>> HandleAsync(string identityId, CancellationToken cancellationToken)
        {
            var rescuerDomain = await rescuersRepository.GetByIdentityIdAsync(identityId, cancellationToken) as RescuersDomain;

            if (rescuerDomain == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Rescuer with identity {identityId} does not have a registered profile");
            }

            var query = from transport in dbContext.Transports
                        where (transport.RescuerEmail == rescuerDomain.GetAggregate().Email) && transport.IsFinished
                        select new ViewRescuerFinishedTransportsDto(transport);

            var result = await query
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return result;
        }
        
    }

}
