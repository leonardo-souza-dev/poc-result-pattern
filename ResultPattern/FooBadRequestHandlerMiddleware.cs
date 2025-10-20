using Microsoft.AspNetCore.Http;

namespace ResultPattern;

public class FooBadRequestHandlerMiddleware : ResponseErrorTransformMiddleware
{
    public FooBadRequestHandlerMiddleware(RequestDelegate next)
        : base(
            next,
            StatusCodes.Status400BadRequest,
            (context, originalPayload) => new
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
            })
    {
    }
}