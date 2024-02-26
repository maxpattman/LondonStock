using LondonStock.Api.Configuration;
using LondonStock.Api.Extensions;
using LondonStock.Application;
using LondonStock.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata;


namespace LondonStock.Api 
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) 
        {

            services.InstallServices(_configuration, typeof(IServiceInstaller).Assembly);

            services.AddHttpContextAccessor();
            services.AddOpenApiDocument();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers()
                    .AddNewtonsoftJson();
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger) 
        {
            if (env == null) 
            {
                throw new ArgumentNullException(nameof(env));
            }

            logger.LogInformation($"Using application in {env.EnvironmentName} mode !");
            // "/swagger/docs/{documentName}/swagger.json"
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("./v1/swagger.json", "My API V1");
            });
            app.ApplyMigrations();
            app.UseDeveloperExceptionPage();
            
            //app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.UseRouting();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "[controller]");
            });
            
        }
    }
}