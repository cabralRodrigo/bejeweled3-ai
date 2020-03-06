using System.Collections.Generic;
using System.Drawing;

namespace Bejeweled3AI.Common.Template
{
    public class BlockTemplate
    {
        public BlockType BlockType { get; }
        public List<Color> Colors { get; }

        public BlockTemplate(BlockType blockType)
        {
            this.BlockType = blockType;
            this.Colors = new List<Color>();
        }

        public bool AdicionarCor(Color color)
        {
            if (!this.Colors.Contains(color))
            {
                this.Colors.Add(color);
                return true;
            }
            else
                return false;
        }
    }
}