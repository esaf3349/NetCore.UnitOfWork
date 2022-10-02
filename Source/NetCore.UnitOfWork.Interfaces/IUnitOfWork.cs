using NetCore.UnitOfWork.Interfaces.Repositories;
using System.Threading.Tasks;

namespace NetCore.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IChatRepository Chats { get; }
        IMessageRepository Messages { get; }
        IPersonRepository Persons { get; }

        Task Commit();
        void Dispose();
    }
}
