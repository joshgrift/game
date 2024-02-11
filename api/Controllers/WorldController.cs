using Microsoft.AspNetCore.Mvc;

namespace gameApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WorldController : ControllerBase
{
  [HttpGet(Name = "World")]
  public string Get()
  {
    var world = WorldAdapter.GetWorld();
    return world.GetCurrentPlayerString();
  }
}
