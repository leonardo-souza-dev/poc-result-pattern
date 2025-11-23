using Foo.Api.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Foo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController(GetClientUseCase getClientUseCase) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetClientRequest request)
    {
        var result = await getClientUseCase.Handle(request);

        return Ok(result);
    }
}