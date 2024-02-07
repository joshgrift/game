namespace Game.Datastore
{
  // Readonly version of an Entity
  public interface IReadonlyEntity
  {
    abstract T? GetComponent<T>() where T : Component;

    abstract Guid guid
    {
      get;
    }

  }

  // Atomic Unit of the Document

  public class Entity : IReadonlyEntity
  {
    private readonly Dictionary<Type, Component> components = new();

    private Guid _guid;

    public Guid guid
    {
      get => _guid;
    }

    public Entity()
    {
      _guid = Guid.NewGuid();
    }

    public Entity AddComponent(Component component)
    {
      components.Add(component.GetType(), component);

      return this;
    }

    public T? GetComponent<T>() where T : Component
    {
      components.TryGetValue(typeof(T), out Component? value);

      return value as T;
    }
  }
}