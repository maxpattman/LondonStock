
using LondonStock.Application.Contracts.Persistence;
using LondonStock.Persistance;
using LondonStock.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LondonStock.Api.Configuration
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            var connectionSting = configuration.GetConnectionString("Database");
            services.AddDbContext<LondonStockDBContext>(options =>
            {
                options.UseNpgsql(connectionSting,b => b.MigrationsAssembly("LondonStock.Persistance"));
               





            });
            
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IStockTypeRepository, StockTypeRepository>();
            services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();

          

        }
    }
}
