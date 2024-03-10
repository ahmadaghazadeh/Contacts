using ContactsContext.Infrastructure;
using Framework.Core.Persistence;
using Mc2.CrudTest.Presentation.Server.Configuration;
using Microsoft.EntityFrameworkCore;

namespace API.Configuration
{
    public class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IDbContext, ContactDbContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            });

           
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<CustomExceptionHandlerMiddleware>();

        }
    }
}
