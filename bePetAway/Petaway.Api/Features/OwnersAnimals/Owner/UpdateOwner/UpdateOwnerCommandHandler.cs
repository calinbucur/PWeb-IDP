using Petaway.Core.Domain.Owner;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.OwnersAnimals.Owner.UpdateOwner
{
    public class UpdateOwnerCommandHandler : IUpdateOwnerCommandHandler
    {
        private readonly IOwnersAnimalsRepository OwnersAnimalsRepository;


        public UpdateOwnerCommandHandler(IOwnersAnimalsRepository OwnersAnimalsRepository, IMediator mediator)
        {
            this.OwnersAnimalsRepository = OwnersAnimalsRepository;
        }

        public async Task HandleAsync(UpdateOwnerDto command, string identityId, CancellationToken cancellationToken)
        {
            var owner = await OwnersAnimalsRepository.GetByIdentityIdAsync(identityId, cancellationToken) as OwnersAnimalsDomain;

            if (owner == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Owner with identity {identityId} does not have a registered profile");
            }

            owner.UpdateOwnerProfile(command.Name, command.PhoneNumber, command.Address, command.PhotoPath);

            await OwnersAnimalsRepository.SaveAsync(cancellationToken);
        }
    }
    
}
