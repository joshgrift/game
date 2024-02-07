using Game.Datastore;
using Game.Util;

namespace Game.World
{
  // TODO: How to make this only readable in the World directory
  public class Position : Component
  {

    public HexCoords Coords;

    public static Position Default() => new()
    {
      Coords = new HexCoords(0, 0)
    };
  }
}