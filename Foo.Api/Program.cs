using Microsoft.OpenApi.Models;
using System.Reflection;
using Foo.Api.Infrastructure;
using Foo.Api.Repository;
using Foo.Api.UseCases;
using Microsoft.AspNetCore.Mvc;
using TheLibrary;

namespace Foo.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = Assembly.GetExecutingAssembly().GetName().Name, Version = "v0" }); });
        builder.Services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });
        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<GetClientUseCase>();
        
        var app = builder.Build();
        app.UseStandardResultPattern(ResultStatusMapper.Build()
            .Add(FooResultStatus.InvalidRequest, typeof(BadRequestObjectResult))
            .Add(FooResultStatus.ClientNotFound, typeof(BadRequestObjectResult))
            .Add(FooResultStatus.Unauthorized, typeof(UnauthorizedObjectResult)));
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    }
}