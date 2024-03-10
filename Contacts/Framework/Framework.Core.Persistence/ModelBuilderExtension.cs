using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Framework.Persistence
{
    public static class ModelBuilderExtension
    {
        public static void RegisterEntityMappings(this ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            IEnumerable<dynamic> types = assemblies.SelectMany(a => a.GetTypes())
                .Where(a => a.BaseType != null && a.BaseType.Name == typeof(EntityMappingBase<>).Name && a is { IsClass: true, IsAbstract: false })
                .Select(Activator.CreateInstance).Cast<dynamic>().ToList();

            foreach (var type in types)
                modelBuilder.ApplyConfiguration(type);
        }

        public static void RegisterAllEntities<TBaseType>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c is { IsClass: true, IsAbstract: false, IsPublic: true } && typeof(TBaseType).IsAssignableFrom(c));

            foreach (Type type in types)
                modelBuilder.Entity(type);
        }
    }
}
