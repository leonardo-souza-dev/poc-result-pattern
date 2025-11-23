using Foo.Api.UseCases;

namespace Foo.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddScoped<GetClientUseCase>();

        var app = builder.Build();
        app.MapControllers();
        
        app.Run();
    }
}
