using Game.Datastore;

namespace Game.World
{
  public class MovementSystem : System
  {
    public MovementSystem(Document document, WorldDispatcher dispatcher) : base(document, dispatcher)
    {
      Dispatcher.MoveEvent += MoveHandler;
      Dispatcher.TurnEvent += TurnHandler;
    }

    public override void Close()
    {
      Dispatcher.MoveEvent -= MoveHandler;
      Dispatcher.TurnEvent -= TurnHandler;
    }

    private void MoveHandler(object? sender, MoveEventArgs e)
    {
      var entity = Document.GetByGuid(e.EntityGuid);

      if (entity == null)
      {
        e.Result = new SystemResult(false, "This entity does not exist");
        return;
      }

      if (e.Instigator != entity.Owner)
      {
        e.Result = new SystemResult(false, "The player doesn't own this entity");
        return;
      }

      var position = entity.GetComponent<Position>();

      if (position == null)
      {
        e.Result = new SystemResult(false, "This entity does not have a position");
        return;
      }

      var movable = entity.GetComponent<Movable>();
      if (movable == null)
      {
        e.Result = new SystemResult(false, "This entity cannot be moved");
        return;
      }

      if (movable.Movement < 1)
      {
        e.Result = new SystemResult(false, "This entity ran out of movement points");
        return;
      }

      // TODO: Check if the distance is too far away

      // Do we want to make this into a transaction system?
      position.Coords.Q = e.Q;
      position.Coords.R = e.R;
      movable.Movement--;

      e.Result = new SystemResult(true, "Moved to new point");
    }

    public void TurnHandler(object? sender, TurnEventArgs e)
    {
      var entities = Document.GetEntities(typeof(Movable));

      foreach (var entity in entities)
      {
        var movable = entity.GetComponent<Movable>();
        movable!.Movement = movable.MaxMovement;
      }

      e.Result = new SystemResult(true, "Turn Complete");
    }
  }
}