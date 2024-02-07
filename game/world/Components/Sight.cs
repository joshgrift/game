using Game.Datastore;

namespace Game.World
{
  public class Sight : Component
  {

    public int Radius;

    public static Sight Default() => new()
    {
      Radius = 2
    };
  }
}