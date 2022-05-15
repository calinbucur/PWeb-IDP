using Petaway.Core.DataModel;
using Petaway.Core.Domain.Foster;
using Petaway.Core.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Petaway.Infrastructure.Data.Repositories
{
    public class FostersRepository : IFostersRepository
    {
        private readonly PetawayContext context;

        public FostersRepository(PetawayContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(RegisterFosterProfileCommand command, CancellationToken cancellationToken)
        {
            var user = new Fosters(command.UserId, command.Email, command.Name, command.PhoneNumber, command.Address, command.Password, command.MaxCapacity);

            await context.Fosters.AddAsync(user);
            await SaveAsync(cancellationToken);
        }

        public async Task<DomainOfAggregate<Fosters>?> GetAsync(int aggregateId, CancellationToken cancellationToken)
        {
            var foster_entity = await context.Fosters
                .Include(x => x.Animals)
                .FirstOrDefaultAsync(x => x.Id == aggregateId, cancellationToken);

            if (foster_entity == null)
            {
                return null;
            }

            return new FostersDomain(foster_entity);
        }

        public async Task DeleteAsync(int aggregateId, CancellationToken cancellationToken)
        {
            var foster_entity = await context.Fosters
                .FirstOrDefaultAsync(x => x.Id == aggregateId, cancellationToken);

            if (foster_entity != null)
            {
                context.Fosters.Remove(foster_entity);
            }
        }

        public Task SaveAsync(CancellationToken cancellationToken)
        {
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
