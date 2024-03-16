namespace Game.World
{
  internal class GameEvent : EventArgs
  {
    internal GameEvent(Guid instigator)
    {
      Instigator = instigator;
      Result = new SystemResult(false, "Incomplete");
    }

    internal SystemResult Result { get; set; }

    internal Guid Instigator { get; set; }
  }
}
