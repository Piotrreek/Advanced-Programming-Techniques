using Products.Domain.Abstractions;

namespace Products.Domain.Products.Exceptions;

internal sealed class InvalidProductQuantityException(string message) : ProductsException(message);