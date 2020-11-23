using EFWithMongoDB.Models;
using EFWithMongoDB.Persisntence;
using EFWithMongoDB.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace EFWithMongoDB
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly AppSettings _appSettings;
        private readonly IOptions<DatabaseSettings> _databaseSettings;

        public App(
            ILogger<App> logger,
            IOptions<AppSettings> appSettings,
            IOptions<DatabaseSettings> databaseSettings)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
            _databaseSettings = databaseSettings ?? throw new ArgumentNullException(nameof(databaseSettings));
        }

        public async Task Run(string[] args, ServiceProvider serviceProvider)
        {
            _logger.LogInformation("Starting...");

            //Console.WriteLine("Hello world!");
            //Console.WriteLine(_appSettings.TempDirectory);

            //var context = new BarbershopContext(_databaseSettings.Value);

            //var serviceService = (IServiceService)serviceProvider.GetService(typeof(IServiceService));

            IServiceService serviceService = new ServiceService(_databaseSettings);

            var service = new Service()
            {
                Name = "Shave Beard 5"
            };
            serviceService.Create(service);

            _logger.LogInformation("Finished!");

            await Task.CompletedTask;
        }
    }
}