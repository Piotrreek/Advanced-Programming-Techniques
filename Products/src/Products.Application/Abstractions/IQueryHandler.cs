using MediatR;

namespace Products.Application.Abstractions;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : class, IQuery<TResult>;