using Foo.Api.UseCases;
using Microsoft.AspNetCore.Mvc;
using static TheLibrary.ControllerHandler;

namespace Foo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController(GetClientUseCase getClientUseCase) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetClientRequest request)
    {
        var result = getClientUseCase.Handle(request);
        
        return await ResultHandler(Ok(result.Value), result);
    }
}