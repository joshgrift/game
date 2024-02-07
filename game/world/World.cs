using Game.Datastore;
using Microsoft.VisualBasic;

namespace Game.World
{
  public class World
  {
    private readonly Document document = new();

    public IReadonlyEntity SpawnUnit(int q, int r)
    {
      var entity = document.CreateEntity(new Component[] {
        new Position(){ Coords = new(q, r)},
        Movable.Default(),
        Sight.Default(),
      });

      return entity;
    }

    // Move a unit
    public void MoveUnit(Guid guid, int q, int r)
    {
      var entity = document.GetByGuid(guid);

      if (entity == null)
        return;

      if (Movement.Move(document, entity, q, r, out var result))
        Console.WriteLine($"Moved to {q}, {r}");
      else
        Console.WriteLine($"Failed moved: {result}");
    }

    public IEnumerable<IReadonlyEntity> GetAllMapEntities()
    {
      return document.GetEntities(typeof(Position));
    }
  }
}