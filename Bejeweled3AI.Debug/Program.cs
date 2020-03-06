using Bejeweled3AI.Common.Template;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Bejeweled3AI.Debug
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var templates = Directory.GetFiles(@"G:\Desktop\tt", "*.json").Select(s =>
            {
                var json = File.ReadAllText(s);
                return JsonConvert.DeserializeObject<BlockTemplate>(json);
            });

            var cores = templates.Select(s => s.Colors).SelectMany(s => s).ToList();

            int blockWidth = 64;
            int blockHeight = 64;
            int blocksPerRow = 64;

            using (var output = new Bitmap(blockWidth * blocksPerRow, blockHeight * (cores.Count / blocksPerRow), PixelFormat.Format32bppArgb))
            {
                var column = 0;
                var row = 0;

                using (var g = Graphics.FromImage(output))
                {
                    g.FillRectangle(new SolidBrush(Color.Transparent), 0, 0, output.Width, output.Height);

                    foreach (var cor in cores)
                    {
                        if (column >= blocksPerRow)
                        {
                            column = 0;
                            row++;
                        }

                        var rec = new Rectangle(column * blockWidth, row * blockHeight, blockWidth, blockHeight);
                        g.FillRectangle(new SolidBrush(cor), rec);

                        column++;
                        Console.WriteLine(cor);
                    }
                }

                output.Save(@"G:\output.png");
            }
        }
    }
}
