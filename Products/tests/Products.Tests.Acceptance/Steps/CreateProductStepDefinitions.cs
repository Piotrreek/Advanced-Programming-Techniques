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
    private readonly HttpClient _client;

    public CreateProductStepDefinitions(ApiFactory apiFactory)
    {
        _client = apiFactory.Client;
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