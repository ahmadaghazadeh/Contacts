using ContactsContext.Infrastructure;
using Framework.Core.Persistence;
using Mc2.CrudTest.Presentation.Server.Configuration;
using Microsoft.EntityFrameworkCore;
using ReadModel.Infrastructure.Models;

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

			services.AddDbContext<ContactReadDbContext>(option =>
			{
				option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
				option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			});


			services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<CustomExceptionHandlerMiddleware>();

        }
    }
}
