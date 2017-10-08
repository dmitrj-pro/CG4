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

        private Control FindControl(Control root, string name)
        {
            if (root.Name == name)
            {
                return root;
            }

            foreach (Control c in root.Controls)
            {
                Control t = FindControl(c, name);
                if (t != null)
                {
                    return t;
                }
            }

            return null;
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
            panel1.Controls.Clear();
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Смещение"); //0
            comboBox2.Items.Add("Поворот"); //1
            comboBox2.Items.Add("Масштаб"); //2
            if(Mode == 0)
            {
                comboBox2.Items.Add("Поиск точки пересечения"); //3
            }
            comboBox2.SelectedIndex = 0;
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
            panel1.Controls.Clear();
            button1.Enabled = false;
            tabPage2.Enabled = false;
            tabPage3.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            if(comboBox2.SelectedIndex == 0)
            { 
                Label l0x = new Label();
                l0x.Text = "Смещение по X: ";
                l0x.Location = new Point(10, 5);
                l0x.Size = new Size(120, 20);
                l0x.TextAlign = ContentAlignment.MiddleCenter;
                panel1.Controls.Add(l0x);

                TextBox t0x = new TextBox();
                t0x.Name = "t0x";
                t0x.Location = new Point(150, 5);
                t0x.Size = new Size(50, 20);
                panel1.Controls.Add(t0x);


                Label l0y = new Label();
                l0y.Text = "Смещение по Y: ";
                l0y.Location = new Point(10, 40);
                l0y.Size = new Size(120, 20);
                l0y.TextAlign = ContentAlignment.MiddleCenter;
                panel1.Controls.Add(l0y);

                TextBox t0y = new TextBox();
                t0y.Name = "t0y";
                t0y.Location = new Point(150, 40);
                t0y.Size = new Size(50, 20);
                panel1.Controls.Add(t0y);

                Button b0 = new Button();
                b0.Size = new Size(120, 23);
                b0.Location = new Point(54, 346);
                b0.Text = "Применить";
                b0.Click += B0_Click;
                panel1.Controls.Add(b0);
            }

            if (comboBox2.SelectedIndex == 1)
            { 
                Label l1 = new Label();
                l1.Text = "Угол поворота: ";
                l1.Size = new Size(120, 20);
                l1.TextAlign = ContentAlignment.MiddleCenter;

                TextBox t1 = new TextBox();
                t1.Name = "t1";
                t1.Size = new Size(50, 20);

                Button b1 = new Button();
                b1.Name = "b1";
                b1.Size = new Size(120, 23);
                b1.Text = "Применить";
                b1.Enabled = false;
                b1.Click += B1_Click;
                b1.Location = new Point(54, 346);

                Label l11 = new Label();
                l11.Text = "X: ";
                l11.Name = "l11";
                l11.Size = new Size(50, 20);
                l11.TextAlign = ContentAlignment.MiddleCenter;

                Label l12 = new Label();
                l12.Text = "Y: ";
                l12.Name = "l12";
                l12.Size = new Size(50, 20);
                l12.TextAlign = ContentAlignment.MiddleCenter;

                if (Mode == 0)
                {
                    CheckBox cb1 = new CheckBox();
                    cb1.Name = "cb1";
                    cb1.CheckedChanged += Cb1_CheckedChanged;
                    cb1.Text = "Воруг центра на 90°";
                    cb1.Size = new Size(150, 20);
                    cb1.Location = new Point(10, 5);
                    panel1.Controls.Add(cb1);

                    l1.Location = new Point(10, 40);

                    t1.Location = new Point(130, 40);

                    l11.Location = new Point(10, 80);

                    l12.Location = new Point(120, 80);

                }
                else
                {
                    l1.Location = new Point(10, 5);

                    t1.Location = new Point(130, 5);

                    l11.Location = new Point(10, 40);

                    l12.Location = new Point(120, 40);

                }

                panel1.Controls.Add(l1);
                panel1.Controls.Add(t1);
                panel1.Controls.Add(b1);
                panel1.Controls.Add(l11);
                panel1.Controls.Add(l12);
            }
        }

        private void Cb1_CheckedChanged(object sender, EventArgs e)
        {
            TextBox t1 = FindControl(panel1, "t1") as TextBox;
            t1.Enabled = !t1.Enabled;
            Button b1 = FindControl(panel1, "b1") as Button;
            if ((sender as CheckBox).Checked)
                b1.Enabled = true;
            else
                b1.Enabled = false;
        }

        private void B1_Click(object sender, EventArgs e)
        {
            Label l11 = FindControl(panel1, "l11") as Label;
            Label l12 = FindControl(panel1, "l12") as Label;
            TextBox t1 = FindControl(panel1, "t1") as TextBox;
            int x;
            int y;
            int angle;
            int.TryParse(t1.Text, out angle);
            int.TryParse(l11.Text.Split(' ')[1], out x);
            int.TryParse(l12.Text.Split(' ')[1], out y);

            //Вот тут вызываем соответствующую функцию поворота
            //todo
        }

        private void B0_Click(object sender, EventArgs e)
        {
            TextBox t0x = FindControl(panel1, "t0x") as TextBox;
            TextBox t0y = FindControl(panel1, "t0y") as TextBox;
            int x;
            int y;
            int.TryParse(t0x.Text, out x);
            int.TryParse(t0y.Text, out y);

            //Вот тут вызываем соответствующую функцию смещения
            //todo
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox2.SelectedIndex == 1)
            {

                if (FindControl(panel1, "cb1") != null)
                {
                    if (!(FindControl(panel1, "cb1") as CheckBox).Checked)
                    {
                        Label l11 = FindControl(panel1, "l11") as Label;
                        Label l12 = FindControl(panel1, "l12") as Label;
                        Button b1 = FindControl(panel1, "b1") as Button;
                        b1.Enabled = true;
                        l11.Text = "X: " + (ToValidPoint(e.X, e.Y).X - 500).ToString();
                        l12.Text = "Y: " + ToValidPoint(e.X, e.Y).Y.ToString();
                    }
                }
                else
                {
                    Label l11 = FindControl(panel1, "l11") as Label;
                    Label l12 = FindControl(panel1, "l12") as Label;
                    Button b1 = FindControl(panel1, "b1") as Button;
                    b1.Enabled = true;
                    l11.Text = "X: " + (ToValidPoint(e.X, e.Y).X - 500).ToString();
                    l12.Text = "Y: " + ToValidPoint(e.X, e.Y).Y.ToString();
                }
            }
        }
    }
}
