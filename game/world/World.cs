using Game.Datastore;

namespace Game.World
{
  public class World
  {
    private readonly Document Document = new();

    // A list of all the systems we want to react to things
    private readonly List<System> systems = new();

    private WorldDispatcher Dispatcher = new();

    // create new
    public World(string[] playerNames)
    {
      if (playerNames.Length < 1)
        throw new ArgumentException("Missing players");

      RegisterSystems();

      List<Guid> players = new();

      foreach (var playerName in playerNames)
      {
        var player = Document.CreateEntity(new Component[] {
          new Player(){ Name = playerName }
        });

        players.Add(player.Guid);
      }

      var worldEntity = Document.CreateEntity(new Component[] {
        new WorldComponent(){
          CurrentTurn = players[0],
          TurnOrder = players
        }
      });
    }

    private void RegisterSystems()
    {
      systems.Add(new MovementSystem(Document, Dispatcher));
      systems.Add(new TurnSystem(Document, Dispatcher));
    }

    // load from file
    public World(string json)
    {
      throw new NotImplementedException("");
    }

    public IReadonlyEntity SpawnUnit(int q, int r)
    {
      var entity = Document.CreateEntity(new Component[] {
        new Position(){ Coords = new(q, r)},
        Movable.Default(),
        Sight.Default(),
      }, GetCurrentPlayerEntity().Guid);

      return entity;
    }

    // Move a unit
    public void MoveUnit(Guid guid, int q, int r)
    {
      var e = Dispatcher.Move(new MoveEventArgs(GetCurrentPlayerEntity().Guid, guid, q, r));
      Console.WriteLine($"{e.TextReason}");
    }

    public Entity GetCurrentPlayerEntity()
    {
      var entities = Document.GetEntities(typeof(WorldComponent));
      var worldComponent = entities[0].GetComponent<WorldComponent>() ?? throw new Exception("Missing world component");

      return Document.GetByGuid(worldComponent.CurrentTurn) ?? throw new Exception("Missing player entity"); ;
    }

    public string GetCurrentPlayerString()
    {
      return GetCurrentPlayerEntity().GetComponent<Player>()!.Name;
    }

    public IReadonlyEntity AddPlayer(string name)
    {
      var entity = Document.CreateEntity(new Component[] {
        new Player(){ Name = name }
      });

      return entity;
    }

    public IEnumerable<IReadonlyEntity> GetAllMapEntities()
    {
      return Document.GetEntities(typeof(Position));
    }

    public string GetPlayerName(Guid guid)
    {
      return DocumentHelpers.GetPlayerName(Document, guid);
    }

    public void EndTurn()
    {
      var currentPlayer = GetCurrentPlayerEntity().Guid;
      var worldComponent = DocumentHelpers.GetWorldComponent(Document);
      var count = worldComponent.TurnOrder.Count;
      var turnCount = worldComponent.TurnCount;
      turnCount++;
      var nextPlayer = worldComponent.TurnOrder[turnCount % count];
      var newRound = turnCount % count == 0;

      Dispatcher.Turn(new TurnEventArgs(currentPlayer, currentPlayer, nextPlayer, newRound));
    }
  }
}