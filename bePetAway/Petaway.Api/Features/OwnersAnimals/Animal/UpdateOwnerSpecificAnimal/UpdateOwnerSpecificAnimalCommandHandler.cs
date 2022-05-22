using Petaway.Core.Domain.Owner;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.OwnersAnimals.Animal.UpdateOwnerSpecificAnimal
{
    public class UpdateOwnerSpecificAnimalCommandHandler : IUpdateOwnerSpecificAnimalCommandHandler
    {
        private readonly IOwnersAnimalsRepository OwnersAnimalsRepository;

        public UpdateOwnerSpecificAnimalCommandHandler(IOwnersAnimalsRepository OwnersAnimalsRepository)
        {
            this.OwnersAnimalsRepository = OwnersAnimalsRepository;
        }

        public async Task<IEnumerable<UpdateOwnerSpecificAnimalDto>> HandleAsync(UpdateOwnerSpecificAnimalDto command, string identityId, CancellationToken cancellationToken)
        {
            var ownerDomain = await OwnersAnimalsRepository.GetByIdentityIdAsync(identityId, cancellationToken) as OwnersAnimalsDomain;

            if (ownerDomain == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Owner with identity {identityId} does not have a registered profile");
            }

            ownerDomain.UpdateAnimalInfo(command.Id, command.Name, command.Type, command.Age, command.Description, command.AnimalPhotoPath);

            await OwnersAnimalsRepository.SaveAsync(cancellationToken);
        }
        
    }

}
