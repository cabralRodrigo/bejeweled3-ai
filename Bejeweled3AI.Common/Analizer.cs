using Bejeweled3AI.Common.Template;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static Bejeweled3AI.Common.Const;
using static Bejeweled3AI.Common.GridUtil;

namespace Bejeweled3AI.Common
{
    public class Analizer
    {
        public static BlockType[,] AnalizeGridImage(List<BlockTemplate> templates, Bitmap gridImage)
        {
            var grid = new BlockType[TotalColunas, TotalLinhas];

            for (var c = 0; c < TotalColunas; c++)
                for (var l = 0; l < TotalLinhas; l++)
                {
                    var rec = new Rectangle(RecTemplate.X + (c * BlockWidth), RecTemplate.Y + (l * BlockHeight), RecTemplate.Width, RecTemplate.Height);
                    var avgColor = ColorUtil.AvgColor(gridImage, rec);

                    var query = (from t in templates
                                 from color in t.Colors
                                 where color == avgColor
                                 select (BlockType?)t.BlockType).ToArray();

                    var type = BlockType.Desconhecido;
                    if (query.Length == 1)
                        type = query[0].Value;
                    else if (query.Length == 2)
                    {
                        var a = query[0].Value;
                        var b = query[1].Value;
                        if (Mover.Equivalent(a, b))
                        {
                            if (a > b)
                                type = a;
                            else
                                type = b;
                        }
                        else
                            throw new Exception();
                    }
                   

                    grid[c, l] = type;
                }

            return grid;
        }
    }
}