using Petaway.Core.Domain.Rescuer;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.Rescuers.GetRescuerExternal
{
    public class GetRescuerExternalCommandHandler : IGetRescuerExternalCommandHandler
    {
        private readonly PetawayContext dbContext;

        public GetRescuerExternalCommandHandler(PetawayContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GetRescuerExternalDto> HandleAsync(string rescuerEmail, CancellationToken cancellationToken)
        {
            var Rescuer = await dbContext.Rescuers
               .Where(x => x.Email == rescuerEmail)
               .Select(x => new GetRescuerExternalDto(x.Email, x.Name, x.PhoneNumber, x.Address, x.PhotoPath))
               .FirstOrDefaultAsync(cancellationToken);

            if (Rescuer == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Rescuer with email {rescuerEmail} does not have a registered profile");
            }

            return Rescuer;
        }
    }
    
}
