using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _1010
{
    public class GameController
    {
        Control owner;
        Point startPoint;
        Grid mainGrid;
        Grid newFiguresGrid;
        List<Figure> newFigures;
        FiguresGenerator generator;

        public Point Position { get { return startPoint; } }

        public GameController(Object owner)
        {
            this.newFigures = new List<Figure>();
            this.generator = new FiguresGenerator();

            this.owner = ((Control)owner);
            this.owner.Paint += new PaintEventHandler(this.owner_Paint);
        }

        private void owner_Paint(Object Sender, PaintEventArgs e)
        {
            if (mainGrid != null)
            {
                mainGrid.Draw(e.Graphics);
            }

            if (newFiguresGrid != null)
            {
                newFiguresGrid.Draw(e.Graphics);
            }
        }

        public void CreateGrids(Point startPoint)
        {
            this.startPoint = startPoint;

            mainGrid = new Grid(10, 10, 30, 2, Color.Gray, Color.Gray);
            mainGrid.Place(owner, new Point(startPoint.X, startPoint.Y));
            owner.Width = mainGrid.Position.X * 2 + mainGrid.PixelSize.Width;

            newFiguresGrid = new Grid(19, 7, 13, 2, Color.Gray, owner.BackColor);
            newFiguresGrid.Place(owner, new Point(mainGrid.Position.X + mainGrid.PixelSize.Width / 2 - newFiguresGrid.PixelSize.Width / 2,
                                                    mainGrid.Position.Y + mainGrid.PixelSize.Height + 30)
                                );


            //this.Invalidate();
        }

        private void DrawNewFiguresOnGrid()
        {
            newFiguresGrid.NullGrid();
            newFigures = new List<Figure>();
            
            for (int i = 0; i < 3; i++)
            {
                newFigures.Add(generator.GenerateFigure());
            }

            int partWidth = (newFiguresGrid.Width - 4) / 3;
            int partHeight = newFiguresGrid.Height - 2;

            foreach (var f in newFigures)
            {
                int x = (partWidth / 2 - f.Width / 2) + (newFigures.IndexOf(f) * partHeight) + newFigures.IndexOf(f) + 1;
                int y = (partHeight / 2 - f.Height / 2) + 1;
                newFiguresGrid.AddFigure(f, x, y);
            }
        }

        public void Start()
        {
            DrawNewFiguresOnGrid();
            
            owner.Invalidate();
        }
    }
}
