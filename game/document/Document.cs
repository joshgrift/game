namespace Game.Document
{
  public class Document
  {
    private List<Entity> entities = new();
    private Dictionary<Type, List<Entity>> components = new();

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

      return entity;
    }

    public List<Entity> GetEntities(Type type)
    {
      return components[type];
    }

  }

  public class Component
  {

  }
}