using Game.Datastore;

namespace Game.World
{
  public class TurnSystem : System
  {
    public TurnSystem(Document document, WorldDispatcher dispatcher) : base(document, dispatcher)
    {
      Dispatcher.TurnEvent += TurnHandler;
    }

    public override void Close()
    {
      Dispatcher.TurnEvent -= TurnHandler;
    }

    public void TurnHandler(object? sender, TurnEventArgs e)
    {
      var worldComponent = DocumentHelpers.GetWorldComponent(Document);

      worldComponent.TurnCount++;
      worldComponent.CurrentTurn = e.NextPlayer;

      e.Result = new SystemResult(true);
    }
  }
}