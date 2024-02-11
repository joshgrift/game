namespace Game.Datastore
{
  // Readonly version of an Entity
  public interface IReadonlyEntity
  {
    abstract T? GetComponent<T>() where T : Component;

    abstract Guid Guid
    {
      get;
    }

    abstract Guid? Owner
    {
      get;
    }
  }

  // Atomic Unit of the Document

  public class Entity : IReadonlyEntity
  {
    private readonly Dictionary<Type, Component> components = new();

    private readonly Guid guid;

    public Guid Guid
    {
      get => guid;
    }

    public Guid? Owner { get; set; } = null;

    public Entity(Guid? owner = null)
    {
      guid = Guid.NewGuid();
      Owner = owner;
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