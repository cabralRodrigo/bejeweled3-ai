using System.Collections.Generic;
using System.Drawing;

namespace Bejeweled3AI.Common
{
    public static class GridLocator
    {
        private static readonly Dictionary<GameMode, Point> points = new Dictionary<GameMode, Point>
        {
            { GameMode.Zen, new Point(270, 67) },
            { GameMode.DiamondMine, new Point(250, 92) },
            { GameMode.Butterflies, new Point(265, 92) }
        };

        public static Point LocateGrid(GameMode gameMode)
        {
            return points[gameMode];
        }
    }
}