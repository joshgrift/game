using Game.Renderer;
using Game.World;

internal class Program
{
  private static void Main(string[] args)
  {
    Console.WriteLine("Welcome to Game");

    var world = new World();

    world.SpawnUnit();

    Renderer.Render(world);



    //var name = Console.ReadLine();
    //Console.WriteLine(name);
  }
}