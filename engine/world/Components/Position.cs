using Game.Datastore;
using Game.Util;

namespace Game.World
{
  // TODO: How to make this only readable in the World directory
  internal class Position : Component
  {

    internal HexCoords Coords;

    internal static Position Default() => new()
    {
      Coords = new HexCoords(0, 0)
    };
  }
}