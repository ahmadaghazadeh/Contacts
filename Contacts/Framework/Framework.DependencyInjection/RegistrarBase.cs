using Microsoft.Extensions.DependencyInjection;

namespace Framework.DependencyInjection
{
    public abstract class RegistrarBase<TRegister> : IRegistrar
    {
        public void Register(IServiceCollection services)
        {
            services.AddAdvancedDependencyInjection();
        }
    }
}
