using Framework.Core.DependencyInjection;
using MediatR;
namespace Framework.Core.Application
{
    public interface ICommandHandler<in TCommand> : ITransientLifetime, IRequestHandler<TCommand> where TCommand : IRequest
    {
    }
}
