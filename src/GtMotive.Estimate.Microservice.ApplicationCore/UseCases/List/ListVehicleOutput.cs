using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.List
{
    /// <summary>
    /// DTO for output for a list of vehicles.
    /// </summary>
    public class ListVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListVehicleOutput"/> class.
        /// </summary>
        public ListVehicleOutput()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListVehicleOutput"/> class with a list of vehicles.
        /// </summary>
        /// <param name="vehicles">The list of vehicles.</param>
        public ListVehicleOutput(IList<Vehicle> vehicles)
        {
            VehiclesList = vehicles;
        }

        /// <summary>
        /// Gets the list of vehicles.
        /// </summary>
        public IList<Vehicle> VehiclesList { get; private set; } = [];

        /// <summary>
        /// Adds multiple vehicles to the list.
        /// </summary>
        /// <param name="vehicles">The vehicles to add.</param>
        public void AddVehicles(IEnumerable<Vehicle> vehicles)
        {
            if (vehicles == null)
            {
                return;
            }

            foreach (var vehicle in vehicles)
            {
                VehiclesList.Add(vehicle);
            }
        }
    }
}
