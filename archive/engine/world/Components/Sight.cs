using Game.Datastore;

namespace Game.World
{
  internal class Sight : Component
  {

    internal int Radius;

    internal static Sight Default() => new()
    {
      Radius = 2
    };
  }
}