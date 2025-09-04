using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Create
{
    /// <summary>
    /// Use case to create a vehicle in the system.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
    /// </remarks>
    /// <param name="vehicleRepository">alfa. </param>
    public class CreateVehicleUseCase(IVehicleRepository vehicleRepository) : ICreateVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        /// <summary>
        /// Executes the use case to create a new vehicle.
        /// </summary>
        /// <param name="input">The input data required to create the vehicle.</param>
        /// <returns>The result of the vehicle creation.</returns>
        public async Task<CreateVehicleOutput> Execute(CreateVehicleInput input)
        {
            var vehicle = new Vehicle(
                 Guid.NewGuid(),
                 input?.VIN,
                 input?.Plate,
                 input.Brand,
                 input.Model,
                 input.ManufactureDate,
                 string.Empty);

            await _vehicleRepository.AddAsync(vehicle);

            return new CreateVehicleOutput { VehicleId = vehicle.Id, VIN = vehicle.VIN };
        }
    }
}
