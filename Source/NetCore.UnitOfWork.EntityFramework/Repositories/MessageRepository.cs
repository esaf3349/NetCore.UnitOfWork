using Microsoft.Extensions.Logging;
using NetCore.UnitOfWork.Core.Entities;
using NetCore.UnitOfWork.EntityFramework.Repositories.Common;
using NetCore.UnitOfWork.Interfaces.Repositories;

namespace NetCore.UnitOfWork.EntityFramework.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(AppDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {

        }
    }
}
