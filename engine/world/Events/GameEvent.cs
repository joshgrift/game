namespace Game.World
{
  public class GameEvent : EventArgs
  {
    public GameEvent(Guid instigator)
    {
      Instigator = instigator;
      Result = new SystemResult(false, "Incomplete");
    }

    public SystemResult Result { get; set; }

    public Guid Instigator { get; set; }
  }
}
