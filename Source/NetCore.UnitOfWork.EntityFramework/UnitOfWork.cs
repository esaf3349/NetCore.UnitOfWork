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

        public IChatRepository Chats { get; private set; }
        public IMessageRepository Messages { get; private set; }
        public IPersonRepository Persons { get; private set; }

        public UnitOfWork(AppDbContext dbContext)
        {
            DbContext = dbContext;

            Chats = new ChatRepository(dbContext);
            Messages = new MessageRepository(dbContext);
            Persons = new PersonRepository(dbContext);
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
