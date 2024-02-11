using Game.Datastore;
using Game.Renderer;
using Game.World;

internal class Program
{

  private static void openWindow(World world)
  {
    Thread thread = new Thread(() =>
      {
        // Your window creation logic here
        var gameWindow = new GameWindow(world);
        System.Windows.Threading.Dispatcher.Run();
      });
    thread.SetApartmentState(ApartmentState.STA); // Set the thread to STA
    thread.Start();
  }

  private static void Main(string[] args)
  {
    Console.WriteLine("Welcome to Game");

    var world = new World(new string[] { "blue", "red" });

    world.SpawnUnit(1, -1);
    //Renderer.Render(world);

    List<IReadonlyEntity>? entityCache = null;

    openWindow(world);

    while (true)
    {
      Console.Write($"({world.GetCurrentPlayerString()}) >");
      var raw = Console.ReadLine() ?? "exit";
      var arguments = raw.Split(" ");

      switch (arguments[0])
      {
        case "move":
          if (arguments.Length <= 3)
          {
            Console.WriteLine("Missing Guid/id or coords");
            break;
          }

          Guid guid;

          try
          {
            guid = new(arguments[1]);
          }
          catch
          {
            if (entityCache == null)
            {
              Console.WriteLine("Run list first");
              break;
            }

            guid = entityCache[int.Parse(arguments[1])].Guid;
          }

          world.MoveUnit(guid, int.Parse(arguments[2]), int.Parse(arguments[3]));

          break;

        case "list":
          entityCache = world.GetAllMapEntities().ToList();

          var i = 0;
          foreach (var entity in entityCache)
          {
            var entityString = $" {i}) {entity.Guid}";

            if (entity.Owner != null)
            {
              var name = world.GetPlayerName((Guid)entity.Owner);
              entityString += $" ({name})";
            }

            entityString += $" {entity.GetComponent<Position>()!.Coords}";

            var movableComponent = entity.GetComponent<Movable>();
            if (movableComponent != null)
              entityString += $" M: {movableComponent.Movement}";

            Console.WriteLine(entityString);
            i++;
          }
          break;

        case "render":
          Renderer.Render(world);
          break;

        case "turn":
          world.EndTurn();
          break;

        case "exit":
          return;

        default:
          Console.WriteLine("Command not valid");
          break;
      }

    }
  }
}
