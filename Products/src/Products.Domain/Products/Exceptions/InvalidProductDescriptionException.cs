using Products.Domain.Abstractions;

namespace Products.Domain.Products.Exceptions;

internal sealed class InvalidProductDescriptionException(string message) : ProductsException(message);