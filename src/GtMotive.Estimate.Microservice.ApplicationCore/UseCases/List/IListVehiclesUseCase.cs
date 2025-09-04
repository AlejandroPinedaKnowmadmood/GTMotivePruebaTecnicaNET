using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.List
{
    /// <summary>
    /// Gets a list of vehicles.
    /// </summary>
    public interface IListVehiclesUseCase : IOutputPortStandard<ListVehicleOutput>
    {
        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <returns>Task.</returns>
        Task<ListVehicleOutput> Execute();
    }
}
