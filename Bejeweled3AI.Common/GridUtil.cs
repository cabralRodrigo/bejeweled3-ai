using System.Drawing;
using static Bejeweled3AI.Common.Const;

namespace Bejeweled3AI.Common
{
    public static class GridUtil
    {
        internal static readonly Rectangle RecTemplate = new Rectangle(x: 26, y: 19, width: 13, height: 29);

        public static Bitmap GetGridFromScreeshot(Bitmap screenshot, GameMode gameMode)
        {
            var pos = GridLocator.LocateGrid(gameMode);
            return Crop(screenshot, new Rectangle(pos.X, pos.Y, GridWidth, GridHeight));
        }

        public static Bitmap GetBlockFromScreenshot(Bitmap screenshot, GameMode gameMode, int coluna, int linha)
        {
            var pos = GridLocator.LocateGrid(gameMode);
            return Crop(screenshot, new Rectangle(pos.X + (BlockWidth * coluna), pos.Y + (BlockHeight * linha), BlockWidth, BlockHeight));
        }

        public static Bitmap GetTemplateCropFromBlock(Bitmap block)
        {
            return Crop(block, RecTemplate);
        }

        private static Bitmap Crop(Bitmap source, Rectangle rectangle)
        {
            var output = new Bitmap(rectangle.Width, rectangle.Height);
            using (var g = Graphics.FromImage(output))
                g.DrawImage(source, new Rectangle(0, 0, output.Width, output.Height), rectangle, GraphicsUnit.Pixel);

            return output;
        }
    }
}