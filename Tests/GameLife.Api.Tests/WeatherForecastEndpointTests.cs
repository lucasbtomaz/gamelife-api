using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace GameLife.Api.Tests;

public class WeatherForecastEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public WeatherForecastEndpointTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_WeatherForecast_RetornaOk()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/WeatherForecast");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
