using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TheLibrary;

public static class ControllerHandler
{
    public static async Task<IActionResult> ResultHandler(IActionResult successResult, Result result)
    {
        return await Task.FromResult(result.IsSuccess ? successResult : MapUnsuccessfullyResult(result));
    }
    
    private static IActionResult MapUnsuccessfullyResult(Result result)
    {
        var dict = WebApplicationExtensions.GetResulStatusMapper();

        if (dict == null)
        {
            throw new ArgumentException("erro ao obter ResultStatusMapper");
        }
        
        var conversao = dict.TryGetValue(result.Status, out var type);
        return conversao ? Activator.CreateInstance(type, result.Message) as IActionResult : new StatusCodeResult(StatusCodes.Status500InternalServerError);
    }
}
