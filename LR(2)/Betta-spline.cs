using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2_
{
    public class Betta_spline : ISplines
    {
        Color color;
        public void SetColor()
        {
            color = Color.Red;
        }
        public void DrawSplines(Bitmap bmp, TransCoord TC, List<Points> points) 
        {

            if (points.Count % 2 == 1 || points.Count < 8) 
                return;

            drawSpline(bmp, TC, points[0].X, points[1].Y, points[0].X, points[1].Y, points[2].X, points[3].Y, points[4].X,
                       points[5].Y, color);

            for (int i = 8; i <= points.Count; i += 2) 
                drawSpline(bmp, TC, points[i - 8].X, points[i - 7].Y, points[i - 6].X, points[i - 5].Y, points[i - 4].X,
                           points[i - 3].Y, points[i - 2].X, points[i - 1].Y, color);

            int j = points.Count - 6;
            drawSpline(bmp, TC, points[j].X, points[j + 1].Y, points[j + 2].X, points[j + 3].Y, points[j + 4].X,
                       points[j + 5].Y, points[j + 4].X, points[j + 5].Y, color); 
        }


        private static void drawSpline(Bitmap bmp, TransCoord TC, float x1, float y1, float x2,
                                        float y2, float x3, float y3, float x4, float y4, Color color)
        {

            float a0 = countSplineCoefficient(0, x1, x2, x3, x4);
            float a1 = countSplineCoefficient(1, x1, x2, x3, x4);
            float a2 = countSplineCoefficient(2, x1, x2, x3, x4);
            float a3 = countSplineCoefficient(3, x1, x2, x3, x4);

            float b0 = countSplineCoefficient(0, y1, y2, y3, y4);
            float b1 = countSplineCoefficient(1, y1, y2, y3, y4);
            float b2 = countSplineCoefficient(2, y1, y2, y3, y4);
            float b3 = countSplineCoefficient(3, y1, y2, y3, y4);

            float xPrev = a0, yPrev = b0;

            for (int i = 1; i <= 20; i++)
            {
                float t = i / 20.0f;
                float x = ((a3 * t + a2) * t + a1) * t + a0; 
                float y = ((b3 * t + b2) * t + b1) * t + b0; 

                LowLogic.DrawLine(bmp, TC.II(xPrev), TC.JJ(yPrev), TC.II(x), TC.JJ(y), color); 
                xPrev = x;
                yPrev = y;
            }
        }

        private static float countSplineCoefficient(int index, float x1, float x2, float x3, float x4)
        {
            switch (index)
            {
                case 0:
                    return (x1 + 4 * x2 + x3) / 6.0f; 
                case 1:
                    return (-x1 + x3) / 2.0f; 
                case 2:
                    return (x1 - 2 * x2 + x3) / 2.0f;
                case 3:
                    return (-x1 + 3 * x2 - 3 * x3 + x4) / 6.0f;
            }
            return 0;
        }
    }
}
