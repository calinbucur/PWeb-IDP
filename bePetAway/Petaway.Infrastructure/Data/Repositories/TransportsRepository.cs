using Petaway.Core.DataModel;
using Petaway.Core.Domain.Transport;
using Petaway.Core.SeedWork;
using Microsoft.EntityFrameworkCore;

//Posibil TODO, entitatea Transport nu imi e inca clar definita, ar trebui luat asincron de fiecare din cei 3 participanti in parte
namespace Petaway.Infrastructure.Data.Repositories
{
    public class TransportsRepository : ITransportsRepository
    {
        private readonly PetawayContext context;

        public TransportsRepository(PetawayContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(RegisterTransportProfileCommand command, CancellationToken cancellationToken)
        {
            var transport_entity = new Transports(command.OwnerEmail, command.AnimalId, command.FosterEmail, command.RescuerEmail, command.StartingPoint, command.EndPoint);

            await context.Transports.AddAsync(transport_entity);
            await SaveAsync(cancellationToken);
        }

        public async Task<DomainOfAggregate<Transports>?> GetAsync(int aggregateId, CancellationToken cancellationToken)
        {
            var transport_entity = await context.Transports
                .FirstOrDefaultAsync(x => x.Id == aggregateId, cancellationToken);

            if (transport_entity == null)
            {
                return null;
            }

            return new TransportsDomain(transport_entity);
        }

        public async Task DeleteAsync(int aggregateId, CancellationToken cancellationToken)
        {
            var transport_entity = await context.Transports
                .FirstOrDefaultAsync(x => x.Id == aggregateId, cancellationToken);

            if (transport_entity != null)
            {
                context.Transports.Remove(transport_entity);
            }
        }

        public Task SaveAsync(CancellationToken cancellationToken)
        {
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
