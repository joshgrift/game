using Game.Datastore;

namespace Game.World
{
  public class WorldDispatcher
  {
    public event EventHandler<MoveEventArgs>? MoveEvent;

    public SystemResult Move(MoveEventArgs args)
    {
      MoveEvent?.Invoke(this, args);

      return args.Result;
    }

    public event EventHandler<TurnEventArgs>? TurnEvent;

    public SystemResult Turn(TurnEventArgs args)
    {
      TurnEvent?.Invoke(this, args);

      return args.Result;
    }
  }
}