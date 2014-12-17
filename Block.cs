using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace _1010
{
    public class Block : Cell
    {
        public Block(int row, int column, Color color)
            :base(row,column,color)
        {

        }

        public Color SetColor(Color color)
        {
            this.color = color;
            return this.color;
        }

        public void SetLocation(int col, int row)
        {
            this.column = col;
            this.row = row;
        }
    }
}
