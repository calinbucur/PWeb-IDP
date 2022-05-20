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

        public async Task<IEnumerable<ViewOwnerAnimalsDto>> HandleAsync(string ownerEmail, CancellationToken cancellationToken)
        {
            var owner = await dbContext.Owners.FirstOrDefaultAsync(x => x.Email == ownerEmail);

            if (owner == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Owner with identity {ownerEmail} does not have a registered profile");
            }

            var ownerProfileId = owner.Id;

            var query = from animal in dbContext.Animals
                        where animal.OwnerId == ownerProfileId
                        select new ViewOwnerAnimalsDto(animal);

            var result = await query
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return result;
        }
        
    }

}
