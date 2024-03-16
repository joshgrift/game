using Game.Datastore;

namespace Game.World
{
  internal class Movable : Component
  {

    internal int Movement;

    internal int MaxMovement;

    internal static Movable Default() => new()
    {
      MaxMovement = 2,
      Movement = 2
    };
  }
}