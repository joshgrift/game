using Game.World;

namespace Game.Renderer
{
  public class Renderer
  {
    public static void Render(World.World world)
    {
      var entities = world.GetAllMapEntities();

      int MaxX = 0;
      int MaxY = 0;

      foreach (var e in entities)
      {
        if (MaxX < e.GetComponent<Position>().X)
        {
          MaxX = e.GetComponent<Position>().X;
        }


        if (MaxY < e.GetComponent<Position>().Y)
        {
          MaxY = e.GetComponent<Position>().Y;
        }
      }

      int[,] map = new int[MaxX + 1, MaxY + 1];

      foreach (var e in entities)
      {
        var position = e.GetComponent<Position>();
        map[position.X, position.Y] = 1;
      }

      for (int k = 0; k < map.GetLength(0); k++)
      {
        for (int l = 0; l < map.GetLength(1); l++)
        {
          Console.Write(map[k, l]);
        }
        Console.WriteLine("");
      }
    }
  }
}