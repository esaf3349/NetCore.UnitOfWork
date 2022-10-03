using NetCore.UnitOfWork.Core.Entities;
using NetCore.UnitOfWork.EntityFramework.Repositories.Common;
using NetCore.UnitOfWork.Interfaces.Repositories;

namespace NetCore.UnitOfWork.EntityFramework.Repositories
{
    public class ChatRepository : GenericRepository<Chat>, IChatRepository
    {
        public ChatRepository(AppDbContext context) : base(context) 
        {

        }
    }
}
