using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2_
{
    public class Logic
    {
        public static void Point(Bitmap bmp, TransCoord TC, Color color, List<Points> p)
        {
            for(int i = 0; i < p.Count; i++)
            {
                LowLogic.DrawPoint(bmp, p[i].Clr, TC.II(p[i].X), TC.JJ(p[i].Y));
            }
        }

        public static void Draw(Bitmap bmp, TransCoord TC, List<ISplines> splines, Line p)
        {           
            try
            {
                Random rnd = new Random();
                DrawOXOY.Draw(bmp, TC);           
                Point(bmp, TC, Color.Black, p.Points);
                if (splines != null)
                {
                    for (int i = 0; i < splines.Count; i++)
                    {
                    splines[i].SetColor();
                    splines[i].DrawSplines(bmp, TC, p.Points);
                    }
                }
            }
            finally
            { }
        }        
       
    }
}
