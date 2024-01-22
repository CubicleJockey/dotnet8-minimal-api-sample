using Microsoft.AspNetCore.Builder;
using MinimalAPIExample.Extensions;

namespace MinimalAPIExample.Tests.Extensions;

[TestClass]
public class WebApplicationExtensionsTests
{
    [DataRow(null)]
    [DataRow(default)]
    [DataTestMethod]
    public void EmptyWebApplication(WebApplication application)
    {
        try
        {
            application.ConfigureGameServiceEndpoints();
        }
        catch (ArgumentNullException exception)
        {
            exception.Should().NotBeNull();
            exception.Message.Should().Be("Value cannot be null. (Parameter 'endpoints')");
        }
    }
}