using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Create
{
    /// <summary>
    /// DTO for input when creating Vehicles.
    /// </summary>
    public class CreateVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the VIN of the Vehicle.
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Gets or sets the Plate of the Vehicle.
        /// </summary>
        public string Plate { get; set; }

        /// <summary>
        /// Gets or sets the Brand of the Vehicle.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the Model of the Vehicle.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the ManufactureDate of the Vehicle.
        /// </summary>
        public DateTime ManufactureDate { get; set; }
    }
}
