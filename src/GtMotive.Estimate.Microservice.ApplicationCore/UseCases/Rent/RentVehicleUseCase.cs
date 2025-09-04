using System;
using System.Data;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent
{
    /// <summary>
    /// Use case to rent a vehicle in the system.
    /// </summary>
    public class RentVehicleUseCase(IVehicleRepository vehicleRepository) : IRentVehicleUserCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">The input data required for renting a vehicle.</param>
        /// <returns> Returns a dto with the information of the vehicle rented and by whom. </returns>
        public async Task<RentVehicleOutput> Execute(RentVehicleInput input)
        {
            if (input == null || string.IsNullOrWhiteSpace(input.VIN) || string.IsNullOrWhiteSpace(input.RentedById))
            {
                throw new ArgumentException("Input, VIN and RentedById cannot be null or empty.");
            }

            var vehicle = await _vehicleRepository.GetByVin(input.VIN) ?? throw new NoNullAllowedException($"Vehicle with VIN {input.VIN} not found.");

            var activeCustomer = await _vehicleRepository.GetByCustomer(input.RentedById);

            if (activeCustomer != null)
            {
                throw new InvalidOperationException($"Customer with Id {input.RentedById} already has a rented vehicle.");
            }

            vehicle.RentedById = input.RentedById;
            await _vehicleRepository.UpdateAsync(vehicle);
            return new RentVehicleOutput
            {
                VIN = vehicle.VIN,
                RentedById = vehicle.RentedById
            };
        }
    }
}
