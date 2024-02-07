namespace Game.Datastore
{
  public class Document
  {
    private readonly List<Entity> entities = new();
    private readonly Dictionary<Type, List<Entity>> components = new();

    public Entity CreateEntity(Component[] newComponents)
    {
      var entity = new Entity();

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

    public List<Entity> GetEntities(Type type)
    {
      return components[type];
    }

    public Entity? GetByGuid(Guid guid)
    {
      // SLOW AS HELL
      foreach (var entity in entities)
      {
        if (entity.guid.Equals(guid))
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