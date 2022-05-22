using Petaway.Core.Domain.Owner;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.OwnersAnimals.Owner.GetOwnerExternal
{
    public class GetOwnerExternalCommandHandler : IGetOwnerExternalCommandHandler
    {
        private readonly PetawayContext dbContext;

        public GetOwnerExternalCommandHandler(PetawayContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GetOwnerExternalDto> HandleAsync(string ownerEmail, CancellationToken cancellationToken)
        {
            var owner = await dbContext.Owners
               .Where(x => x.Email == ownerEmail)
               .Select(x => new GetOwnerExternalDto(x.Email, x.Name, x.PhoneNumber, x.Address, x.PhotoPath, x.NumberOfAnimals))
               .FirstOrDefaultAsync(cancellationToken);

            if (owner == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Owner with email {ownerEmail} does not have a registered profile");
            }

            return owner;
        }
    }
    
}
