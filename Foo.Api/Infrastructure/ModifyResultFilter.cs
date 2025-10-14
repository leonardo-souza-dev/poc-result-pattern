// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Filters;
//
// namespace Foo.Api.Infrastructure;
//
// public class ModifyResultFilter : IResultFilter
// {
//     public void OnResultExecuting(ResultExecutingContext context)
//     {
//         if (context.Result is OkObjectResult okObjectResult /*|| context.Result is OkResult okResult*/)
//         {
//             var originalPayload = okObjectResult?.Value;
//             context.Result = new OkObjectResult(originalPayload);
//         }
//     }
//
//     public void OnResultExecuted(ResultExecutedContext context)
//     {
//     }
// }