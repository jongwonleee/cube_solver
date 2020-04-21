using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xycollecter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Focus();
        }
        int[] x = new int[300];
        int[] y = new int[300];
        private void button2_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = img;
                pictureBox1.Size = img.Size;
                this.Width = img.Width + 140;
                this.Height = img.Height + 134;
                listBox1.Height = img.Height - 120;
                textBox1.Width = this.Width - 29;   
            }
            button1.Focus();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string str = e.X + " , " + e.Y;
            listBox1.Items.Add(str);
            x[listBox1.Items.Count - 1] = e.X;
            y[listBox1.Items.Count - 1] = e.Y;
            button1.Focus();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            button1.Focus();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            string str = e.X + " , " + e.Y;
            label1.Text = str;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C) listBox1.Items.Clear();
            else if (e.KeyCode == Keys.X) listBox1.Items.RemoveAt(listBox1.Items.Count-1);
            if(e.KeyCode == Keys.Space)
            {
                string str = "xy[0] = " + equation(x[0], x[1],x[2]);
                textBox1.Text = str + "\n";
                str = "xy[1] = " + equation(y[0], y[1],y[2]);
                textBox1.AppendText(str + "\n");
                textBox1.AppendText(pts());
            }        
        }
        string pts()
        {
            string temp;
            string x1 = "", x2 = "", y1 = "", y2 = "";
            if((x[1] - x[0])>0) x1 =" + " +(x[1] - x[0]).ToString();
            else  x1 =(x[1] - x[0]).ToString();
            if((x[2] - x[0])>0) x2 =" + " +(x[2] - x[0]).ToString();
            else  x2 =(x[2] - x[0]).ToString();
            if((y[1] - y[0])>0) y1 =" + " +(y[1] - y[0]).ToString();
            else  y1 =(y[1] - y[0]).ToString();
            if((y[2] - y[0])>0) y2 =" + " +(y[2] - y[0]).ToString();
            else  y2 =(y[2] - y[0]).ToString();
            temp = "pt[1] = new Point( x" + x1 + ", y" + y1 + ");"+" \n "+"pt[2] = new Point( x" + x2 + ", y" + y2 + ");";
            return temp;
        }
        string equation (int num1,int num2,int num3)
        {
            string temp;
            int a, b,c;
            a = num2 - num1;
            b = num1;
            c = num3 - num1;
            temp = a.ToString() + " * i + " + c.ToString() + " * j + " + b.ToString() + ";" ;
            return temp;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Focus();
        }
    }
}
