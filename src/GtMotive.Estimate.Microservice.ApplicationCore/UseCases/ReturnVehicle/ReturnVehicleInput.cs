namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// DTO for input when returning a Vehicle.
    /// </summary>
    public class ReturnVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the VIN of the Vehicle.
        /// </summary>
        public string VIN { get; set; }
    }
}
