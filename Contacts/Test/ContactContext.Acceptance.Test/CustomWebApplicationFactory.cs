using System.Data.Common;
using API;
using ContactsContext.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReadModel.Infrastructure.Models;

namespace ContactContext.Acceptance.Test
{
	public class CustomWebApplicationFactory : WebApplicationFactory<Program>
	{

		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder
				.UseEnvironment("Test")
				.ConfigureTestServices(services =>
				{

					var readContextDescriptor = services.SingleOrDefault(d =>
						d.ServiceType == typeof(DbContextOptions<ContactReadDbContext>));
					if (readContextDescriptor != null) services.Remove(readContextDescriptor);

					var writeContextDescriptor =
						services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ContactDbContext>));
					if (writeContextDescriptor != null) services.Remove(writeContextDescriptor);

					var dbConnectionDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbConnection));
					if (dbConnectionDescriptor != null) services.Remove(dbConnectionDescriptor);

					services.AddSingleton<DbConnection>(container =>
					{
						var connectionString =
							$"Server=.,1433;Database=contactDb{Guid.NewGuid()};User=sa;Password=asd@123_#;TrustServerCertificate=True;Persist Security Info=True;";
						var connection = new SqlConnection(connectionString);
						return connection;
					});

					services.AddDbContext<ContactReadDbContext>((container, options) =>
					{
						var connection = container.GetRequiredService<DbConnection>();
						options.UseSqlServer(connection);
					});

					services.AddDbContext<ContactDbContext>((container, options) =>
					{
						var connection = container.GetRequiredService<DbConnection>();
						options.UseSqlServer(connection);
					});

				});
		}
	}
}
