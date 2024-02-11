namespace Game.Util
{
  public struct HexCoords
  {
    public HexCoords(int q, int r)
    {
      Q = q;
      R = r;
    }

    public int Q { get; set; }
    public int R { get; set; }
    public readonly double S { get => -Q - R; }

    public override readonly string ToString() => $"({Q}, {R}, {S})";

    public readonly HexCoords Subtract(HexCoords b)
    {
      return new HexCoords(Q - b.Q, R - b.R);
    }

    public readonly double DistanceTo(HexCoords b)
    {
      var vec = Subtract(b);
      return (Math.Abs(vec.Q) + Math.Abs(vec.Q + vec.R) + Math.Abs(vec.R)) / 2;
    }

    public readonly double[] ToCartesian(int size)
    {
      return new double[]{
        Q * size * 3 / 2,
        size * (Math.Sqrt(3) / 2 * Q + Math.Sqrt(3) * R)
      };
    }
  }
}