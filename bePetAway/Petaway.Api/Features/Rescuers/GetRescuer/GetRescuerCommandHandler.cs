using Petaway.Core.Domain.Rescuer;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.Rescuers.GetRescuer
{
    public class GetRescuerCommandHandler : IGetRescuerCommandHandler
    {
        private readonly PetawayContext dbContext;

        public GetRescuerCommandHandler(PetawayContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GetRescuerDto> HandleAsync(string identityId, CancellationToken cancellationToken)
        {
            var Rescuer = await dbContext.Rescuers
               .Where(x => x.IdentityId == identityId)
               .Select(x => new GetRescuerDto(x.Email, x.Name, x.PhoneNumber, x.Address, x.PhotoPath))
               .FirstOrDefaultAsync(cancellationToken);

            if (Rescuer == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Rescuer with identity {identityId} does not have a registered profile");
            }

            return Rescuer;
        }
    }
    
}
