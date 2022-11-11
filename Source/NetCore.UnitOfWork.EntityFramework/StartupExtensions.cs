using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCore.UnitOfWork.Interfaces;

namespace NetCore.UnitOfWork.EntityFramework
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddAppDatabase(this IServiceCollection services, string dbConnection)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConnection));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static void ApplyAppDatabaseMigrations(this IServiceScope serviceScope)
        {
            using (var context = serviceScope.ServiceProvider.GetService<AppDbContext>())
            {
                context.Database.Migrate();
            }
        }
    }
}