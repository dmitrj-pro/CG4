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

        private Graphics G;

        private int Mode;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            G = Graphics.FromImage(pictureBox1.Image);
            G.Clear(Color.Bisque);
            PlotAxes();
            tabPage2.Enabled = false;
            tabPage3.Enabled = false;
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
            G.DrawLine(pen, p1, p2);
            p1.X = 0;
            p1.Y = pictureBox1.Height / 2;
            p2.X = pictureBox1.Width;
            p2.Y = pictureBox1.Height / 2;
            G.DrawLine(pen, p1, p2);
        }

        Point ToValidPoint(int x, int y)
        {
            return new Point(x + pictureBox1.Width / 2, -1 * y + pictureBox1.Height / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Смещение"); //0
            comboBox2.Items.Add("Поворот"); //1
            comboBox2.Items.Add("Масштаб"); //2
            if(Mode == 0)
            {
                comboBox2.Items.Add("Поиск точки пересечения"); //3
            }
            tabPage2.Enabled = true;
            tabPage3.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (comboBox1.SelectedIndex == 0)
            {
                Mode = 0;
            }
            else
            {
                Mode = 1;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            G = Graphics.FromImage(pictureBox1.Image);
            G.Clear(Color.Bisque);
            PlotAxes();
            comboBox1.SelectedItem = null;
            button1.Enabled = false;
            tabPage2.Enabled = false;
            tabPage3.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
