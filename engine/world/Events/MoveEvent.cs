using Game.Datastore;

namespace Game.World
{
  public class MoveEventArgs : GameEvent
  {
    public MoveEventArgs(Guid instigator, int q, int r) : base(instigator)
    {
    }

    public MoveEventArgs(Guid instigator, Guid entityGuid, int q, int r) : base(instigator)
    {
      EntityGuid = entityGuid;
      Q = q;
      R = r;
    }

    public Guid EntityGuid { get; set; }
    public int Q { get; set; }
    public int R { get; set; }
  }
}
