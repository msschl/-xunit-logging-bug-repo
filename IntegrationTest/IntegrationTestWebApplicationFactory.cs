using Microsoft.AspNetCore.Mvc.Testing;

using Xunit.Abstractions;

using MartinCostello.Logging.XUnit;

namespace IntegrationTest;

public class IntegrationTestWebApplicationFactory : WebApplicationFactory<Program>, ITestOutputHelperAccessor
{
    public IntegrationTestWebApplicationFactory()
        : base()
    { }

    public ITestOutputHelper? OutputHelper { get; set; } = null!;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder
            .ConfigureAppConfiguration(configuration =>
            {
                configuration.AddUserSecrets<Program>();
            })
            .ConfigureLogging(logging =>
            {
                logging.AddXUnit(this);
            });
    }
}