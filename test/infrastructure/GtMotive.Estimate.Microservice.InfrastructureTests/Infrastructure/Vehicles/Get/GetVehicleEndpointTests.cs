using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    public class GetVehicleEndpointTests : IClassFixture<GenericInfrastructureTestServerFixture>
    {
        private readonly HttpClient _client;

        public GetVehicleEndpointTests(GenericInfrastructureTestServerFixture fixture)
        {
            ArgumentNullException.ThrowIfNull(fixture);
            _client = fixture.Server.CreateClient();
        }

        [Fact]
        public async Task GetAllVehiclesReturnsOk()
        {
            // Act
            var uri = new Uri("/api/Vehicle", UriKind.Relative);
            var response = await _client.GetAsync(uri);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
