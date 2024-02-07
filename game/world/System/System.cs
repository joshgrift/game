using Game.Datastore;

namespace Game.World
{
  // TODO: How to make this only readable in the World directory
  public interface ISystem
  {
    abstract static bool FinishTurn(Document document);
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