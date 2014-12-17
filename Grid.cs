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
    public class Grid
    {
        private int width, height, cellSize, separatorSize;
        private Color backgroundColor, cellColor;
        private List<Cell> cells;
        private Object owner;
        private Point nullPosition;
        private Graphics ownerGraphics;
        private Size size;
        private List<Figure> figures;


        public Point Position { get { return nullPosition; } }
        public Size PixelSize { get { return size; } }
        public int Width { get { return width; } }
        public int Height { get { return height; } }


        public Grid(int width, int height, int cellSize, int separatorSize, Color backgroundColor, Color cellColor)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.separatorSize = separatorSize;
            this.backgroundColor = backgroundColor;
            this.cellColor = cellColor;

            this.figures = new List<Figure>();
            this.size = new Size(cellSize * width + separatorSize * width,
                                cellSize * height + separatorSize * height);
            CreateCells();
        }

        private void CreateCells()
        {
            cells = new List<Cell>();
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    cells.Add(new GridCell(i, j));
                }
            }
        }

        public void NullGrid()
        {
            CreateCells();
        }

        public void Place(Object owner, Point point)
        {
            this.owner = owner;
            this.ownerGraphics = ((Control)owner).CreateGraphics();
            this.backgroundColor = ((Control)owner).BackColor;
            this.nullPosition = point;
        }

        public void AddFigure(Figure figure, int col, int row)
        {
            figure.SetLocation(col, row);
            figures.Add(figure);
            
            foreach (var b in figure.Blocks)
            {
                cells[cells.IndexOf(cells.Where(c => c.Row == b.Row &&
                                                        c.Column == b.Column).First())] = b;
            }

        }

        public void Draw(Graphics gr)
        {
            ownerGraphics = gr;
            foreach (var cell in cells)
            {
                int x = nullPosition.X + cell.Column * this.cellSize + ((cell.Column > 0)? this.separatorSize * cell.Column:0);
                int y = nullPosition.Y + cell.Row * this.cellSize + ((cell.Row > 0) ? this.separatorSize * cell.Row : 0);
                GraphicsPath tempPath = new GraphicsPath();

                if (cell is GridCell)
                {
                    tempPath = cell.Draw(x, y, this.cellSize, this.cellSize, 3);
                    ownerGraphics.FillPath(new SolidBrush(this.cellColor), tempPath);
                }
                else
                {
                    tempPath = cell.Draw(x, y, this.cellSize, this.cellSize, 3);
                    ownerGraphics.FillPath(new SolidBrush(cell.Color), tempPath);
                }
                ownerGraphics.DrawPath(new Pen(this.cellColor), tempPath);
            }
        }
    }
}
