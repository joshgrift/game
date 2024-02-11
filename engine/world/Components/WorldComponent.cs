using Game.Datastore;

namespace Game.World
{
  internal class WorldComponent : Component
  {

    internal required Guid CurrentTurn;

    internal required List<Guid> TurnOrder;

    internal int TurnCount = 0;

    internal string[][]? Terrain;
  }
}