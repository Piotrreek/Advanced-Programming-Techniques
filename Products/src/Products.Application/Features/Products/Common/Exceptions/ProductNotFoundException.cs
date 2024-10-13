using Products.Application.Abstractions;

namespace Products.Application.Features.Products.Common.Exceptions;

internal sealed class ProductNotFoundException() : NotFoundException(Errors.ProductNotFound);