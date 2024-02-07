using Game.Datastore;

namespace Game.World
{
  // TODO: How to make this only readable in the World directory
  public interface ISystem
  {
    abstract static bool FinishTurn(Document document);
  }
}