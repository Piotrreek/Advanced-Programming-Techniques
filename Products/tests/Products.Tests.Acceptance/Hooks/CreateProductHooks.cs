using BoDi;
using Products.Tests.Integration.Api;
using TechTalk.SpecFlow;

namespace Products.Tests.Integration.Hooks;

[Binding]
public class CreateProductHooks
{
    [BeforeFeature("CreateProduct")]
    public static async Task RegisterServices(IObjectContainer objectContainer)
    {
        var factory = new ApiFactory();
        await factory.InitializeAsync();
        objectContainer.RegisterInstanceAs(factory);
    }

    [AfterScenario]
    public static async Task CleanDatabase(IObjectContainer objectContainer)
    {
        var factory = objectContainer.Resolve<ApiFactory>();
        await factory.ResetDatabaseAsync();
    }

    [AfterFeature("CreateProduct")]
    public static async Task DisposeAsync(IObjectContainer objectContainer)
    {
        var factory = objectContainer.Resolve<ApiFactory>();
        await factory.DisposeAsync();
    }
}