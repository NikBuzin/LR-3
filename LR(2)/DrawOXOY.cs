using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2_
{
    public class DrawOXOY
    {
        public static Bitmap Draw(Bitmap bmp, TransCoord TC)
        {
            OX(bmp, TC); OY(bmp, TC);
            return bmp;
        }
        static double HH(double a1, double a2)
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
        public static void OX(Bitmap bmp, TransCoord TC)
        {
            LowLogic.DrawLine(bmp, TC.II(TC.X1), TC.JJ(0), TC.II(TC.X2), TC.JJ(0), Color.Black);
            double h1 = HH(TC.X1, TC.X2);
            int k1 = (int)Math.Round(TC.X1 / h1) - 1;
            int k2 = (int)Math.Round(TC.X2 / h1);
            byte Digits = GetDigits(Math.Abs(TC.X2 - TC.X1));
            for (int i = k1; i <= k2; i++)
            {
                LowLogic.DrawLine(bmp, TC.II(i * h1), TC.JJ(0) - 7, TC.II(i * h1), TC.JJ(0) + 7, Color.Black);
                for (int j = 1; j <= 9; j++)
                    LowLogic.DrawLine(bmp, TC.II(i * h1 + j * h1 / 10), TC.JJ(0) - 3, TC.II(i * h1 + j * h1 / 10), TC.JJ(0) + 3, Color.Black);             
            }
        }
        static byte GetDigits(double dx)
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
        public static void OY(Bitmap bmp, TransCoord TC)
        {
            LowLogic.DrawLine(bmp, TC.II(0), TC.JJ(TC.Y1), TC.II(0), TC.JJ(TC.Y2), Color.Black);
            double h1 = HH(TC.Y1, TC.Y2);
            int k1 = (int)Math.Round(TC.Y1 / h1) - 1;
            int k2 = (int)Math.Round(TC.Y2 / h1);
            int Digits = GetDigits(Math.Abs(TC.Y2 - TC.Y1));
            for (int i = k1; i <= k2; i++)
            {
                LowLogic.DrawLine(bmp, TC.II(0) - 7, TC.JJ(i * h1), TC.II(0) + 7, TC.JJ(i * h1), Color.Black);
                for (int j = 1; j <= 9; j++)
                    LowLogic.DrawLine(bmp, TC.II(0) - 3, TC.JJ(i * h1 + j * h1 / 10), TC.II(0) + 3, TC.JJ(i * h1 + j * h1 / 10), Color.Black);            
            }
        }

        
    }
}
