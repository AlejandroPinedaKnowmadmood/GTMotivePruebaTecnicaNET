using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Interface for VehicleRepository. Repostory patter implementation.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Sets a new Vehicle.
        /// </summary>
        /// <param name="vehicle"> Gets or sets the name of the customer4. </param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddAsync(Vehicle vehicle);

        /// <summary>
        /// Gets all the Vehicles.
        /// </summary>
        /// <returns> A list of vehicles <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<Vehicle>> GetAllAsync();

        /// <summary>doc
        /// Retrieves the vehicle associated with the specified customer ID.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer whose vehicle is to be retrieved. Cannot be null or empty.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="Vehicle"/>
        /// associated with the specified customer ID,  or <see langword="null"/> if no vehicle is found for the given
        /// customer.</returns>
        Task<Vehicle> GetByCustomer(string customerId);

        /// <summary>
        /// Gets a Vehicle by Vin.
        /// </summary>
        /// <param name="vin">Vehicle´s vin. </param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<Vehicle> GetByVin(string vin);

        /// <summary>
        /// Update a Vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle to be updated. </param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task UpdateAsync(Vehicle vehicle);
    }
}
