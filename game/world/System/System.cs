using Game.Datastore;

namespace Game.World
{
  // TODO: How to make this only readable in the World directory
  public abstract class System
  {
    protected Document Document;
    protected WorldDispatcher Dispatcher;

    public System(Document document, WorldDispatcher dispatcher)
    {
      Document = document;
      Dispatcher = dispatcher;
    }

    public abstract void Close();
  }

  public class SystemResult
  {
    public readonly string TextReason;

    public readonly bool Success;

    public SystemResult(bool success, string reason = "")
    {
      Success = success;
      TextReason = reason;
    }

    public static implicit operator bool(SystemResult result)
    {
      return result.Success;
    }
  }
}