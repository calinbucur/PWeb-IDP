using Petaway.Core.DataModel;
using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Owner
{
    public interface IOwnersAnimalsRepository : IRepositoryOfAggregate<Fosters, RegisterOwnerProfileCommand>
    {
    }
}
