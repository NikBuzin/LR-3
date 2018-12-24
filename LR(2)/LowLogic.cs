using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2_
{
    public class LowLogic
    {
        public static void DrawLine(Bitmap Bmp, double x1, double y1, double x2, double y2, Color color)
        {
            double dx = (x2 > x1) ? (x2 - x1) : (x1 - x2);
            double dy = (y2 > y1) ? (y2 - y1) : (y1 - y2);

            double sx = (x2 >= x1) ? (1) : (-1);
            double sy = (y2 >= y1) ? (1) : (-1);

            if (dy < dx)
            {
                double d = ((int)dy << 1) - dx; 
                double d1 = (int)dy << 1;
                double d2 = ((int)dy - (int)dx) << 1;
                double x = x1 + sx;
                double y = y1;
                DrawPixel(Bmp, color, (int)x, (int)y);
                for (int i = 1; i <= dx; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        y += sy;
                        DrawPixel(Bmp, color, (int)x, (int)y);
                    }
                    else
                        d += d1;
                    DrawPixel(Bmp, color, (int)x, (int)y);
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
                DrawPixel(Bmp, color, (int)x, (int)y);
                for (int i = 1; i <= dy; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        x += sx;
                        DrawPixel(Bmp, color, (int)x, (int)y);
                    }
                    else
                        d += d1;
                    DrawPixel(Bmp, color, (int)x, (int)y);
                    y += sy;

                }

            }           
        }

        public static void DrawPixel(Bitmap Bmp, Color color, int x, int y)
        {
            if (x > 0 && y > 0 && y < Bmp.Height && x < Bmp.Width)
            {
                Bmp.SetPixel(x, y, color);
            }

        }
        public static void DrawPoint(Bitmap bmp, Color color, double x, double y)
        {
            for (int i = -3; i < 3; i++)
            {
                for (int j = -3; j < 3; j++)
                {
                    DrawPixel(bmp, color, (int)x + i, (int)y + j);
                }
            }           
        }
    }
}
