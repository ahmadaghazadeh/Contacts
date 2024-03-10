using MediatR;

namespace Framework.Core.Facade
{
    public abstract class FacadeQueryBase : IQueryFacade
    {
        protected FacadeQueryBase(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IMediator Mediator { get; }

    }
}
