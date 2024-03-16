namespace Game.Datastore
{
  internal class Document
  {
    private readonly List<Entity> entities = new();
    private readonly Dictionary<Type, List<Entity>> components = new();

    internal Entity CreateEntity(Component[] newComponents, Guid? owner = null)
    {
      var entity = new Entity(owner);

      foreach (var newComponent in newComponents)
      {
        if (!components.ContainsKey(newComponent.GetType()))
        {
          components.Add(newComponent.GetType(), new List<Entity>());
        }
        components[newComponent.GetType()].Add(entity);
        entity.AddComponent(newComponent);
      }

      entities.Add(entity);
      return entity;
    }

    internal List<Entity> GetEntities(Type type)
    {
      return components[type] ?? new List<Entity>();
    }

    internal Entity? GetByGuid(Guid guid)
    {
      // SLOW AS HELL
      foreach (var entity in entities)
      {
        if (entity.Guid.Equals(guid))
        {
          return entity;
        }
      }

      return null;
    }

  }

  public class Component
  {

  }
}