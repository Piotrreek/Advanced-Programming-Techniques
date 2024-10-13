using Products.Domain.Abstractions;

namespace Products.Domain.Products.Exceptions;

internal sealed class InvalidProductNameException(string message) : ProductsException(message);