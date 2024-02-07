using Game.Datastore;

namespace Game.World
{
  public class Movement : ISystem
  {
    public static bool Move(Document document, Entity entity, int q, int r, out string? result)
    {
      result = "";

      var position = entity.GetComponent<Position>();
      if (position == null)
      {
        result = "This entity does not have a position";
        return false;
      }


      var movable = entity.GetComponent<Movable>();
      if (movable == null)
      {
        result = "This entity cannot be moved";
        return false;
      }

      if (movable.Movement < 1)
      {
        result = "This entity ran out of movement points";
        return false;
      }

      // TODO: Check if the distance is too far away

      // Do we want to make this into a transaction system?
      position.Coords.Q = q;
      position.Coords.R = r;
      movable.Movement--;
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