using Game.Datastore;

namespace Game.World
{
  public class Movable : Component
  {

    public int Movement;

    public int MaxMovement;

    public static Movable Default() => new()
    {
      MaxMovement = 2,
      Movement = 2
    };
  }
}