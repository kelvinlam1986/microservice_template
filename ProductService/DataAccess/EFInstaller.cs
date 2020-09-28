using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.DataAccess.EF;
using ProductService.Domain;

namespace ProductService.DataAccess
{
    public static class EFInstaller
    {
        public static IServiceCollection AddEFConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var useInMemoryData = configuration.GetSection("Settings").GetValue<bool>("UseInMemoryDatabase");
            services.AddDbContext<ProductDbContext>(options =>
            {
                if (useInMemoryData)
                {
                    options.UseInMemoryDatabase("Products");
                }
                else
                {
                    options.UseSqlServer(configuration.GetConnectionString("Products"));
                }
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
