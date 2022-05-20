using Petaway.Core.DataModel;
using Petaway.Core.SeedWork;

namespace Petaway.Core.Domain.Rescuer
{
    public interface IRescuersRepository : IRepositoryOfAggregate<Rescuers, RegisterRescuerProfileCommand>
    {
    }
}
