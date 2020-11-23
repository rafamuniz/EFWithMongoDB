using EFWithMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFWithMongoDB.Persisntence.Repositories
{
    public interface IServiceRepository
    {
        /// <summary>
        ///     Create Service
        /// </summary>
        /// <param name="service"></param>
        Service Create(Service service);

        /// <summary>
        ///     Create Service
        /// </summary>
        /// <param name="service"></param>
        Task<Service> CreateAsync(Service service);

        /// <summary>
        ///     Update Service
        /// </summary>
        /// <param name="service"></param>
        Service Update(Service service);

        /// <summary>
        ///     Update Service
        /// </summary>
        /// <param name="service"></param>
        Task<Service> UpdateAsync(Service service);

        /// <summary>
        ///     Delete Service
        /// </summary>
        /// <param name="service"></param>
        Service Delete(Service service);

        /// <summary>
        ///     Delete Service
        /// </summary>
        /// <param name="service"></param>
        Task<Service> DeleteAsync(Service service);

        /// <summary>
        ///     Get Service By Id
        /// </summary>        
        Service GetById(Guid id);

        /// <summary>
        ///     Get Service By Id
        /// </summary>        
        Task<Service> GetByIdAsync(Guid id);

        /// <summary>
        ///     Get Services
        /// </summary>        
        List<Service> Gets();

        /// <summary>
        ///     Get Services
        /// </summary>        
        Task<List<Service>> GetsAsync();
    }
}
