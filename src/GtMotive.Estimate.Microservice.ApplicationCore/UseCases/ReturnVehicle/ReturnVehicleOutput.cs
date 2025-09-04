namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// DTO for output when returning a Vehicle.
    /// </summary>
    public class ReturnVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets Vehicle´s VIN.
        /// </summary>
        public string VIN { get; set; }
    }
}
