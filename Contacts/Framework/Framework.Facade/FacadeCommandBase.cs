using Framework.Core.Facade;
using MediatR;

namespace Framework.Facade
{
    public abstract class FacadeCommandBase : ICommandFacade
    {
        protected FacadeCommandBase(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IMediator Mediator { get; }
    }


}
