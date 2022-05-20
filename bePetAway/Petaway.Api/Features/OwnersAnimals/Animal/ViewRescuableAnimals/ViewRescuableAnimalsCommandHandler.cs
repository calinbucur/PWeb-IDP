using Petaway.Core.Domain.Owner;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.OwnersAnimals.Animal.ViewRescuableAnimals
{
    public class ViewRescuableAnimalsCommandHandler : IViewRescuableAnimalsCommandHandler
    {
        private readonly PetawayContext dbContext;

        public ViewRescuableAnimalsCommandHandler(PetawayContext dbContext, IMediator mediator)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ViewRescuableAnimalsDto>> HandleAsync(CancellationToken cancellationToken)
        {
            var query = from animal in dbContext.Animals
                        where animal.Status == "home"
                        select new ViewRescuableAnimalsDto(animal);

            var result = await query
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return result;
        }
        
    }

}
