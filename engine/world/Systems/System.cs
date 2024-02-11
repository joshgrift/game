using Game.Datastore;

namespace Game.World
{
  // TODO: How to make this only readable in the World directory
  internal abstract class System
  {
    protected Document Document;
    protected WorldDispatcher Dispatcher;

    internal System(Document document, WorldDispatcher dispatcher)
    {
      Document = document;
      Dispatcher = dispatcher;
    }

    internal abstract void Close();
  }

  internal class SystemResult
  {
    internal readonly string TextReason;

    internal readonly bool Success;

    internal SystemResult(bool success, string reason = "")
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