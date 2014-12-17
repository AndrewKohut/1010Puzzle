using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1010
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Form dragging

        private Point mouseOffset;
        private bool isMouseDown = false;


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X;
                yOffset = -e.Y;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        #endregion

        GameController game;
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //CreateGrids();
            game = new GameController(this);
            game.CreateGrids(new Point(20, panel1.Height + 5));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            /*if (mainGrid != null)
            {
                mainGrid.Draw(e.Graphics);
            }

            if (newObjectsGrid != null)
            {
                newObjectsGrid.Draw(e.Graphics);
            }*/
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            game.Start();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Application.Exit();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }



    }
}
