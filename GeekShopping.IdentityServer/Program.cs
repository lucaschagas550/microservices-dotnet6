using GeekShopping.IdentityServer.Initializer;

namespace GeekShopping.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            //Criando um scopo do serviço IDbInitializer e passando como parametro na startup
            var dbInitialize = app.Services.CreateScope().ServiceProvider.GetService<IDbInitializer>();

            startup.Configure(app, app.Environment, dbInitialize);
            app.Run();
        }
    }
}