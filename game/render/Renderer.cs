using Game.World;

namespace Game.Renderer
{
  public class Renderer
  {
    public static void Render(World.World world)
    {
      var entities = world.GetAllMapEntities();

      int MaxQ = 0;
      int MaxR = 0;

      foreach (var e in entities)
      {
        if (MaxQ < e!.GetComponent<Position>()!.Q)
        {
          MaxQ = e!.GetComponent<Position>()!.Q;
        }


        if (MaxR < e!.GetComponent<Position>()!.R)
        {
          MaxR = e!.GetComponent<Position>()!.R;
        }
      }

      int[,] map = new int[MaxQ + 1, MaxR + 1];

      foreach (var e in entities)
      {
        var position = e.GetComponent<Position>();
        map[position!.Q, position!.R] = 1;
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