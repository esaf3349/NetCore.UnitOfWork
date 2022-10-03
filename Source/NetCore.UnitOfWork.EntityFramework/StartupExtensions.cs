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
    }
}