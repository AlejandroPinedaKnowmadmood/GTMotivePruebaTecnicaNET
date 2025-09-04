namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent
{
    /// <summary>
    /// DTO for output when creating Vehicles.
    /// </summary>
    public class RentVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets Vehicle´s VIN.
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who rented the Vehicle.
        /// </summary>
        public string RentedById { get; set; }
    }
}
