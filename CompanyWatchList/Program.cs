using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CompanyWatchList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfig)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void SetupConfig(HostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            builder.AddJsonFile("appconfig.json", false, true);
        }
    }
}
