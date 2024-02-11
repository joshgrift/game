using Game.World;

class WorldAdapter
{
  private static World? World;

  public static void Create()
  {
    World = new World(new string[] { "blue", "red" });
  }

  public static World GetWorld()
  {
    if (World == null)
    {
      Create();
    }

    return World!;
  }
}