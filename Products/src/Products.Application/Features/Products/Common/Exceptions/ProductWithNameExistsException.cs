using Products.Domain.Abstractions;

namespace Products.Application.Features.Products.Common.Exceptions;

internal sealed class ProductWithNameExistsException() : ProductsException(Errors.ProductWithNameExists);