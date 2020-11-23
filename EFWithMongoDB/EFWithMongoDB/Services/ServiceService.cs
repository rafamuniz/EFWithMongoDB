using EFWithMongoDB.Models;
using EFWithMongoDB.Persisntence;
using EFWithMongoDB.Persisntence.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using System;

namespace EFWithMongoDB.Services
{
    public class ServiceService : IServiceService
    {
        #region Fields
        private readonly DatabaseSettings _settings;
        private readonly IBarbershopContext _context;
        private readonly IServiceRepository _serviceRepository;
        #endregion Fields

        public ServiceService(String connectionString)
        {
            //_context = new BarbershopContext(connectionString);
        }

        public ServiceService(String connectionString, String database)
        {
            _context = new BarbershopContext(connectionString, database);
        }

        public ServiceService(IOptions<DatabaseSettings> settings)
        {
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));

            _context = new BarbershopContext(_settings);
            _serviceRepository = new ServiceRepository(_context);
        }

        public Service Create(Service service)
        {
            return _serviceRepository.Create(service);
        }
    }
}