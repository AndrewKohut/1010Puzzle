using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1010
{
    public class Figure
    {
        private List<Block> blocks;

        private int height, widht;
        private Color color;
        private int row, col;

        public int Height { get { return height; } }
        public int Width { get { return widht; } }

        public Color Color { get { return color; } }
        public int Row { get { return row; } }
        public int Column { get { return col; } }


        public List<Block> Blocks { get { return blocks; } }


        public Figure(int[][] template, Color color)
        {
            this.color = color;
            this.height = template.Count();
            this.widht = template.First().Count();
            GenerateBlocs(template);
        }

        

        public void SetLocation(int col, int row)
        {
            this.col = col;
            this.row = row;

            foreach (var b in blocks)
                b.SetLocation(col + b.Column, row + b.Row);
        }

        private void GenerateBlocs(int[][] template)
        {
            blocks = new List<Block>();

            for (int i = 0; i < template.Count(); i++)
            {
                for (int j = 0; j < template[i].Count(); j++)
                {
                    blocks.Add(new Block(i, j, color));
                }
            }
        }
    }
}
