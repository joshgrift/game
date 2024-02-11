using Game.Datastore;

namespace Game.World
{
  internal class MoveEventArgs : GameEvent
  {
    internal MoveEventArgs(Guid instigator, int q, int r) : base(instigator)
    {
    }

    internal MoveEventArgs(Guid instigator, Guid entityGuid, int q, int r) : base(instigator)
    {
      EntityGuid = entityGuid;
      Q = q;
      R = r;
    }

    internal Guid EntityGuid { get; set; }
    internal int Q { get; set; }
    internal int R { get; set; }
  }
}
