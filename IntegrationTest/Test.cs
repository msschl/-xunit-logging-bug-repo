#pragma warning disable CA1707, CA2234

using Xunit;
using Xunit.Abstractions;

namespace IntegrationTest;

public class Test : IClassFixture<IntegrationTestWebApplicationFactory>
{
    private readonly IntegrationTestWebApplicationFactory factory;

    public Test(IntegrationTestWebApplicationFactory factory, ITestOutputHelper output)
    {
        this.factory = factory;
        this.factory.OutputHelper = output;
    }

    [Fact]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
    {
        // Arrange
        var client = this.factory.CreateClient();

        // Act
        var response = await client.GetAsync("/");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType?.ToString());
    }
}