using Game.Datastore;

namespace Game.World
{
  // TODO: How to make this only readable in the World directory
  public class Position : Component
  {

    public int Q;
    public int R;

    public static Position Default() => new()
    {
      Q = 5,
      R = 2,
    };
  }
}