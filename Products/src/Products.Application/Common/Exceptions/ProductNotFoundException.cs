using Products.Application.Abstractions;
using Products.Domain.Abstractions;

namespace Products.Application.Common.Exceptions;

internal sealed class ProductNotFoundException() : NotFoundException(Errors.ProductNotFound);