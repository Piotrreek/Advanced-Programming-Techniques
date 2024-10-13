using MediatR;

namespace Products.Application.Abstractions;

public interface IQuery<out TResult> : IRequest<TResult>;