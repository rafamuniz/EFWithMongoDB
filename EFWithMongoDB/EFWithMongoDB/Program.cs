using EFWithMongoDB.Models;
using EFWithMongoDB.Persisntence;
using EFWithMongoDB.Persisntence.Repositories;
using EFWithMongoDB.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace EFWithMongoDB
{
    /// <summary>
    ///     https://keestalkstech.com/2018/04/dependency-injection-with-ioptions-in-console-apps-in-net-core-2/
    /// </summary>
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            // create service provider
            var serviceProvider = services.BuildServiceProvider();

            // entry to run app
            await serviceProvider.GetService<App>().Run(args, serviceProvider);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // configure logging
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            // build config
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            // add options (settings)
            services.Configure<AppSettings>(configuration.GetSection("App"));
            services.Configure<DatabaseSettings>(configuration.GetSection(DatabaseSettings.Section));

            // add services:
            services.AddTransient<BarbershopContext>();

            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
                        
            // add app
            services.AddTransient<App>();
        }
    }
}
