namespace LondonStock.Api 
{
    public static class Program
    {
        public static void Main(string[] args) 
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => 
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.ConfigureKestrel((context, options) =>
                {
                    context.Configuration.GetSection("Kestrel").Bind(options);
                });
            });
    }
}

