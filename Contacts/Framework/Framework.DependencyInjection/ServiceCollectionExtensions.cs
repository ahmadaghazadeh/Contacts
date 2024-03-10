using System.Reflection;
using Framework.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyModel;
using Scrutor;

namespace Framework.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdvancedDependencyInjection(this IServiceCollection services)
        {
            services.Scan(scan => scan
            .FromDependencyContext(DependencyContext.Default)
            .AddClassesFromInterfaces());

            return services.AddCommonServices();
        }

        public static IServiceCollection AddAdvancedDependencyInjection(this IServiceCollection services, Func<Assembly, bool> predicate)
        {
            services.Scan(scan => scan
            .FromDependencyContext(DependencyContext.Default, predicate)
            .AddClassesFromInterfaces());

            return services.AddCommonServices();
        }

        private static IImplementationTypeSelector AddClassesFromInterfaces(this IImplementationTypeSelector selector)
        {
            //singleton
            selector.AddClasses(classes => classes.AssignableTo<ITransientLifetime>(), true)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithTransientLifetime()

            //transient
            .AddClasses(classes => classes.AssignableTo<ITransientLifetime>(), true)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime()

            //scoped
            .AddClasses(classes => classes.AssignableTo<IScopedLifetime>(), true)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithScopedLifetime()

            .AddClasses(classes => classes.AssignableTo<IScopedLifetime>(), true)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime();

            return selector;
        }

        private static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            services.TryAddSingleton(services);
            return services;
        }
    }
}
