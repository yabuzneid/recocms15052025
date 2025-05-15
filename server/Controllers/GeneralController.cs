using Microsoft.AspNetCore.Mvc;

namespace RecoCms6.Controllers;

[Controller]
public class GeneralController : ControllerBase
{
    [HttpGet("health")]
    public IActionResult Index()
    {
        return Ok();
    }
}