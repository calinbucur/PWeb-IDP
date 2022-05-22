using Petaway.Core.Domain.Owner;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.Fosters.ViewFosterAnimals
{
    public class ViewFosterAnimalsCommandHandler : IViewFosterAnimalsCommandHandler
    {
        private readonly PetawayContext dbContext;

        public ViewFosterAnimalsCommandHandler(PetawayContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ViewFosterAnimalsDto>> HandleAsync(string identityId, CancellationToken cancellationToken)
        {
            var foster = await dbContext.Fosters.FirstOrDefaultAsync(x => x.IdentityId == identityId);

            if (foster == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Foster with identity {identityId} does not have a registered profile");
            }

            var query = from animal in dbContext.Animals
                        where animal.CrtFosterEmail == foster.Email
                        select new ViewFosterAnimalsDto(animal);

            var result = await query
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return result;
        }   
    }
}
