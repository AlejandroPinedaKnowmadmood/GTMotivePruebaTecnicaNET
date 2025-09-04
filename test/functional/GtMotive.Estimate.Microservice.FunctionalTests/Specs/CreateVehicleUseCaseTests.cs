using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Create;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    public class CreateVehicleUseCaseTests(CompositionRootTestFixture fixture) : FunctionalTestBase(fixture)
    {
        private readonly ICreateVehicleUseCase _createVehicleUseCase = fixture.ServiceProvider.GetRequiredService<ICreateVehicleUseCase>();

        [Fact]
        public async Task CreateVehicleShouldReturnSuccess()
        {
            var input = new CreateVehicleInput
            {
                VIN = "1HGCM82677A123456",
                Plate = "LFR8723",
                Brand = "Honda",
                Model = "Civic",
                ManufactureDate = DateTime.UtcNow.AddYears(-4)
            };

            var result = await _createVehicleUseCase.Execute(input);

            Assert.NotNull(result.VIN);
        }
    }
}
