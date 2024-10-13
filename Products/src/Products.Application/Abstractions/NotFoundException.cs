using Products.Domain.Abstractions;

namespace Products.Application.Abstractions;

public abstract class NotFoundException(string message) : ProductsException(message);