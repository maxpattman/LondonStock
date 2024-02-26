using LondonStock.Persistance;
using Microsoft.EntityFrameworkCore;

namespace LondonStock.Api.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {


            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using LondonStockDBContext dbContext =
                scope.ServiceProvider.GetRequiredService<LondonStockDBContext>();
                dbContext.Database.Migrate();
                dbContext.SaveChanges();
        }
       
    }
}
