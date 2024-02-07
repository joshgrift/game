using Game.Document;

namespace Game.World
{
  // TODO: How to make this only readable in the World directory
  public class Position : Component
  {

    public int X;
    public int Y;

    public static Position Default() => new()
    {
      X = 5,
      Y = 2,
    };
  }
}