using Petaway.Core.Domain.Owner;
using Petaway.Infrastructure.Data;
using Petaway.Api.Web;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Petaway.Api.Features.OwnersAnimals.Animal.GetOwnerSpecificAnimal
{
    public class GetOwnerSpecificAnimalCommandHandler : IGetOwnerSpecificAnimalCommandHandler
    {
        private readonly PetawayContext dbContext;

        public GetOwnerSpecificAnimalCommandHandler(PetawayContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GetOwnerSpecificAnimalDto>> HandleAsync(GetOwnerSpecificAnimalCommandRequirements command, CancellationToken cancellationToken)
        {
            var owner = await dbContext.Owners.FirstOrDefaultAsync(x => x.Email == command.OwnerEmail);

            if (owner == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, $"Owner with email {command.OwnerEmail} does not have a registered profile");
            }

            var query = from animal in dbContext.Animals
                        where ((animal.OwnerEmail == owner.Email) && (animal.Name == command.AnimalName) && (animal.Type == command.AnimalType) && (animal.Age == command.AnimalAge))
                        select new GetOwnerSpecificAnimalDto(animal);

            var result = await query
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return result;
        }
        
    }

}
