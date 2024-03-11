
using API.Configuration;
using ContactContext.Configuration;
using Framework.MediatR;
using Mc2.CrudTest.Presentation.Server.Configuration;
using MediatR;
namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkPipelineBehavior<,>));
            });

            builder.Services.InstallServices(
                builder.Configuration,
                typeof(IServiceInstaller).Assembly);

            new Registrar().Register(builder.Services);


            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
