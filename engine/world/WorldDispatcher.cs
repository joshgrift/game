using Game.Datastore;

namespace Game.World
{
  internal class WorldDispatcher
  {
    internal event EventHandler<MoveEventArgs>? MoveEvent;

    internal SystemResult Move(MoveEventArgs args)
    {
      MoveEvent?.Invoke(this, args);

      return args.Result;
    }

    internal event EventHandler<TurnEventArgs>? TurnEvent;

    internal SystemResult Turn(TurnEventArgs args)
    {
      TurnEvent?.Invoke(this, args);

      return args.Result;
    }
  }
}