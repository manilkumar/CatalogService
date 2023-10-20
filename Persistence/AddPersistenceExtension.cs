using Application.RepositoryInterfaces;
using Persistence.Context;
using Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class AddPersistenceExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Name=SqlServerDB"));
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            return services;
        }
    }
}
