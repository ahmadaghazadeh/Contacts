
using Framework.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace ContactContext.Configuration
{
    public class Registrar : IRegistrar
    {
        public void Register(IServiceCollection services)
        {
            services.AddAdvancedDependencyInjection();
        }
    }
}
