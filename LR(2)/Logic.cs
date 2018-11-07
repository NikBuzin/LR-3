using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2_
{
    class Logic
    {
        static int I1 = 0, J1 = 0, I2, J2;
        public static Bitmap Bmp;
        public double x1 = -0.1, y1 = -1, x2 = 3.1, y2 = 16;

        public delegate int IJ(double x);

        public Pen MyPen1;
        public Pen MyPen2;

        public Logic()
        {
            MyPen1 = new Pen(Brushes.Black, 1);
            MyPen1.Color = Color.Black;
            MyPen2 = new Pen(Brushes.Black, 1);
            MyPen2.Color = Color.Black;
        }

        public int II(double x)
        {
            return I1 + (int)((x - x1) * (I2 - I1) / (x2 - x1));
        }

        public double XX(int I)
        {
            return x1 + (I - I1) * (x2 - x1) / (I2 - I1);
        }

        public int JJ(double y)
        {
            return J2 + (int)((y - y1) * (J1 - J2) / (y2 - y1));
        }

        public double YY(int J)
        {
            return y1 + (J - J2) * (y2 - y1) / (J1 - J2);
        }

        double HH(double a1, double a2)
        {
            double Result = 1;
            while (Math.Abs(a2 - a1) / Result < 1)
                Result /= 10.0;
            while (Math.Abs(a2 - a1) / Result >= 10)
                Result *= 10.0;
            if (Math.Abs(a2 - a1) / Result < 2.0)
                Result /= 5.0;
            if (Math.Abs(a2 - a1) / Result < 5.0)
                Result /= 2.0;
            return Result;
        }

        byte GetDigits(double dx)
        {
            byte Result;
            if (dx >= 5) Result = 0;
            else
                if (dx >= 0.5) Result = 1;
            else
                    if (dx >= 0.05) Result = 2;
            else
                        if (dx >= 0.005) Result = 3;
            else
                            if (dx >= 0.0005) Result = 4; else Result = 5;
            return Result;
        }

        Font aFont;

        void OX(IJ II, IJ JJ, Graphics g)
        {
            g.DrawLine(Pens.LightBlue, II(x1), JJ(0), II(x2), JJ(0));
            double h1 = HH(x1, x2);
            int k1 = (int)Math.Round(x1 / h1) - 1;
            int k2 = (int)Math.Round(x2 / h1);
            byte Digits = GetDigits(Math.Abs(x2 - x1));
            for (int i = k1; i <= k2; i++)
            {
                g.DrawLine(MyPen2, II(i * h1), JJ(0) - 7, II(i * h1), JJ(0) + 7);
                for (int j = 1; j <= 9; j++)
                    g.DrawLine(MyPen2, II(i * h1 + j * h1 / 10), JJ(0) - 3, II(i * h1 + j * h1 / 10), JJ(0) + 3);
                string s = Convert.ToString(Math.Round(h1 * i, Digits));
                g.DrawString(s, aFont, Brushes.Black, II(i * h1) - 5, JJ(0) - 13);
            }
        }

        void OY(IJ II, IJ JJ, Graphics g)
        {
            DrawLine(II(0), JJ(y1), II(0),JJ(y2), Color.Black);
            double h1 = HH(y1, y2); int k1 = (int)Math.Round(y1 / h1) - 1;
            int k2 = (int)Math.Round(y2 / h1);
            int Digits = GetDigits(Math.Abs(y2 - y1));
            for (int i = k1; i <= k2; i++)
            {
                DrawLine(II(0) - 7, JJ(i * h1), II(0) + 7, JJ(i * h1), Color.Black);
                for (int j = 1; j <= 9; j++)
                    DrawLine(II(0) - 3, JJ(i * h1 + j * h1 / 10), II(0) + 3, JJ(i * h1 + j * h1 / 10), Color.Black);
                string s = Convert.ToString(Math.Round(h1 * i, Digits));
                g.DrawString(s, aFont, Brushes.Black, II(0) + 5, JJ(i * h1) - 5);
            }
        }

        public static void DrawLine(double x1, double y1, double x2, double y2, Color color)
        {
            double dx = (x2 > x1) ? (x2 - x1) : (x1 - x2);
            double dy = (y2 > y1) ? (y2 - y1) : (y1 - y2);

            double sx = (x2 >= x1) ? (1) : (-1);
            double sy = (y2 >= y1) ? (1) : (-1);

            if (dy < dx)
            {
                double d = ((int)dy << 1) - dx; //(dy « 1) - dx; 
                double d1 = (int)dy << 1;
                double d2 = ((int)dy - (int)dx) << 1;
                double x = x1 + sx;
                double y = y1;
                DrawPixel(color, (int)x, (int)y);
                for (int i = 1; i <= dx; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        y += sy;
                        DrawPixel(color, (int)x, (int)y);
                    }
                    else
                        d += d1;
                    DrawPixel(color, (int)x, (int)y);
                    x += sx;
                }
            }
            else
            {
                double d = ((int)dx << 1) - dy;
                double d1 = (int)dx << 1;
                double d2 = ((int)dx - (int)dy) << 1;
                double x = x1;
                double y = y1 + sy;
                DrawPixel(color, (int)x, (int)y);
                for (int i = 1; i <= dy; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        x += sx;
                        DrawPixel(color, (int)x, (int)y);
                    }
                    else
                        d += d1;
                    DrawPixel(color, (int)x, (int)y);
                    y += sy;

                }

            }
        }

        public static void DrawPixel(Color color, int x, int y)
        {
            if (x > 0 && y > 0 && y < Bmp.Height && x < Bmp.Width)
            {
                Bmp.SetPixel(x, y, color);
            }

        }

        public void Draw(Bitmap bmp, Graphics g, Rectangle ClientRectangle, byte flFunc, PointF[] p1, PointF[] p2, bool dr)
        {
            Bmp = bmp;
            I2 = ClientRectangle.Width;
            J2 = ClientRectangle.Height;
            const int n = 50;
            try
            {
                Color cl = Color.FromArgb(255, 255, 255);
                g.Clear(cl);
                Rectangle r = ClientRectangle;                
                aFont = new Font("Arial", 7, FontStyle.Bold);
                OX(II, JJ, g); OY(II, JJ, g);
                ConnectPoint(p1, g, Color.Red, r, II, JJ);
                ConnectPoint(p2, g, Color.Red, r, II, JJ);
                if (dr)
                {
                    Morph(p1, p2, 100, g, r, II, JJ);
                }
                g.DrawImage(Bmp, r);
                aFont.Dispose();                            
            }
            finally
            {
            }
        }
        public static void ConnectPoint(PointF[] pointF, Graphics g, Color color, Rectangle r, IJ II, IJ JJ)
        {
            for (int j = 0; j < pointF.Length-1; j++)
            {
                PointF temp1 = pointF[j], temp2 = pointF[j + 1];
                if(pointF[j].X > pointF[j+1].X)
                {
                    PointF temp = temp1; temp1 = temp2; temp2 = temp;
                }
                for (double i = temp1.X; i <= temp2.X; i += 0.005)
                {
                    DrawPixel(color, II(i), JJ(Lagrange((float)i, pointF)));
                }
                g.DrawImage(Bmp, r);               
            }
            
        }
        public static float Lagrange(float x, PointF[] Points)
        {
            float res = 0f, s = 0f, s1 = 1f, s2 = 1f;

            for (int i = 0; i < (Points.Length); i++)
            {
                s1 = 1f; s2 = 1f;
                for (int j = 0; j < (Points.Length); j++)
                {
                    if (i != j)
                    {
                        s1 = s1 * (x - Points[j].X);
                        s2 = s2 * (Points[i].X - Points[j].X);
                    }
                }
                s = Points[i].Y * (s1 / s2);
                res = res + s;

            }

            return res;
        }
        public static void Morph(PointF[] point1, PointF[] point2, int step, Graphics g, Rectangle r, IJ II, IJ JJ)
        {
            float lx = 0, ly = 0;
            PointF[] temp = new PointF[4];
            for (int j = 1; j < step; j++)
            {
                for (int i = point1.Length - 1; i >= 0; i--)
                {
                    lx = point2[i].X - point1[i].X;
                    ly = point2[i].Y - point1[i].Y;
                    temp[i].X = point1[i].X + j * lx / step;
                    temp[i].Y = point1[i].Y + j * ly / step;

                }
                ConnectPoint(temp, g, Color.Red, r, II, JJ);
                ConnectPoint(temp, g, Color.White, r, II, JJ);
            }
        }
    }
}
