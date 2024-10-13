using MediatR;

namespace Products.Application.Abstractions;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : class, ICommand;