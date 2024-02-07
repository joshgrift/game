namespace Game.Util
{
  public class CommandUtil
  {
    public static bool IsGuid(string s)
    {
      return s.IndexOf("-") > -1;
    }
  }
}
