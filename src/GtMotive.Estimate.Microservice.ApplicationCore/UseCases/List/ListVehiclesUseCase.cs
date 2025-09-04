using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.List
{
    /// <summary>
    /// Gets a list of vehicles.
    /// </summary>
    public class ListVehiclesUseCase(IVehicleRepository vehicleRepository) : IListVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        /// <summary>
        /// Gets a list of vehicles.
        /// </summary>
        /// <returns>A list of vehicles.</returns>
        public async Task<ListVehicleOutput> Execute()
        {
            var response = await _vehicleRepository.GetAllAsync();
            var output = new ListVehicleOutput();
            output.AddVehicles(response);
            return output;
        }

        /// <summary>
        /// Gets a list of vehicles.
        /// </summary>
        /// /// <param name="response">A list of vehicles.</param>
        public void StandardHandle(ListVehicleOutput response)
        {
            throw new NotImplementedException();
        }
    }
}
