using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface for the handler of an use case.
    /// </summary>
    /// <typeparam name="TUseCaseInput">Type of the input message.</typeparam>
    /// <typeparam name="TUseCaseOutput">Type of the output message.</typeparam>
    ///
    public interface IUseCase<in TUseCaseInput, TUseCaseOutput>
        where TUseCaseInput : IUseCaseInput
    {
        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        Task<TUseCaseOutput> Execute(TUseCaseInput input);
    }
}
