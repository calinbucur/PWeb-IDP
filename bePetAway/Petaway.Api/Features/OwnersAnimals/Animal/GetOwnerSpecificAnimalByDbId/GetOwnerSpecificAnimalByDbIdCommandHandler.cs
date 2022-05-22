using Petaway.Core.Domain.Owner;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.OwnersAnimals.Animal.GetOwnerSpecificAnimalByDbId
{
    public class GetOwnerSpecificAnimalByDbIdCommandHandler : IGetOwnerSpecificAnimalByDbIdCommandHandler
    {
        private readonly PetawayContext dbContext;

        public GetOwnerSpecificAnimalByDbIdCommandHandler(PetawayContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GetOwnerSpecificAnimalByDbIdDto>> HandleAsync(GetOwnerSpecificAnimalByDbIdCommandRequirements command, CancellationToken cancellationToken)
        {
            var owner = await dbContext.Owners.FirstOrDefaultAsync(x => x.Email == command.OwnerEmail);

            if (owner == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Owner with email {command.OwnerEmail} does not have a registered profile");
            }

            var query = from animal in dbContext.Animals
                        where ((animal.OwnerEmail == owner.Email) && (animal.Id == command.AnimalId))
                        select new GetOwnerSpecificAnimalByDbIdDto(animal);

            var result = await query
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return result;
        }
        
    }

}
