using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace graphicsengine3d
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Graphics g;
        public Pen pen0 = new Pen(Color.Black);
        public Font font0;
        public Brush brush0 = new SolidBrush(Color.Black);
        public world3d theworld3d = new world3d();

        public triangle3d t = new triangle3d();
        public triangle3d t1 = new triangle3d();
      
        

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            font0 = this.Font;
           
            dot3d tmp = new dot3d();
            tmp.x = 10;
            tmp.y = 20;
            tmp.z = 34;
            t.p1 = tmp;
            tmp.x = 203;
            tmp.y = 40;
            tmp.z = 24;
            t.p2 = tmp;
            tmp.x = 17;
            tmp.y = 10;
            tmp.z = 14;
            t.p3 = tmp;

            dot3d tmp1 = new dot3d();
            tmp1.x = 20;
            tmp1.y = 20;
            tmp1.z = 34;
            t1.p1 = tmp;
            tmp1.x = 21;
            tmp1.y = 31;
            tmp1.z = 21;
            t1.p2 = tmp;
            tmp1.x = 53;
            tmp1.y = 23;
            tmp1.z = 53;
            t1.p3 = tmp;


            
 

        }

        public void calculate(ref dot3d d)
        {



            d.x += (float)((d.x * Math.Sin(theworld3d.unghiteta / (180 / Math.PI)) * Math.Cos(theworld3d.unghifi / (180 / Math.PI))));
            d.y += (float)((d.y * Math.Sin(theworld3d.unghiteta / (180 / Math.PI)) * Math.Sin(theworld3d.unghifi / (180 / Math.PI))));
            d.z += (float)((d.z * Math.Sin(theworld3d.unghiteta / (180 / Math.PI))));

               
           
        }

        public void drawlines3d(dot3d d1, dot3d d2)
        {
            try
            {
                g.DrawLine(pen0, d1.x, d1.y, d2.x, d2.y);
                g.DrawLine(pen0, d1.x, d1.z, d2.x, d2.z);
                g.DrawLine(pen0, d1.z, d1.y, d2.z, d2.y);

                g.DrawLine(pen0, d1.x, d1.y, 550, 450);
                g.DrawLine(pen0, d1.x, d1.z, 550, 450);
                g.DrawLine(pen0, d1.z, d1.y, 550, 450);

                g.DrawLine(pen0, d2.x, d2.y, 550, 450);
                g.DrawLine(pen0, d2.x, d2.z, 550, 450);
                g.DrawLine(pen0, d2.z, d2.y, 550, 450);

            }
            catch { }

        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
           
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            g.Clear(BackColor);
            theworld3d.unghifi = e.X/100;
            theworld3d.unghiteta = e.Y/100;

            calculate(ref t.p1);
            calculate(ref t.p2);
            calculate(ref t.p3);

            calculate(ref t1.p1);
            calculate(ref t1.p2);
            calculate(ref t1.p3);

            drawlines3d(t1.p1, t.p2);
        }

    }
}
