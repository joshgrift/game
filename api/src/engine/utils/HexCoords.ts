export class HexCoords {
  constructor(
    private q: number,
    private r: number,
  ) {}

  get Q(): number {
    return this.q;
  }

  set Q(value: number) {
    this.q = value;
  }

  get R(): number {
    return this.r;
  }

  set R(value: number) {
    this.r = value;
  }

  get S(): number {
    return -this.q - this.r;
  }

  public toString(): string {
    return `(${this.q}, ${this.r}, ${this.S})`;
  }

  public subtract(b: HexCoords): HexCoords {
    return new HexCoords(this.q - b.Q, this.r - b.R);
  }

  public distanceTo(b: HexCoords): number {
    const vec = this.subtract(b);
    return (Math.abs(vec.Q) + Math.abs(vec.Q + vec.R) + Math.abs(vec.R)) / 2;
  }

  public toCartesian(size: number): number[] {
    return [
      (this.q * size * 3) / 2,
      size * ((Math.sqrt(3) / 2) * this.q + Math.sqrt(3) * this.r),
    ];
  }

  public equals(b: HexCoords): boolean {
    return b.q == this.q && b.r == this.r;
  }
}
