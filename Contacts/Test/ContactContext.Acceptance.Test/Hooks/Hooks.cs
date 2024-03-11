using BoDi;
using ContactsContext.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReadModel.Infrastructure.Models;

namespace ContactContext.Acceptance.Test.Hooks
{
	[Binding]
	public class Hooks
	{

		private readonly CustomWebApplicationFactory factory;

		public Hooks(CustomWebApplicationFactory factory)
		{
			this.factory = factory;
		}

		[BeforeScenario]
		public void RunBefore()
		{
			using (var scope = factory.Services.CreateScope())
			{
				var writeDbContext = scope.ServiceProvider.GetRequiredService<ContactDbContext>();
				writeDbContext.Database.EnsureDeleted();
				writeDbContext.Database.Migrate();
			}
		}

		[AfterScenario]
		public void RunAfter()
		{
			using (var scope = factory.Services.CreateScope())
			{
				var writeDbContext = scope.ServiceProvider.GetRequiredService<ContactDbContext>();
				writeDbContext.Database.EnsureDeleted();
			}
		}

		[BeforeScenario(Order = 1)]
		public static void RegisterDependencies(IObjectContainer objectContainer)
		{
			objectContainer.RegisterInstanceAs(new ContactReadDbContext());

		}
		 
	}
}
