using Game.Document;

namespace Game.World
{
  public class World
  {
    private Document.Document document = new();

    public IReadonlyEntity SpawnUnit()
    {
      var entity = document.CreateEntity(new[] {
        new Position(){ X = 15, Y = 10}
      });

      return entity;
    }

    public IEnumerable<IReadonlyEntity> GetAllMapEntities()
    {
      return document.GetEntities(typeof(Position));
    }
  }
}