using Game.Document;

namespace Game.World
{
  public class World
  {
    private Document.Document document = new();

    public IReadonlyEntity SpawnUnit()
    {
      var entity = document.CreateEntity(new[] {
        new Position(){ Q = 15, R = 10}
      });

      return entity;
    }

    public void MoveUnit()
    {

    }

    public IEnumerable<IReadonlyEntity> GetAllMapEntities()
    {
      return document.GetEntities(typeof(Position));
    }
  }
}