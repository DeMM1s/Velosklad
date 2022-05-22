using Velosklad.Infrastructure;
using Velosklad.DB;
using Velosklad.DB.Repository;
using Velosklad.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Velosklad.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(Constants.ConnectionName);

            services.AddDbContextFactory<OrderDbContext>(dbContextOptionsBuilder => dbContextOptionsBuilder.UseNpgsql(connectionString));
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
