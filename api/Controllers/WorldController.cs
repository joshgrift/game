using Microsoft.AspNetCore.Mvc;
using Game.World;

namespace gameApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WorldController : ControllerBase
{
  [HttpGet(Name = "World")]
  public string Get()
  {
    var world = new World(new string[] { "blue", "red" });

    return world.GetCurrentPlayerString();
  }
}
