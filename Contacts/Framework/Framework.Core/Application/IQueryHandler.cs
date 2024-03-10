using Framework.Core.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Application
{
    public interface IQueryHandler<in TQuery, TResult> : ITransientLifetime, IRequestHandler<TQuery, TResult> where TQuery : IRequest<TResult>
    {
    }
}
