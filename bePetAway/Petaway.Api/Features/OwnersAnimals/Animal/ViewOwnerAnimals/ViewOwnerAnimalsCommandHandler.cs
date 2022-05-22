using Petaway.Core.Domain.Owner;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.OwnersAnimals.Animal.ViewOwnerAnimals
{
    public class ViewOwnerAnimalsCommandHandler : IViewOwnerAnimalsCommandHandler
    {
        private readonly PetawayContext dbContext;

        public ViewOwnerAnimalsCommandHandler(PetawayContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ViewOwnerAnimalsDto>> HandleAsync(string identityId, CancellationToken cancellationToken)
        {
            var owner = await dbContext.Owners.FirstOrDefaultAsync(x => x.IdentityId == identityId);

            if (owner == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Owner with identity {identityId} does not have a registered profile");
            }

            var query = from animal in dbContext.Animals
                        where animal.OwnerEmail == owner.Email
                        select new ViewOwnerAnimalsDto(animal);

            var result = await query
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return result;
        }
        
    }

}
