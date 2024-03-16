import { HexCoords } from './HexCoords';

describe('HexCoords Util', () => {
  const h = (q: number, r: number) => new HexCoords(q, r);

  describe('Should be able to be compared to one another', () => {
    it('(1,1).equals(1,1)', () => {
      expect(h(1, 1).equals(h(1, 1))).toBe(true);
    });

    it('(1,1).equals(1,0)', () => {
      expect(h(1, 1).equals(h(1, 0))).toBe(false);
    });
  });

  describe('Should calculate S properly when Q & R are', () => {
    it('1 & 2', () => {
      expect(h(1, 2).S).toBe(-3);
    });

    it('0 & 0', () => {
      expect(h(0, 0).S == 0).toBe(true);
    });

    it('-3 & 0', () => {
      expect(h(-3, 0).S).toBe(3);
    });

    it('-2 & -1', () => {
      expect(h(-2, -1).S).toBe(3);
    });
  });

  it('Should be converted to string properly', () => {
    expect('' + h(0, 0)).toBe('(0, 0, 0)');
  });

  describe('Should Subtract properly', () => {
    it('1,1 - 1,1', () => {
      expect(h(1, 1).subtract(h(1, 1)).equals(h(0, 0))).toBe(true);
    });

    it('1,4 - 5,3', () => {
      expect(h(1, 4).subtract(h(5, 3)).equals(h(-4, 1))).toBe(true);
    });
  });

  describe('Should properly calculate the distance from', () => {
    const testDistance = (a: HexCoords, b: HexCoords, distance: number) => {
      it(`${a} to ${b}`, () => {
        expect(a.distanceTo(b)).toBe(distance);
      });
    };

    testDistance(h(0, 0), h(1, 1), 2);
    testDistance(h(1, -3), h(-1, 4), 7);
  });

  describe('Should properly convert to Cartesian', () => {
    const testToCartesian = (
      a: HexCoords,
      size: number,
      x: number,
      y: number,
    ) => {
      it(`${a}`, () => {
        const r = a.toCartesian(size);
        expect(r[0]).toBe(x);
        expect(r[1]).toBe(y);
      });
    };

    testToCartesian(h(0, 0), 10, 0, 0);
    testToCartesian(h(1, 1), 10, 15, 10 * ((3 * Math.sqrt(3)) / 2));
  });
});
