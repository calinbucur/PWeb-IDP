using Petaway.Core.DataModel;
using Petaway.Core.Domain.Rescuer;
using Petaway.Core.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Petaway.Infrastructure.Data.Repositories
{
    public class RescuersRepository : IRescuersRepository
    {
        private readonly PetawayContext context;

        public RescuersRepository(PetawayContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(RegisterRescuerProfileCommand command, CancellationToken cancellationToken)
        {
            var user = new Rescuers(command.IdentityId, command.Email, command.Name, command.PhoneNumber, command.Address, command.PhotoPath); //, command.MaxCapacity, command.AnimalType, command.IsAggresive, command.IsSick, command.IsStray);

            await context.Rescuers.AddAsync(user);
            await SaveAsync(cancellationToken);
        }

        public async Task<DomainOfAggregate<Rescuers>?> GetAsync(int aggregateId, CancellationToken cancellationToken)
        {
            var rescuer_entity = await context.Rescuers
                .FirstOrDefaultAsync(x => x.Id == aggregateId, cancellationToken);

            if (rescuer_entity == null)
            {
                return null;
            }

            return new RescuersDomain(rescuer_entity);
        }

        public async Task<DomainOfAggregate<Rescuers>?> GetByEmailAsync(string aggregateEmail, CancellationToken cancellationToken)
        {
            var rescuer_entity = await context.Rescuers
                .FirstOrDefaultAsync(x => x.Email == aggregateEmail, cancellationToken);

            if (rescuer_entity == null)
            {
                return null;
            }

            return new RescuersDomain(rescuer_entity);
        }

        public async Task<DomainOfAggregate<Rescuers>?> GetByIdentityIdAsync(string identityID, CancellationToken cancellationToken)
        {
            var rescuer_entity = await context.Rescuers
                .FirstOrDefaultAsync(x => x.IdentityId == identityID, cancellationToken);

            if (rescuer_entity == null)
            {
                return null;
            }

            return new RescuersDomain(rescuer_entity);
        }

        public async Task DeleteAsync(int aggregateId, CancellationToken cancellationToken)
        {
            var rescuer_entity = await context.Rescuers
                .FirstOrDefaultAsync(x => x.Id == aggregateId, cancellationToken);

            if (rescuer_entity != null)
            {
                context.Rescuers.Remove(rescuer_entity);
            }
        }

        public Task SaveAsync(CancellationToken cancellationToken)
        {
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
