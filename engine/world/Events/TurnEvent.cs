using Game.Datastore;

namespace Game.World
{
  public class TurnEventArgs : GameEvent
  {
    public TurnEventArgs(Guid instigator, Guid previousPlayer, Guid nextPlayer, bool newRound) : base(instigator)
    {
      PreviousPlayer = previousPlayer;
      NextPlayer = nextPlayer;
      NewRound = newRound;
    }

    public Guid PreviousPlayer { get; set; }
    public Guid NextPlayer { get; set; }
    public bool NewRound { get; set; }
  }
}
