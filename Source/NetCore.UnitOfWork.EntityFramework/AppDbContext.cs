using Microsoft.EntityFrameworkCore;
using NetCore.UnitOfWork.Core.Entities;
using NetCore.UnitOfWork.EntityFramework.EntityConfigs;

namespace NetCore.UnitOfWork.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ChatEntityConfig());
            builder.ApplyConfiguration(new MessageEntityConfig());
            builder.ApplyConfiguration(new PersonEntityConfig());

            base.OnModelCreating(builder);
        }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
