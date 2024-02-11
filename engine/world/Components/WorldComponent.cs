using Game.Datastore;

namespace Game.World
{
  public class WorldComponent : Component
  {

    public required Guid CurrentTurn;

    public required List<Guid> TurnOrder;

    public int TurnCount = 0;

    public string[][]? Terrain;
  }
}