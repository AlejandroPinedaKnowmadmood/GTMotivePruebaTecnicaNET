using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Create;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore.UseCases.Create
{
    /// <summary>
    /// Unit test class for create vehicle use case.
    /// </summary>
    public class CreateVehicleUseCaseTest
    {
        /// <summary>
        /// Unit test method for validate create vehicle use case.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        [Fact]
        public async Task ExecuteShouldCreateVehicleSuccessfully()
        {
            // Arrange
            var mockRepository = new Mock<IVehicleRepository>();
            var useCase = new CreateVehicleUseCase(mockRepository.Object);

            var input = new CreateVehicleInput
            {
                VIN = "1HGCM82633A123456",
                Plate = "ABC123",
                Brand = "Honda",
                Model = "Civic",
                ManufactureDate = DateTime.UtcNow.AddYears(-4)
            };

            // Act
            var result = await useCase.Execute(input);

            // Assert
            Assert.NotEqual(Guid.Empty, result.VehicleId);
            Assert.Equal(input.VIN, result.VIN);

            mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Vehicle>()), Times.Once);
        }

        /// <summary>
        ///  Unit test method for validate create vehicle use case.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        [Fact]
        public async Task ExecuteShouldNotCreateVehicleSuccessfully()
        {
            // Arrange
            var mockRepository = new Mock<IVehicleRepository>();
            var useCase = new CreateVehicleUseCase(mockRepository.Object);

            var input = new CreateVehicleInput
            {
                VIN = "1HGCM82633A123456",
                Plate = "ABC123",
                Brand = "Honda",
                Model = "Civic",
                ManufactureDate = DateTime.UtcNow.AddYears(-10)
            };

            // Act & Assert: esperamos que lance excepción
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => useCase.Execute(input));
            Assert.Equal("You cannot create a vehicle that is more than 5 years old.", exception.Message);

            mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Vehicle>()), Times.Never);
        }
    }
}
