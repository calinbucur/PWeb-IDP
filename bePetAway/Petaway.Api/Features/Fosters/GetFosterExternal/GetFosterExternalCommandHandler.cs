using Petaway.Core.Domain.Foster;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.Fosters.GetFosterExternal
{
    public class GetFosterExternalCommandHandler : IGetFosterExternalCommandHandler
    {
        private readonly PetawayContext dbContext;

        public GetFosterExternalCommandHandler(PetawayContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GetFosterExternalDto> HandleAsync(string fosterEmail, CancellationToken cancellationToken)
        {
            var foster = await dbContext.Fosters
               .Where(x => x.Email == fosterEmail)
               .Select(x => new GetFosterExternalDto(x.Email, x.Name, x.PhoneNumber, x.Address, x.PhotoPath, x.CrtCapacity, x.MaxCapacity))
               .FirstOrDefaultAsync(cancellationToken);

            if (foster == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Foster with email {fosterEmail} does not have a registered profile");
            }

            return foster;
        }
    }
    
}
