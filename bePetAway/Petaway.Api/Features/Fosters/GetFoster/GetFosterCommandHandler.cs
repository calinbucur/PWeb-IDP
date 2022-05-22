using Petaway.Core.Domain.Foster;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.Fosters.GetFoster
{
    public class GetFosterCommandHandler : IGetFosterCommandHandler
    {
        private readonly PetawayContext dbContext;

        public GetFosterCommandHandler(PetawayContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GetFosterDto> HandleAsync(string identityId, CancellationToken cancellationToken)
        {
            var Foster = await dbContext.Fosters
               .Where(x => x.IdentityId == identityId)
               .Select(x => new GetFosterDto(x.Email, x.Name, x.PhoneNumber, x.Address, x.PhotoPath, x.CrtCapacity, x.MaxCapacity))
               .FirstOrDefaultAsync(cancellationToken);

            if (Foster == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Foster with identity {identityId} does not have a registered profile");
            }

            return Foster;
        }
    }
    
}
