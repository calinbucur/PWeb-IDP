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
        private readonly IFostersRepository FostersAnimalsRepository;
        private readonly IMediator mediator;


        public UpdateFosterCommandHandler(IFostersRepository FostersAnimalsRepository, IMediator mediator)
        {
            this.FostersAnimalsRepository = FostersAnimalsRepository;
            this.mediator = mediator;
        }

        public async Task HandleAsync(UpdateFosterDto command, string identityId, CancellationToken cancellationToken)
        {
            var Foster = await FostersAnimalsRepository.GetByIdentityIdAsync(identityId, cancellationToken) as FostersDomain;

            if (Foster == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Foster with identity {identityId} does not have a registered profile");
            }

            Foster.UpdateFosterProfile(command.Name, command.PhoneNumber, command.Address, command.PhotoPath, command.MaxCapacity);

            await FostersAnimalsRepository.SaveAsync(cancellationToken);
        }
    }
    
}
