using Petaway.Core.Domain.Rescuer;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.Rescuers.UpdateRescuer
{
    public class UpdateRescuerCommandHandler : IUpdateRescuerCommandHandler
    {
        private readonly IRescuersRepository RescuersRepository;
        private readonly IMediator mediator;


        public UpdateRescuerCommandHandler(IRescuersRepository RescuersRepository, IMediator mediator)
        {
            this.RescuersRepository = RescuersRepository;
            this.mediator = mediator;
        }

        public async Task HandleAsync(UpdateRescuerDto command, string identityId, CancellationToken cancellationToken)
        {
            var Rescuer = await RescuersRepository.GetByIdentityIdAsync(identityId, cancellationToken) as RescuersDomain;

            if (Rescuer == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Rescuer with identity {identityId} does not have a registered profile");
            }

            Rescuer.UpdateRescuerProfile(command.Name, command.PhoneNumber, command.Address, command.PhotoPath);

            await RescuersRepository.SaveAsync(cancellationToken);
        }
    }
    
}
