using Game.Document;

namespace Game.World
{
  public class World
  {
    private readonly Document.Document document = new();

    public IReadonlyEntity SpawnUnit()
    {
      var entity = document.CreateEntity(new[] {
        new Position(){ Q = 15, R = 10}
      });

      return entity;
    }

    // Move a unit
    public void MoveUnit(Guid guid, int q, int r)
    {
      var entity = document.GetByGuid(guid);
      if (entity == null)
        return;

      var component = entity.GetComponent<Position>();
      if (component == null)
        return;

      // Do we want to make this into a transaction system?
      component.Q = q;
      component.R = r;
      Console.WriteLine($"Moved to {q}, {r}");
    }

    public IEnumerable<IReadonlyEntity> GetAllMapEntities()
    {
      return document.GetEntities(typeof(Position));
    }
  }
}