using Petaway.Core.DataModel;
using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Foster
{
    public interface IFostersRepository : IRepositoryOfAggregate<Fosters, RegisterFosterProfileCommand>
    {
    }
}
