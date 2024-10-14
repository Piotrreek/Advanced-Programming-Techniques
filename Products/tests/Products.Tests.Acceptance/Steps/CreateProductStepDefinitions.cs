using System.Net.Http.Json;
using FluentAssertions;
using Products.Api.Requests.Products;
using Products.Application.Features.Products.DTO;
using Products.Tests.Integration.Api;
using TechTalk.SpecFlow;
using Xunit;

namespace Products.Tests.Integration.Steps;

[Binding]
public class CreateProductStepDefinitions : IClassFixture<ApiFactory>
{
    private static ApiFactory _apiFactory = default!;
    private static HttpClient _client = default!;

    [BeforeTestRun]
    public static async Task BeforeTestRun()
    {
        _apiFactory = new ApiFactory();
        await _apiFactory.InitializeAsync();
        _client = _apiFactory.CreateClient();
    }

    [AfterTestRun]
    public static async Task AfterTestRun()
    {
        _client.Dispose();
        await _apiFactory.DisposeAsync();
    }

    [When("I create the product with name '(.*)', quantity '(.*)', price '(.*)', description '(.*)'")]
    public async Task WhenICreateTheProductWithNameQuantityPriceDescription(string name, int quantity, decimal price,
        string description)
    {
        var createProductRequest = new CreateProductRequest(name, quantity, price, description);
        await _client.PostAsJsonAsync("products", createProductRequest);
    }

    [Then("product with name '(.*)', quantity '(.*)', price '(.*)', description '(.*)' should be created")]
    public async Task ThenProductProductWithNameQuantityPriceDescriptionShouldBeCreated(string name, int quantity,
        decimal price, string description)
    {
        var expectedProductDetails = new ProductDetailsDto
        {
            Id = 1,
            Name = name,
            Price = price,
            Quantity = quantity,
            Description = description,
            Available = quantity > 0
        };

        var products = await _client.GetFromJsonAsync<IEnumerable<ProductDto>>("products");
        var product = products!.Single(x => x.Name == name);

        var productDetails = await _client.GetFromJsonAsync<ProductDetailsDto>($"products/{product.Id}");

        productDetails.Should().BeEquivalentTo(expectedProductDetails, options => options.Excluding(x => x.Id));
    }
}