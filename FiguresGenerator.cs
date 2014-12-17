using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _1010
{
    public class FiguresGenerator
    {
        private FigureTemplates templates;
        private Random random;

        public FiguresGenerator()
        {
            this.templates = new FigureTemplates();
            this.random = new Random();
        }

        private Color GetRandomColor()
        {
            var values = Enum.GetValues(typeof(Colors));
            string colorString = values.GetValue(random.Next(values.Length)).ToString();
            return Color.FromName(colorString);
        }

        public Figure GenerateFigure()
        {
            return new Figure(templates.ChooseRandomTemplate(), GetRandomColor()) ;
        }
    }
}
