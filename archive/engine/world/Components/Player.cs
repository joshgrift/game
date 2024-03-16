using Game.Datastore;

namespace Game.World
{
  internal class Player : Component
  {

    internal required string Name;

    internal static Player Default() => new()
    {
      Name = "test"
    };
  }
}