using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Create;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.List;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class VehicleController(ICreateVehicleUseCase createVehicleUseCase, IListVehiclesUseCase listVehiclesUseCase,
        IRentVehicleUserCase rentVehicleUseCase, IReturnVehicleUserCase renturnVehicleUseCase) : ControllerBase
    {
        private readonly ICreateVehicleUseCase _createVehicleUseCase = createVehicleUseCase;
        private readonly IListVehiclesUseCase _listVehiclesUseCase = listVehiclesUseCase;
        private readonly IRentVehicleUserCase _rentVehicleUseCase = rentVehicleUseCase;
        private readonly IReturnVehicleUserCase _renturnVehicleUseCase = renturnVehicleUseCase;

        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicleList = await _listVehiclesUseCase.Execute();
            return Ok(vehicleList);
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateVehicle(CreateVehicleInput input)
        {
            var newVehicle = await _createVehicleUseCase.Execute(input);
            return Ok(newVehicle);
        }

        [HttpPost("rent")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> RentVehicle(RentVehicleInput input)
        {
            var rentedVehicle = await _rentVehicleUseCase.Execute(input);
            return Ok(rentedVehicle);
        }

        [HttpPost("return")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> ReturnVehicle(ReturnVehicleInput input)
        {
            var renturnedVehicle = await _renturnVehicleUseCase.Execute(input);
            return Ok(renturnedVehicle);
        }
    }
}
