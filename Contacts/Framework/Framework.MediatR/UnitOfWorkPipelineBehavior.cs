using Framework.Core.Persistence;
using MediatR;

namespace Framework.MediatR
{
    public class UnitOfWorkPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IDbContext _dbContext;

        public UnitOfWorkPipelineBehavior(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();
            if (_dbContext.HasAnyThingToSave())
                _dbContext.SaveChanges();

            return response;
        }
    }
}
