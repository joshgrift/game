using Game.Datastore;

namespace Game.World
{
  internal class TurnSystem : System
  {
    internal TurnSystem(Document document, WorldDispatcher dispatcher) : base(document, dispatcher)
    {
      Dispatcher.TurnEvent += TurnHandler;
    }

    internal override void Close()
    {
      Dispatcher.TurnEvent -= TurnHandler;
    }

    internal void TurnHandler(object? sender, TurnEventArgs e)
    {
      var worldComponent = DocumentHelpers.GetWorldComponent(Document);

      worldComponent.TurnCount++;
      worldComponent.CurrentTurn = e.NextPlayer;

      e.Result = new SystemResult(true);
    }
  }
}