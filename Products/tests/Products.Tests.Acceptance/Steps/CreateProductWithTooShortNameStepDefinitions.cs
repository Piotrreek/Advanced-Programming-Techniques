using System.Net.Http.Json;
using FluentAssertions;
using Products.Api.Requests.Products;
using Products.Application.Features.Products.DTO;
using Products.Domain.Products;
using Products.Tests.Integration.Api;
using TechTalk.SpecFlow;

namespace Products.Tests.Integration.Steps;

[Binding]
public class CreateProductWithTooShortNameStepDefinitions
{
    private readonly HttpClient _client;
    private static string _responseString = string.Empty;

    public CreateProductWithTooShortNameStepDefinitions(ApiFactory apiFactory)
    {
        _client = apiFactory.Client;
    }

    [When("I try to create the product with too short name '(.*)', quantity '(.*)', price '(.*)', description '(.*)'")]
    public async Task WhenITryToCreateTheProductWithTooShortNameQuantityPriceDescription(string name, int quantity,
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

    [Then("I should see an error message indicating the name length is too short")]
    public void ThenIShouldSeeAnErrorMessageIndicatingTheNameLengthIsTooShort()
    {
        _responseString.Should().Contain(Errors.NameMinLength);
    }
}