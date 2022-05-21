using Petaway.Core.DataModel;
using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Rescuer
{
    public interface IRescuersRepository : IRepositoryOfAggregate<Rescuers, RegisterRescuerProfileCommand>
    {
        Task<DomainOfAggregate<Rescuers>?> GetByEmailAsync(string aggregateEmail, CancellationToken cancellationToken);

        Task<DomainOfAggregate<Rescuers>?> GetByIdentityIdAsync(string identityId, CancellationToken cancellationToken);

    }
}
