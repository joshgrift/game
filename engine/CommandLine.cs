namespace Game.Util
{
  internal class CommandUtil
  {
    internal static bool IsGuid(string s)
    {
      return s.IndexOf("-") > -1;
    }
  }
}
