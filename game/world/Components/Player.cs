using Game.Datastore;

namespace Game.World
{
  public class Player : Component
  {

    public required string Name;

    public static Player Default() => new()
    {
      Name = "test"
    };
  }
}