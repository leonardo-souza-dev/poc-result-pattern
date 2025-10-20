using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace ResultPattern;

public class ResponseErrorTransformMiddleware
{
    private readonly RequestDelegate _next;
    private readonly int _statusCode;
    private readonly Func<HttpContext, object?, object> _payloadTransformer;

    public ResponseErrorTransformMiddleware(RequestDelegate next, int statusCode, Func<HttpContext, object?, object> payloadTransformer)
    {
        _next = next;
        _statusCode = statusCode;
        _payloadTransformer = payloadTransformer;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        await using var memStream = new MemoryStream();
        context.Response.Body = memStream;

        await _next(context);

        memStream.Seek(0, SeekOrigin.Begin);

        var responseBody = await new StreamReader(memStream).ReadToEndAsync();

        if (context.Response.StatusCode == _statusCode)
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

            var modifiedPayload = _payloadTransformer(context, originalPayload);

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
