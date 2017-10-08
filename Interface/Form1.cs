using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class Form1 : Form
    {

        private Graphics g;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.Bisque);
            PlotAxes();
            //Pen pen = new Pen(Color.Blue);
            //g.DrawRectangle(pen, ToValidPoint(-10, -10).X, ToValidPoint(-10, -10).Y, 10, 10);
        }

        private void PlotAxes()
        {
            Pen pen = new Pen(Color.Black);
            Point p1 = new Point();
            Point p2 = new Point();
            p1.X = pictureBox1.Width / 2;
            p1.Y = 0;
            p2.X = pictureBox1.Width / 2;
            p2.Y = pictureBox1.Height;
            g.DrawLine(pen, p1, p2);
            p1.X = 0;
            p1.Y = pictureBox1.Height / 2;
            p2.X = pictureBox1.Width;
            p2.Y = pictureBox1.Height / 2;
            g.DrawLine(pen, p1, p2);
        }

        Point ToValidPoint(int x, int y)
        {
            return new Point(x + pictureBox1.Width / 2, -1 * y + pictureBox1.Height / 2);
        }

        private void clear_Click(object sender, EventArgs e)
        {

        }
    }
}
