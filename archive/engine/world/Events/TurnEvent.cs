using Game.Datastore;

namespace Game.World
{
  internal class TurnEventArgs : GameEvent
  {
    internal TurnEventArgs(Guid instigator, Guid previousPlayer, Guid nextPlayer, bool newRound) : base(instigator)
    {
      PreviousPlayer = previousPlayer;
      NextPlayer = nextPlayer;
      NewRound = newRound;
    }

    internal Guid PreviousPlayer { get; set; }
    internal Guid NextPlayer { get; set; }
    internal bool NewRound { get; set; }
  }
}
