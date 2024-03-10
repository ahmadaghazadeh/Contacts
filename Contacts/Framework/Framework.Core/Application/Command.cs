using Framework.Core.DependencyInjection;
using MediatR;

namespace Framework.Core.Application
{
    public abstract class Command : IRequest, ITransientLifetime
    {
    }
}
