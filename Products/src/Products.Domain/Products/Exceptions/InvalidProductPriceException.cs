using Products.Domain.Abstractions;

namespace Products.Domain.Products.Exceptions;

internal sealed class InvalidProductPriceException(string message) : ProductsException(message);