using System.Net.Http.Json;
using FluentAssertions;
using Products.Api.Requests.Products;
using Products.Application.Features.Products.DTO;
using Products.Domain.Products;
using Products.Tests.Integration.Api;
using TechTalk.SpecFlow;
using Xunit;

namespace Products.Tests.Integration.Steps;

[Binding]
public class CreateProductStepDefinitions : IClassFixture<ApiFactory>
{
    private readonly HttpClient _client;

    private static string _responseString = string.Empty;

    public CreateProductStepDefinitions(ApiFactory apiFactory)
    {
        _client = apiFactory.Client;
    }

    [When("I create the product with name '(.*)', quantity '(.*)', price '(.*)', description '(.*)'")]
    public async Task WhenITryToCreateTheProductWithTooLongNameQuantityPriceDescription(string name, int quantity,
        decimal price,
        string description)
    {
        var createProductRequest = new CreateProductRequest(name, quantity, price, description);
        var response = await _client.PostAsJsonAsync("products", createProductRequest);
        _responseString = await response.Content.ReadAsStringAsync();
    }

    [Then("the system should not create product")]
    public async Task ThenTheSystemShouldNotCreateProduct()
    {
        var products = await _client.GetFromJsonAsync<IEnumerable<ProductDto>>("products");

        products!.Count().Should().Be(0);
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

    [Then("I should see an error message indicating the name length is too long")]
    public static void ThenIShouldSeeAnErrorMessageIndicatingTheNameLengthIsTooLong()
    {
        _responseString.Should().Contain(Errors.NameMaxLength);
    }


    [Then("I should see an error message indicating the name length is too short")]
    public static void ThenIShouldSeeAnErrorMessageIndicatingTheNameLengthIsTooShort()
    {
        _responseString.Should().Contain(Errors.NameMinLength);
    }

    [Then("I should see an error message indicating the quantity is invalid")]
    public static void ThenIShouldSeeAnErrorMessageIndicatingTheQuantityIsInvalid()
    {
        _responseString.Should().Contain(Errors.QuantityNegative);
    }

    [Then("I should see an error message indicating invalid price")]
    public static void ThenIShouldSeeAnErrorMessageIndicatingInvalidPrice()
    {
        _responseString.Should().Contain(Errors.PriceMinValue);
    }
}