using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Bejeweled3AI.Common
{
    public static class ColorUtil
    {
        public static Color AvgColor(Bitmap source) => AvgColor(source, new Rectangle(0, 0, source.Width, source.Height));

        public static Color AvgColor(Bitmap source, Rectangle rec)
        {
            int mut;

            switch (source.PixelFormat)
            {
                case PixelFormat.Format24bppRgb:
                    mut = 3;
                    break;
                case PixelFormat.Format32bppRgb:
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                    mut = 4;
                    break;
                default:
                    throw new Exception();
            }

            var data = source.LockBits(rec, ImageLockMode.ReadOnly, source.PixelFormat);
            var stride = data.Stride;
            var scan0 = data.Scan0;
            var totals = new long[] { 0, 0, 0 };

            unsafe
            {
                var pixel = (byte*)(void*)scan0;

                for (var y = 0; y < rec.Height; y++)
                    for (var x = 0; x < rec.Width; x++)
                        for (var color = 0; color < 3; color++)
                        {
                            var idx = (y * stride) + x * mut + color;

                            totals[color] += pixel[idx];
                        }
            }

            source.UnlockBits(data);

            var B = (int)(totals[0] / (rec.Width * rec.Height));
            var G = (int)(totals[1] / (rec.Width * rec.Height));
            var R = (int)(totals[2] / (rec.Width * rec.Height));

            return Color.FromArgb(R, G, B);
        }

        public static Color FromBlockType(BlockType blockType)
        {
            switch (blockType)
            {
                case BlockType.MisselAmarelo:
                case BlockType.BombaAmarelo:
                case BlockType.Amarelo: return Color.Yellow;

                case BlockType.MisselAzul:
                case BlockType.BombaAzul:
                case BlockType.Azul: return Color.Blue;

                case BlockType.MisselBranco:
                case BlockType.BombaBranco:
                case BlockType.Branco: return Color.White;

                case BlockType.MisselLaranja:
                case BlockType.BombaLaranja:
                case BlockType.Laranja: return Color.Orange;

                case BlockType.MisselVerde:
                case BlockType.BombaVerde:
                case BlockType.Verde: return Color.Green;

                case BlockType.MisselVermelho:
                case BlockType.BombaVermelho:
                case BlockType.Vermelho: return Color.Red;

                case BlockType.MisselVioleta:
                case BlockType.BombaVioleta:

                case BlockType.Violeta: return Color.Violet;
                case BlockType.Matrix: return Color.Black;
                case BlockType.Desconhecido: return Color.Coral;
                default: throw new Exception();
            }
        }
    }
}