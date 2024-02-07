namespace Game.Document
{
  // Readonly version of an Entity
  public interface IReadonlyEntity
  {
    abstract T GetComponent<T>() where T : Component;
  }

  // Atomic Unit of the Document

  public class Entity : IReadonlyEntity
  {
    private Dictionary<Type, Component> components = new();

    public Entity AddComponent(Component component)
    {
      components.Add(component.GetType(), component);

      return this;
    }

    public T GetComponent<T>() where T : Component
    {
      components.TryGetValue(typeof(T), out Component value);

      return value as T;
    }
  }
}