using LondonStock.Api.Controllers;
using System.Reflection;

namespace LondonStock.Api.Configuration
{
    public class ApiServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<LondonStockController>();
        }
    }
}
