using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _1010
{
    public class Cell
    {
        protected int row, column;
        protected Color color;

        public Color Color { get { return color; } }
        public int Row { get { return row; } }
        public int Column { get { return column; } }

        public Cell(int row, int column, Color color)
        {
            this.row = row;
            this.column = column;
            this.color = color;
        }


        public GraphicsPath Draw(float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner
            gp.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner
            gp.CloseFigure();
            gp.FillMode = FillMode.Winding;

            return gp;
            /*g.FillPath(new SolidBrush(Color.Gray), gp);
            g.DrawPath(p, gp);
            gp.Dispose();*/
        }
    }
}
