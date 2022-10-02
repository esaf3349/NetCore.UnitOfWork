using NetCore.UnitOfWork.Core.Entities;
using NetCore.UnitOfWork.Interfaces.Repositories.Common;

namespace NetCore.UnitOfWork.Interfaces.Repositories
{
    public interface IPersonRepository : IGenericRepository<Person>
    {

    }
}
