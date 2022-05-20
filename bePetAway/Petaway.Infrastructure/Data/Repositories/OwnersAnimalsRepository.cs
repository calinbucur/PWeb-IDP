using Petaway.Core.DataModel;
using Petaway.Core.Domain.Owner;
using Petaway.Core.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Petaway.Infrastructure.Data.Repositories
{
    public class OwnersAnimalsRepository : IOwnersAnimalsRepository
    {
        private readonly PetawayContext context;

        public OwnersAnimalsRepository(PetawayContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(RegisterOwnerProfileCommand command, CancellationToken cancellationToken)
        {
            var user = new Owners(command.Email, command.Name, command.PhoneNumber, command.Address, command.PhotoPath);

            await context.Owners.AddAsync(user);
            await SaveAsync(cancellationToken);
        }

        public async Task<DomainOfAggregate<Owners>?> GetAsync(int aggregateId, CancellationToken cancellationToken)
        {
            var owner_entity = await context.Owners
                .Include(x => x.Animals)
                .FirstOrDefaultAsync(x => x.Id == aggregateId, cancellationToken);

            if (owner_entity == null)
            {
                return null;
            }

            return new OwnersAnimalsDomain(owner_entity);
        }

        public async Task<DomainOfAggregate<Owners>?> GetByEmailAsync(string aggregateEmail, CancellationToken cancellationToken)
        {
            var owner_entity = await context.Owners
                .Include(x => x.Animals)
                .FirstOrDefaultAsync(x => x.Email == aggregateEmail, cancellationToken);

            if (owner_entity == null)
            {
                return null;
            }

            return new OwnersAnimalsDomain(owner_entity);
        }



        public async Task DeleteAsync(int aggregateId, CancellationToken cancellationToken)
        {
            var owner_entity = await context.Owners
                .Include(x => x.Animals)
                .FirstOrDefaultAsync(x => x.Id == aggregateId, cancellationToken);

            if (owner_entity != null)
            {
                context.Owners.Remove(owner_entity);

                foreach (Animals? owned_animal_entity in owner_entity.Animals)
                {
                    if (owned_animal_entity != null)
                    {
                        context.Animals.Remove(owned_animal_entity);
                    } else
                    {
                        throw new NullAnimalException();
                    }
                }

            }
        }

        public Task SaveAsync(CancellationToken cancellationToken)
        {
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
