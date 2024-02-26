using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace LondonStock.Application
{
    public static class InfrastructureServiceConfiguration
    {
        public static IServiceCollection AddInfrastructureServiceConfiguration(this IServiceCollection services, IConfiguration configuration) 
        {

            return services;
        
        }
    }
}
