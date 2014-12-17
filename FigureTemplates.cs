using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1010
{
    public class FigureTemplates
    {
        private List<int[][]> templates;
        private Random random;

        public FigureTemplates()
        {
            random = new Random();
            templates = new List<int[][]>();
            CreateTemplates();            
        }
                
        public int[][] ChooseRandomTemplate()
        {
            return templates[random.Next(0, templates.Count)];
        }

        private void CreateTemplates()
        {
            int[][] a = new int[5][];

            a[0] = new int[] { 1 };
            a[1] = new int[] { 1 };
            a[2] = new int[] { 1 };
            a[3] = new int[] { 1 };
            a[4] = new int[] { 1 };
            templates.Add(a);

            a = new int[1][];
            a[0] = new int[] { 1, 1, 1, 1, 1 };

            a = new int[1][];
            a[0] = new int[] { 1, 1 };
            templates.Add(a);

            a = new int[2][];
            a[0] = new int[] { 1 };
            a[1] = new int[] { 1 };
            templates.Add(a);

            a = new int[1][];
            a[0] = new int[] { 1, 1, 1 };
            templates.Add(a);

            a = new int[3][];
            a[0] = new int[] { 1 };
            a[1] = new int[] { 1 };
            a[2] = new int[] { 1 };
            templates.Add(a);

            a = new int[4][];
            a[0] = new int[] { 1 };
            a[1] = new int[] { 1 };
            a[2] = new int[] { 1 };
            a[3] = new int[] { 1 };
            templates.Add(a);

            a = new int[1][];
            a[0] = new int[] { 1, 1, 1, 1 };
            templates.Add(a);

            a = new int[2][];
            a[0] = new int[] { 1, 1 };
            a[1] = new int[] { 1, 0 };
            templates.Add(a);

            a = new int[2][];
            a[0] = new int[] { 1, 1 };
            a[1] = new int[] { 0, 1 };
            templates.Add(a);

            a = new int[2][];
            a[0] = new int[] { 0, 1 };
            a[1] = new int[] { 1, 1 };
            templates.Add(a);

            a = new int[2][];
            a[0] = new int[] { 1, 0 };
            a[1] = new int[] { 1, 1 };
            templates.Add(a);

            a = new int[3][];
            a[0] = new int[] { 1, 0, 0 };
            a[1] = new int[] { 1, 0, 0 };
            a[2] = new int[] { 1, 1, 1 };
            templates.Add(a);

            a = new int[3][];
            a[0] = new int[] { 0, 0, 1 };
            a[1] = new int[] { 0, 0, 1 };
            a[2] = new int[] { 1, 1, 1 };
            templates.Add(a);

            a = new int[3][];
            a[0] = new int[] { 1, 1, 1 };
            a[1] = new int[] { 0, 0, 1 };
            a[2] = new int[] { 0, 0, 1 };
            templates.Add(a);

            a = new int[3][];
            a[0] = new int[] { 1, 1, 1 };
            a[1] = new int[] { 1, 0, 0 };
            a[2] = new int[] { 1, 0, 0 };
            templates.Add(a);

            a = new int[1][];
            a[0] = new int[] { 1 };
            templates.Add(a);

            a = new int[3][];
            a[0] = new int[] { 1, 1, 1 };
            a[1] = new int[] { 1, 1, 1 };
            a[2] = new int[] { 1, 1, 1 };
            templates.Add(a);

            a = new int[2][];
            a[0] = new int[] { 1, 1 };
            a[1] = new int[] { 1, 1 };
            templates.Add(a);
        }
    }
}
