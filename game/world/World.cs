using Game.Datastore;

namespace Game.World
{
  public class World
  {
    private readonly Document document = new();

    public IReadonlyEntity SpawnUnit()
    {
      var entity = document.CreateEntity(new Component[] {
        new Position(){ Q = 15, R = 10},
        new Movable(),
        new Sight()
      });

      return entity;
    }

    // Move a unit
    public void MoveUnit(Guid guid, int q, int r)
    {
      var entity = document.GetByGuid(guid);

      if (entity == null)
        return;

      if (Movement.Move(document, entity, q, r))
        Console.WriteLine($"Moved to {q}, {r}");
    }

    public IEnumerable<IReadonlyEntity> GetAllMapEntities()
    {
      return document.GetEntities(typeof(Position));
    }
  }
}