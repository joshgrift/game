using Game.Datastore;
using Game.Renderer;
using Game.World;
using Game.Util;
using System.Linq;

internal class Program
{
  private static void Main(string[] args)
  {
    Console.WriteLine("Welcome to Game");

    var world = new World();

    world.SpawnUnit(5, 10);
    Renderer.Render(world);

    List<IReadonlyEntity>? entityCache = null;

    while (true)
    {
      Console.Write(">");
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

            guid = entityCache[int.Parse(arguments[1])].guid;
          }

          world.MoveUnit(guid, int.Parse(arguments[2]), int.Parse(arguments[3]));
          Console.WriteLine("Moved");

          break;

        case "list":
          entityCache = world.GetAllMapEntities().ToList();

          var i = 0;
          foreach (var entity in entityCache)
          {
            Console.WriteLine($" {i}) {entity.guid} {entity.GetComponent<Position>()!.Coords}");
            i++;
          }
          break;

        case "render":
          Renderer.Render(world);
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
