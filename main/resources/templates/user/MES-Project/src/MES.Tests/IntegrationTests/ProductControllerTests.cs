using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace MES.Tests.IntegrationTests
{
    public class ProductControllerTests : IClassFixture<WebApplicationFactory<MES.API.Startup>>
    {
        private readonly HttpClient _client;

        public ProductControllerTests(WebApplicationFactory<MES.API.Startup> factory)
        {
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Here you can configure any test-specific services if needed
                });
            }).CreateClient();
        }

        [Fact]
        public async Task GetProducts_ReturnsOkResult()
        {
            // Act
            var response = await _client.GetAsync("/api/products");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetProduct_ExistingId_ReturnsOkResult()
        {
            // Arrange
            var productId = 1; // Assuming a product with ID 1 exists

            // Act
            var response = await _client.GetAsync($"/api/products/{productId}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetProduct_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var productId = 999; // Assuming no product with this ID exists

            // Act
            var response = await _client.GetAsync($"/api/products/{productId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}