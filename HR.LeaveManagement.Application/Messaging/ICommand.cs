using MediatR;

namespace HR.LeaveManagement.Application.Messaging
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }
    public interface ICommandHandler<TCommand, TResponse>
        : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    { }
}
