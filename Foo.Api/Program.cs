using Foo.Api.Repository;
using Foo.Api.UseCases;
using ResultPattern;

namespace Foo.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<GetClientUseCase>();

        var app = builder.Build();
        app.UseMiddleware<FooNotFoundHandlerMiddleware>();//precisa ser antes de app.MapControllers
        app.UseMiddleware<FooBadRequestHandlerMiddleware>();//precisa ser antes de app.MapControllers
        app.MapControllers();
        
        app.Run();
    }
}