using Petaway.Core.DataModel;
using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Owner
{
    public interface IOwnersAnimalsRepository : IRepositoryOfAggregate<Owners, RegisterOwnerProfileCommand>
    {
        Task<DomainOfAggregate<Owners>?> GetByEmailAsync(string aggregateEmail, CancellationToken cancellationToken);

        Task<DomainOfAggregate<Owners>?> GetByIdentityIdAsync(string identityId, CancellationToken cancellationToken);

    }
}
