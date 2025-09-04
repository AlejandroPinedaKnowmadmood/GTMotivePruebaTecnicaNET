using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Create
{
    /// <summary>
    /// DTO for output when creating Vehicles.
    /// </summary>
    public class CreateVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets VehicleId.
        /// </summary>
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the VIN of the Vehicle.
        /// </summary>
        public string VIN { get; set; }
    }
}
