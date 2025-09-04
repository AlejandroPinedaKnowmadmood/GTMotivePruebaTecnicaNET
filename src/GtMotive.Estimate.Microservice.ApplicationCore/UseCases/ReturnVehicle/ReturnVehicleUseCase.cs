using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Use case for returning a vehicle.
    /// </summary>
    public class ReturnVehicleUseCase(IVehicleRepository vehicleRepository) : IReturnVehicleUserCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">The input data required for returning a vehicle.</param>
        /// <returns> Returns a dto with the information of the vehicle returned. </returns>
        public async Task<ReturnVehicleOutput> Execute(ReturnVehicleInput input)
        {
            if (input == null || string.IsNullOrWhiteSpace(input.VIN))
            {
                throw new ArgumentException("Input, VIN cannot be null or empty.");
            }

            var vehicle = await _vehicleRepository.GetByVin(input.VIN) ?? throw new InvalidOperationException($"Vehicle with VIN {input.VIN} not found.");

            if (string.IsNullOrWhiteSpace(vehicle.RentedById))
            {
                throw new InvalidOperationException($"Vehicle with VIN {input.VIN} is not currently rented.");
            }

            vehicle.RentedById = string.Empty;
            await _vehicleRepository.UpdateAsync(vehicle);
            return new ReturnVehicleOutput
            {
                VIN = vehicle.VIN,
            };
        }
    }
}
