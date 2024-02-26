
using Application.Profiles;
using LondonStock.Application.DTOs.StockType;
using LondonStock.Application.Features.StockRequests.Handlers.Queries;
using LondonStock.Application.Features.StockType.Queries.GetAllStockType;
using LondonStock.Application.Features.StockType.Queries.GetStockList;
using LondonStock.Application.Features.StockType.Queries.GetStockType;
using MediatR;
using MediatR.Registration;
using System.Net.NetworkInformation;
using System.Reflection;

namespace LondonStock.Api.Configuration
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options => options.Configuration = configuration.GetConnectionString("Cache"));
            
            services.AddAutoMapper(typeof(StockTypeProfile));

            services.AddMediatR(cfg => 
            {
                cfg.RegisterServicesFromAssemblies(
                    typeof(GetStockRequest).Assembly,
                    typeof(GetStockListRequest).Assembly,
                    typeof(GetAllStockRequest).Assembly
                );
            });
            // Register Handlers 
            services.AddScoped(typeof(IRequestHandler<GetStockRequest, StockTypeDto>), typeof(GetStockRequestHandler));
            services.AddScoped(typeof(IRequestHandler<GetStockListRequest, List<StockTypeDto>>), typeof(GetStockListRequestHandler));
            services.AddScoped(typeof(IRequestHandler<GetAllStockRequest, List<StockTypeDto>>), typeof(GetAllStockRequestHandler));

        }

      
    }
}
