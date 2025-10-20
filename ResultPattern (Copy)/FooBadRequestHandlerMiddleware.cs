using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace ResultPattern;

public class FooBadRequestHandlerMiddleware(RequestDelegate _next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        await using var memStream = new MemoryStream();
        context.Response.Body = memStream;

        await _next(context);

        memStream.Seek(0, SeekOrigin.Begin);

        var responseBody = await new StreamReader(memStream).ReadToEndAsync();

        if (context.Response.StatusCode == StatusCodes.Status400BadRequest)
        {
            object? originalPayload = null;

            try
            {
                if (!string.IsNullOrWhiteSpace(responseBody))
                    originalPayload = JsonSerializer.Deserialize<object>(responseBody);
            }
            catch
            {
                originalPayload = responseBody;
            }

            var modifiedPayload = new
            {
                type = "https://example.com/probs/invalid-parameters",
                title = "Parâmetros inválidos",
                errors = new[]{
                    new {
                        details = originalPayload,
                        pointer = "TODO:",
                        instance = context.Request.Path.Value,
                    }
                }
            };

            var json = JsonSerializer.Serialize(modifiedPayload);
            var data = Encoding.UTF8.GetBytes(json);

            context.Response.ContentType = "application/json";
            context.Response.ContentLength = data.Length;

            context.Response.Body = originalBodyStream;
            await context.Response.Body.WriteAsync(data);
        }
        else
        {
            memStream.Seek(0, SeekOrigin.Begin);
            await memStream.CopyToAsync(originalBodyStream);
        }
    }
}