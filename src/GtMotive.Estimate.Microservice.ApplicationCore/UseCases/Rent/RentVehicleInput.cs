namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent
{
    /// <summary>
    /// DTO for input when renting Vehicles.
    /// </summary>
    public class RentVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the VIN of the Vehicle.
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Gets or sets Id of the customer who has rented the vehicle.
        /// </summary>
        public string RentedById { get; set; }
    }
}
