using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bejeweled3AI.Common
{
    public static class Mover
    {
        private enum Plane
        {
            Vertical,
            Horizontal
        }

        private static Dictionary<Direction, (int x, int y)> Transform = new Dictionary<Direction, (int x, int y)>
        {
            { Direction.Up, (0, -1) },
            { Direction.Down, (0, 1) },
            { Direction.Left, (-1, 0) },
            { Direction.Right, (1, 0) }
        };

        public static Direction? RecomendedMove(BlockType[,] grid, int c, int l)
        {
            var tc = grid.GetLength(0);
            var tl = grid.GetLength(1);

            bool canMove(Direction direction)
            {
                switch (direction)
                {
                    case Direction.Up: return l > 0;
                    case Direction.Down: return l + 1 < tl;
                    case Direction.Left: return c > 0;
                    case Direction.Right: return c + 1 < tc;
                    default:
                        throw new Exception();
                }
            }

            (int nC, int nL) GetInDirection(Direction direction)
            {
                int nC, nL;
                switch (direction)
                {
                    case Direction.Up:
                        nC = c;
                        nL = l - 1;
                        break;
                    case Direction.Down:
                        nC = c;
                        nL = l + 1;
                        break;
                    case Direction.Left:
                        nC = c - 1;
                        nL = l;
                        break;
                    case Direction.Right:
                        nC = c + 1;
                        nL = l;
                        break;
                    default:
                        throw new Exception();
                }

                return (nC, nL);
            }

            void Swap(int nC, int nL)
            {
                var a = grid[c, l];
                var b = grid[nC, nL];

                grid[c, l] = b;
                grid[nC, nL] = a;
            }

            int Matches(int nC, int nL, bool countIncomplete, Direction? exclude = null, Plane? plane = null)
            {
                var verticalCount = 0;
                var horizontalCount = 0;

                foreach (var item in TransformationInPlane(plane, exclude))
                {
                    (var x, var y) = item.Value;

                    var bC = nC + x;
                    var bL = nL + y;

                    if (((bC >= 0 && bC < tc) && (bL >= 0 && bL < tl)) && (Equivalent(grid[nC, nL], grid[bC, bL])))
                    {
                        var currentPlane = GetPlane(item.Key);
                        var nCount = Matches(bC, bL, true, Invert(item.Key), currentPlane);

                        if (currentPlane == Plane.Horizontal)
                            horizontalCount += nCount + 1;
                        else if (currentPlane == Plane.Vertical)
                            verticalCount += nCount + 1;
                        else
                            throw new Exception();
                    }
                }

                var totalCount = 0;

                if (countIncomplete || verticalCount > 1)
                    totalCount += verticalCount;

                if (countIncomplete || horizontalCount > 1)
                    totalCount += horizontalCount;

                return totalCount;
            }

            bool Check(Direction direction)
            {
                if (!canMove(direction))
                    return false;

                (var nC, var nL) = GetInDirection(direction);

                Swap(nC, nL);
                var resultado = Matches(nC, nL, false) + 1 >= 3;
                Swap(nC, nL);

                return resultado;
            }

            if (Check(Direction.Up)) return Direction.Up;
            if (Check(Direction.Down)) return Direction.Down;
            if (Check(Direction.Left)) return Direction.Left;
            if (Check(Direction.Right)) return Direction.Right;

            return null;
        }

        internal static bool Equivalent(BlockType a, BlockType b)
        {
            if (a != b)
                switch (a)
                {
                    case BlockType.Amarelo: return b == BlockType.BombaAmarelo || b == BlockType.MisselAmarelo;
                    case BlockType.Azul: return b == BlockType.BombaAzul || b == BlockType.MisselAzul;
                    case BlockType.Branco: return b == BlockType.BombaBranco || b == BlockType.MisselBranco;
                    case BlockType.Laranja: return b == BlockType.BombaLaranja || b == BlockType.MisselLaranja;
                    case BlockType.Verde: return b == BlockType.BombaVerde || b == BlockType.MisselVerde;
                    case BlockType.Vermelho: return b == BlockType.BombaVermelho || b == BlockType.MisselVermelho;
                    case BlockType.Violeta: return b == BlockType.BombaVioleta || b == BlockType.MisselVioleta;

                    case BlockType.BombaAmarelo: return b == BlockType.Amarelo || b == BlockType.MisselAmarelo;
                    case BlockType.BombaAzul: return b == BlockType.Azul || b == BlockType.MisselAzul;
                    case BlockType.BombaBranco: return b == BlockType.Branco || b == BlockType.MisselBranco;
                    case BlockType.BombaLaranja: return b == BlockType.Laranja || b == BlockType.MisselLaranja;
                    case BlockType.BombaVerde: return b == BlockType.Verde || b == BlockType.MisselVerde;
                    case BlockType.BombaVermelho: return b == BlockType.Vermelho || b == BlockType.MisselVermelho;
                    case BlockType.BombaVioleta: return b == BlockType.Violeta || b == BlockType.MisselVioleta;

                    case BlockType.MisselAmarelo: return b == BlockType.Amarelo || b == BlockType.BombaAmarelo;
                    case BlockType.MisselAzul: return b == BlockType.Azul || b == BlockType.BombaAzul;
                    case BlockType.MisselBranco: return b == BlockType.Branco || b == BlockType.BombaBranco;
                    case BlockType.MisselLaranja: return b == BlockType.Laranja || b == BlockType.BombaLaranja;
                    case BlockType.MisselVerde: return b == BlockType.Verde || b == BlockType.BombaVerde;
                    case BlockType.MisselVermelho: return b == BlockType.Vermelho || b == BlockType.BombaVermelho;
                    case BlockType.MisselVioleta: return b == BlockType.Violeta || b == BlockType.BombaVioleta;
                }

            return a == b;
        }

        [DebuggerStepThrough]
        private static Plane? GetPlane(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return Plane.Vertical;
                case Direction.Down: return Plane.Vertical;
                case Direction.Left: return Plane.Horizontal;
                case Direction.Right: return Plane.Horizontal;
                default: throw new Exception();
            }
        }

        [DebuggerStepThrough]
        private static Direction? Invert(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return Direction.Down;
                case Direction.Down: return Direction.Up;
                case Direction.Left: return Direction.Right;
                case Direction.Right: return Direction.Left;
                default: throw new Exception();
            }
        }

        private static IEnumerable<KeyValuePair<Direction, (int x, int y)>> TransformationInPlane(Plane? plane, Direction? exclusion)
        {
            foreach (var item in Transform)
            {
                if (item.Key == exclusion)
                    continue;

                if (plane.HasValue && GetPlane(item.Key) != plane)
                    continue;

                yield return item;
            }
        }
    }
}
