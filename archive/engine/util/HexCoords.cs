namespace Game.Util
{
  internal struct HexCoords
  {
    internal HexCoords(int q, int r)
    {
      Q = q;
      R = r;
    }

    internal int Q { get; set; }
    internal int R { get; set; }
    internal readonly double S { get => -Q - R; }

    public override readonly string ToString() => $"({Q}, {R}, {S})";

    internal readonly HexCoords Subtract(HexCoords b)
    {
      return new HexCoords(Q - b.Q, R - b.R);
    }

    internal readonly double DistanceTo(HexCoords b)
    {
      var vec = Subtract(b);
      return (Math.Abs(vec.Q) + Math.Abs(vec.Q + vec.R) + Math.Abs(vec.R)) / 2;
    }

    internal readonly double[] ToCartesian(int size)
    {
      return new double[]{
        Q * size * 3 / 2,
        size * (Math.Sqrt(3) / 2 * Q + Math.Sqrt(3) * R)
      };
    }
  }
}