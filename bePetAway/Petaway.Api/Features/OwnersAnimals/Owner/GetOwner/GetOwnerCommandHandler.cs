using Petaway.Core.Domain.Owner;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.OwnersAnimals.Owner.GetOwner
{
    public class GetOwnerCommandHandler : IGetOwnerCommandHandler
    {
        private readonly PetawayContext dbContext;

        public GetOwnerCommandHandler(PetawayContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GetOwnerDto> HandleAsync(string identityId, CancellationToken cancellationToken)
        {
            var owner = await dbContext.Owners
               .Where(x => x.IdentityId == identityId)
               .Select(x => new GetOwnerDto(x.Email, x.Name, x.PhoneNumber, x.Address, x.PhotoPath, x.NumberOfAnimals))
               .FirstOrDefaultAsync(cancellationToken);

            if (owner == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Owner with identity {identityId} does not have a registered profile");
            }

            return owner;
        }
    }
    
}
