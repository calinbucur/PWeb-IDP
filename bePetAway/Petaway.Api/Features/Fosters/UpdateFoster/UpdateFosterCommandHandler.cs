using Petaway.Core.Domain.Foster;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.Fosters.UpdateFoster
{
    public class UpdateFosterCommandHandler : IUpdateFosterCommandHandler
    {
        private readonly IFostersRepository FostersRepository;
        private readonly IMediator mediator;


        public UpdateFosterCommandHandler(IFostersRepository FostersRepository, IMediator mediator)
        {
            this.FostersRepository = FostersRepository;
            this.mediator = mediator;
        }

        public async Task HandleAsync(UpdateFosterDto command, string identityId, CancellationToken cancellationToken)
        {
            var foster = await FostersRepository.GetByIdentityIdAsync(identityId, cancellationToken) as FostersDomain;

            if (foster == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Foster with identity {identityId} does not have a registered profile");
            }

            foster.UpdateFosterProfile(command.Name, command.PhoneNumber, command.Address, command.PhotoPath, command.MaxCapacity);

            await FostersRepository.SaveAsync(cancellationToken);
        }
    }
    
}
