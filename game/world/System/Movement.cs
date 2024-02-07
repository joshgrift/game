using Game.Datastore;

namespace Game.World
{
  public class Movement : ISystem
  {
    public static bool Move(Document document, Entity entity, int q, int r)
    {
      var position = entity.GetComponent<Position>();
      if (position == null)
        return false;

      var movable = entity.GetComponent<Movable>();
      if (movable == null)
        return false;

      if (movable.Movement < 1)
        return false;

      // Do we want to make this into a transaction system?
      position.Q = q;
      position.R = r;
      return true;
    }

    public static bool FinishTurn(Document document)
    {
      var entities = document.GetEntities(typeof(Movable));

      foreach (var entity in entities)
      {
        var movable = entity.GetComponent<Movable>();
        movable!.Movement = movable.MaxMovement;
      }

      return true;
    }
  }
}