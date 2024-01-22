using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MinimalAPIExample.DependencyInjection.Tests;

[TestClass]
public class ServiceCollectionExtensionsTests
{
    private readonly IServiceCollection fakeServicesCollection = A.Fake<IServiceCollection>();
    private readonly IConfiguration fakeConfiguration = A.Fake<IConfiguration>();

    [TestCleanup]
    public void TestCleanup()
    {
        Fake.ClearRecordedCalls(fakeServicesCollection);
        Fake.ClearRecordedCalls(fakeConfiguration);
    }
    
    [DataRow(null)]
    [DataRow(default)]
    [DataTestMethod]
    public void AddMinimalApiExampleDependencies_EmptyServiceCollection(IServiceCollection serviceCollection)
    {
       var method = () =>  serviceCollection.AddMinimalApiExampleDependencies(fakeConfiguration);
       method.Should()
             .Throw<ArgumentNullException>()
             .WithMessage("Value cannot be null. (Parameter 'services')");
    }

    [DataRow(null)]
    [DataRow(default)]
    [DataTestMethod]
    public void AddMinimalApiExampleDependencies_EmptyConfiguration(IConfiguration configuration)
    {
        var method = () => fakeServicesCollection.AddMinimalApiExampleDependencies(configuration);
        method.Should()
            .Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'configuration')");
    }

    [TestMethod]
    public void AddMinimalApiExampleDependencies_Valid()
    {
        try
        {
            fakeServicesCollection.AddMinimalApiExampleDependencies(fakeConfiguration);
        }
        catch
        {
            Assert.Fail("No exception should be encountered.");
        }
    }
}