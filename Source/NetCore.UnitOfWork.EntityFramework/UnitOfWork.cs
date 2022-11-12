using Microsoft.Extensions.Logging;
using NetCore.UnitOfWork.EntityFramework.Repositories;
using NetCore.UnitOfWork.Interfaces;
using NetCore.UnitOfWork.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace NetCore.UnitOfWork.EntityFramework
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext DbContext;
        private readonly ILogger Logger;

        public IChatRepository Chats { get; private set; }
        public IMessageRepository Messages { get; private set; }
        public IPersonRepository Persons { get; private set; }

        public UnitOfWork(AppDbContext dbContext, ILoggerFactory loggerFactory)
        {
            DbContext = dbContext;
            Logger = loggerFactory.CreateLogger<UnitOfWork>();

            Chats = new ChatRepository(dbContext, Logger);
            Messages = new MessageRepository(dbContext, Logger);
            Persons = new PersonRepository(dbContext, Logger);
        }

        public async Task Commit()
        {
            await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
