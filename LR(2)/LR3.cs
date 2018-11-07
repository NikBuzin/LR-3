using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_2_
{
    public partial class LR3 : Form
    {
        Rectangle R;
        const int n = 4;
        int count = n;
        PointF[] p1 = new PointF[n];
        PointF[] p2 = new PointF[n];
        bool fullp1 = false, fullp2 = false;
        Bitmap Bmp;
        byte flFunc = 0;
        double coeff = 1;
        Pen myPen;
        bool drawing = false, dr = false;
        Logic G = new Logic();
        MouseEventArgs e0;
        Graphics g;
        public LR3()
        {
            InitializeComponent();
            myPen = new Pen(Color.Black, 1);
            g = CreateGraphics();
        }

        public void MyDraw(Graphics g)
        {
            Bmp = new Bitmap(R.Width, R.Height);
            G.Draw(Bmp, g, ClientRectangle, flFunc, p1, p2, dr);
        }

        private void LR3_Paint(object sender, PaintEventArgs e)
        {
            R = e.ClipRectangle;
            MyDraw(g);
        }

        private void LR3_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                double dx = G.XX(e.X) - G.XX(e0.X);
                double dy = G.YY(e.Y) - G.YY(e0.Y);
                e0 = e;
                G.x1 -= dx; G.y1 -= dy;
                G.x2 -= dx; G.y2 -= dy;
                MyDraw(g);
            }
        }

        private void LR3_Resize(object sender, EventArgs e)
        {
            MyDraw(g);
        }

        private void LR3_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            e0 = e;
        }

        private void LR3_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void LR3_Load(object sender, EventArgs e)
        {
            MouseWheel += new MouseEventHandler(LR3_MouseWheel);
        }

        void LR3_MouseWheel(object sender, MouseEventArgs e)
        {
            double x = G.XX(e.X);
            double y = G.YY(e.Y);
            if (e.Delta < 0)
                coeff = 1.5;
            else
                coeff = 0.5;
            G.x1 = x - (x - G.x1) * coeff;
            G.x2 = x + (G.x2 - x) * coeff;
            G.y1 = y - (y - G.y1) * coeff;
            G.y2 = y + (G.y2 - y) * coeff;
            MyDraw(g);
        }

        private void LR3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dr = true;
            MyDraw(g);
            dr = false;
        }

        private void LR3_MouseClick(object sender, MouseEventArgs e)
        {
            g.DrawRectangle(myPen, e.Location.X, e.Location.Y, 2, 2);
            if (!fullp1)
            {
                if (count > 0)
                {
                    p1[n - count] = new PointF((float)(G.XX(e.Location.X)), (float)G.YY(e.Location.Y));
                    count--;
                }
                if (count == 0)
                {
                    fullp1 = true;                    
                    count = n;
                }
            }
            else
           if (!fullp2)
            {
                if (count > 0)
                {
                    p2[n - count] = new PointF((float)(G.XX(e.Location.X)), (float)G.YY(e.Location.Y));                   
                    count--;
                }
                if (count == 0)
                {
                    fullp2 = true;                    
                    count = n;                    
                }
            }
            else MyDraw(g);

        }
    }
}
