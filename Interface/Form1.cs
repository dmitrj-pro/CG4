﻿using System;
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

        private int CurrPanel;

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
            panel2.Controls.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox2.Items.Add("Смещение"); //0
            comboBox2.Items.Add("Поворот"); //1
            comboBox2.Items.Add("Масштаб"); //2
            if(Mode == 0)
            {
                comboBox2.Items.Add("Поиск точки пересечения"); //3
            }
            comboBox2.SelectedIndex = 0;

            if (Mode == 0)
            {
                comboBox3.Items.Add("Положение точки"); //0
            }
            else
            {
                comboBox3.Items.Add("Принадлежность многоугольнику"); //0

            }
            comboBox3.SelectedIndex = 0;

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
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            panel1.Controls.Clear();
            panel2.Controls.Clear();
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
            if (comboBox2.SelectedIndex == 0)
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

            if (comboBox2.SelectedIndex == 2)
            {
                Label l2 = new Label();
                l2.Text = "Масштаб: ";
                l2.Location = new Point(10, 5);
                l2.Size = new Size(120, 20);
                l2.TextAlign = ContentAlignment.MiddleCenter;
                panel1.Controls.Add(l2);

                TextBox t2 = new TextBox();
                t2.Name = "t2";
                t2.Location = new Point(150, 5);
                t2.Size = new Size(50, 20);
                panel1.Controls.Add(t2);


                Button b2 = new Button();
                b2.Size = new Size(120, 23);
                b2.Location = new Point(54, 346);
                b2.Text = "Применить";
                b2.Click += B2_Click;
                panel1.Controls.Add(b2);
            }
            if(Mode == 0)
            {
                if (comboBox2.SelectedIndex == 3)
                {
                    Label l31 = new Label();
                    l31.Text = "X1: ";
                    l31.Name = "l31";
                    l31.Size = new Size(50, 20);
                    l31.TextAlign = ContentAlignment.MiddleCenter;
                    l31.Location = new Point(10, 5);
                    panel1.Controls.Add(l31);

                    Label l32 = new Label();
                    l32.Text = "Y1: ";
                    l32.Name = "l32";
                    l32.Size = new Size(50, 20);
                    l32.TextAlign = ContentAlignment.MiddleCenter;
                    l32.Location = new Point(120, 5);
                    panel1.Controls.Add(l32);

                    Label l33 = new Label();
                    l33.Text = "X2: ";
                    l33.Name = "l33";
                    l33.Size = new Size(50, 20);
                    l33.TextAlign = ContentAlignment.MiddleCenter;
                    l33.Location = new Point(10, 40);
                    panel1.Controls.Add(l33);

                    Label l34 = new Label();
                    l34.Text = "Y2: ";
                    l34.Name = "l34";
                    l34.Size = new Size(50, 20);
                    l34.TextAlign = ContentAlignment.MiddleCenter;
                    l34.Location = new Point(120, 40);
                    panel1.Controls.Add(l34);

                    Label l35 = new Label();
                    l35.Text = "Результат: ";
                    l35.Name = "l35";
                    l35.Size = new Size(50, 20);
                    l35.TextAlign = ContentAlignment.MiddleCenter;
                    l35.Location = new Point(10, 60);
                    panel1.Controls.Add(l35);

                    Button b3 = new Button();
                    b3.Name = "b3";
                    b3.Size = new Size(120, 23);
                    b3.Location = new Point(54, 346);
                    b3.Text = "Применить";
                    b3.Click += B3_Click;
                    b3.Enabled = false;
                    panel1.Controls.Add(b3);
                }
            }
        }

        private void B3_Click(object sender, EventArgs e)
        {
            Label l31 = FindControl(panel1, "l31") as Label;
            Label l32 = FindControl(panel1, "l32") as Label;
            Label l33 = FindControl(panel1, "l33") as Label;
            Label l34 = FindControl(panel1, "l34") as Label;
            int x1;
            int y1;
            int x2;
            int y2;
            int.TryParse(l31.Text.Split(' ')[1], out x1);
            int.TryParse(l32.Text.Split(' ')[1], out y1);
            int.TryParse(l33.Text.Split(' ')[1], out x2);
            int.TryParse(l34.Text.Split(' ')[1], out y2);
            //Вот тут вызываем соответствующую функцию поиска пересечения двух ребер
            //todo
        }

        private void B2_Click(object sender, EventArgs e)
        {
            TextBox t2 = FindControl(panel1, "t2") as TextBox;
            int scale;
            int.TryParse(t2.Text, out scale);
            //Вот тут вызываем соответствующую функцию масштабирования
            //todo
        }

        private void Cb1_CheckedChanged(object sender, EventArgs e)
        {
            TextBox t1 = FindControl(panel1, "t1") as TextBox;
            t1.Enabled = !t1.Enabled;
            Button b1 = FindControl(panel1, "b1") as Button;
            if ((sender as CheckBox).Checked)
            {
                b1.Enabled = true;
                Label l11 = FindControl(panel1, "l11") as Label;
                Label l12 = FindControl(panel1, "l12") as Label;
                l11.Text = "X: ";
                l12.Text = "Y: ";
            }
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
            if (CurrPanel == 1)
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
                            if (e.Button == MouseButtons.Left)
                            {
                                l11.Text = "X: " + (ToValidPoint(e.X, e.Y).X - 500).ToString();
                                l12.Text = "Y: " + ToValidPoint(e.X, e.Y).Y.ToString();
                            }
                        }
                    }
                    else
                    {
                        Label l11 = FindControl(panel1, "l11") as Label;
                        Label l12 = FindControl(panel1, "l12") as Label;
                        Button b1 = FindControl(panel1, "b1") as Button;
                        b1.Enabled = true;
                        if (e.Button == MouseButtons.Left)
                        {
                            l11.Text = "X: " + (ToValidPoint(e.X, e.Y).X - 500).ToString();
                            l12.Text = "Y: " + ToValidPoint(e.X, e.Y).Y.ToString();
                        }
                    }
                }

                if (Mode == 0)
                {
                    if (comboBox2.SelectedIndex == 3)
                    {
                        Button b3 = FindControl(panel1, "b3") as Button;
                        Label l31 = FindControl(panel1, "l31") as Label;
                        Label l32 = FindControl(panel1, "l32") as Label;
                        Label l33 = FindControl(panel1, "l33") as Label;
                        Label l34 = FindControl(panel1, "l34") as Label;
                        if (e.Button == MouseButtons.Left)
                        {
                            l31.Text = "X1: " + (ToValidPoint(e.X, e.Y).X - 500).ToString();
                            l32.Text = "Y1: " + ToValidPoint(e.X, e.Y).Y.ToString();
                        }
                        if (e.Button == MouseButtons.Right)
                        {
                            l33.Text = "X2: " + (ToValidPoint(e.X, e.Y).X - 500).ToString();
                            l34.Text = "Y2: " + ToValidPoint(e.X, e.Y).Y.ToString();
                            b3.Enabled = true;
                        }
                    }
                }
            }
            if(CurrPanel == 2)
            {
                if (Mode == 1)
                {
                    if (comboBox3.SelectedIndex == 0)
                    {
                        Label l21 = FindControl(panel2, "l21") as Label;
                        Label l22 = FindControl(panel2, "l22") as Label;
                        Button b5 = FindControl(panel2, "b5") as Button;
                        if (e.Button == MouseButtons.Left)
                        {
                            l21.Text = "X: " + (ToValidPoint(e.X, e.Y).X - 500).ToString();
                            l22.Text = "Y: " + ToValidPoint(e.X, e.Y).Y.ToString();
                        }
                        b5.Enabled = true;
                    }
                }
                else
                {
                    if (comboBox3.SelectedIndex == 0)
                    {
                        Label l11 = FindControl(panel2, "l11") as Label;
                        Label l12 = FindControl(panel2, "l12") as Label;
                        Button b4 = FindControl(panel2, "b4") as Button;
                        {
                            l11.Text = "X: " + (ToValidPoint(e.X, e.Y).X - 500).ToString();
                            l12.Text = "Y: " + ToValidPoint(e.X, e.Y).Y.ToString();
                        }
                        b4.Enabled = true;
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            if(Mode == 0)
            {
                Label l11 = new Label();
                l11.Text = "X: ";
                l11.Name = "l11";
                l11.Size = new Size(50, 20);
                l11.TextAlign = ContentAlignment.MiddleCenter;
                l11.Location = new Point(10, 5);
                panel2.Controls.Add(l11);

                Label l12 = new Label();
                l12.Text = "Y: ";
                l12.Name = "l12";
                l12.Size = new Size(50, 20);
                l12.TextAlign = ContentAlignment.MiddleCenter;
                l12.Location = new Point(120, 5);
                panel2.Controls.Add(l12);

                Label l13 = new Label();
                l13.Text = "Результат: ";
                l13.Name = "l13";
                l13.Size = new Size(100, 20);
                l13.TextAlign = ContentAlignment.MiddleCenter;
                l13.Location = new Point(10, 40);
                panel2.Controls.Add(l13);

                Button b4 = new Button();
                b4.Name = "b4";
                b4.Size = new Size(120, 23);
                b4.Location = new Point(54, 346);
                b4.Text = "Проверить";
                b4.Click += B4_Click;
                b4.Enabled = false;
                panel2.Controls.Add(b4);
            }
            if(Mode == 1)
            {
                Label l21 = new Label();
                l21.Text = "X: ";
                l21.Name = "l21";
                l21.Size = new Size(50, 20);
                l21.TextAlign = ContentAlignment.MiddleCenter;
                l21.Location = new Point(10, 5);
                panel2.Controls.Add(l21);

                Label l22 = new Label();
                l22.Text = "Y: ";
                l22.Name = "l22";
                l22.Size = new Size(50, 20);
                l22.TextAlign = ContentAlignment.MiddleCenter;
                l22.Location = new Point(120, 5);
                panel2.Controls.Add(l22);

                Label l23 = new Label();
                l23.Text = "Результат: ";
                l23.Name = "l23";
                l23.Size = new Size(100, 20);
                l23.TextAlign = ContentAlignment.MiddleCenter;
                l23.Location = new Point(10, 40);
                panel2.Controls.Add(l23);

                Button b5 = new Button();
                b5.Name = "b5";
                b5.Size = new Size(120, 23);
                b5.Location = new Point(54, 346);
                b5.Text = "Проверить";
                b5.Click += B5_Click;
                b5.Enabled = false;
                panel2.Controls.Add(b5);
            }
        }

        private void B5_Click(object sender, EventArgs e)
        {
            
        }

        private void B4_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrPanel = tabControl1.SelectedIndex;
        }
    }
}
