using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Api.Requests.Products;
using Products.Application.Features.Products.CreateProduct;
using Products.Application.Features.Products.GetProduct;
using Products.Application.Features.Products.GetProducts;
using Products.Application.Features.Products.UpdateProduct;

namespace Products.Api.Controllers;

[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
        => Ok(await _sender.Send(new GetProducts()));

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProductRequest request)
    {
        var command = new CreateProduct(request.Name, request.Quantity, request.Price, request.Description);
        await _sender.Send(command);

        return Created();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync([FromRoute] int id)
        => Ok(await _sender.Send(new GetProduct(id)));

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateProductRequest request)
    {
        var command = new UpdateProduct(id, request.Name, request.Quantity, request.Price, request.Description);
        await _sender.Send(command);

        return NoContent();
    }
}