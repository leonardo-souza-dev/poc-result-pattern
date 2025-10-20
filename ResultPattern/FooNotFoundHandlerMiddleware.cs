using Microsoft.AspNetCore.Http;

namespace ResultPattern;

public class FooNotFoundHandlerMiddleware : ResponseErrorTransformMiddleware
{
    public FooNotFoundHandlerMiddleware(RequestDelegate next)
        : base(
            next,
            StatusCodes.Status404NotFound,
            (context, originalPayload) => new
            {
                type = "https://example.com/probs/not-found",
                title = "Recurso não encontrado",
                status = 404,
                detail = originalPayload,
                instance = context.Request.Path.Value
            })
    {
    }
}