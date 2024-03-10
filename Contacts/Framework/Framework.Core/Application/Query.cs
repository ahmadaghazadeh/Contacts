using MediatR;

namespace Framework.Core.Application
{
    public abstract class Query<TResult> : IRequest<TResult>
    {
    }
}
