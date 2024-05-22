using ECommerceBookStore.Domain.Interface;
using ECommerceBookStore.Infrastructure.Data;
using ECommerceBookStore.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceBookStore.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ECommerceConneciton") ??
                throw new InvalidOperationException("Connection string 'ECommerceConneciton' not found ")));

            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<IGetAuthorQuery, GetAuthorQuery>();
            services.AddTransient<IGetBookQuery, GetBookQuery>();
            services.AddTransient<IGetOrderQuery, GetOrderQuery>();
            services.AddTransient<IGetPublisherQuery, GetPublisherQuery>();
            services.AddTransient<IGetUserQuery, GetUserQuery>();
            return services;
        }
    }
}
