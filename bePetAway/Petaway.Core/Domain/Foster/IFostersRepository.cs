using Petaway.Core.DataModel;
using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Foster
{
    public interface IFostersRepository : IRepositoryOfAggregate<Fosters, RegisterFosterProfileCommand>
    {
        Task<DomainOfAggregate<Fosters>?> GetByEmailAsync(string aggregateEmail, CancellationToken cancellationToken);

        Task<DomainOfAggregate<Fosters>?> GetByIdentityIdAsync(string identityId, CancellationToken cancellationToken);
    }
}
