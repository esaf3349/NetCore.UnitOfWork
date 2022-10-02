using System.Threading.Tasks;

namespace NetCore.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
        void Dispose();
    }
}
