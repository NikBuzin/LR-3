using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2_
{
    public class Bezie : ISplines
    {
        Color color;
        public void SetColor()
        {
            color = Color.Green;
        }
        public void DrawSplines(Bitmap bmp, TransCoord TC, List<Points> list)
        {
            int j = 0;
            float step = 0.01f;

            List<PointF> result = new List<PointF>();
            for (float t = 0; t < 1; t += step)
            {
                float ytmp = 0;
                float xtmp = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    float b = polinom(i, list.Count - 1, t);
                    xtmp += list[i].X * b;
                    ytmp += list[i].Y * b;
                }
                result.Add(new PointF(xtmp, ytmp));
                if (j > 0)
                {
                    LowLogic.DrawLine(bmp, TC.II(result[j - 1].X), TC.JJ(result[j - 1].Y), TC.II(result[j].X), TC.JJ(result[j].Y), color);
                }
                j++;
            }
        }
        static float polinom(int i, int n, float t)
        {
            return (Fuctorial(n) / (Fuctorial(i) * Fuctorial(n - i))) * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i);
        }
        static int Fuctorial(int n)
        {
            int res = 1;
            for (int i = 1; i <= n; i++)
                res *= i;
            return res;
        }
    }
}
