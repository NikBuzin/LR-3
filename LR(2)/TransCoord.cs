using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2_
{
    public class TransCoord
    {
        public int I1 { get; set; }
        public int J1 { get; set; }
        public int I2 { get; set; }
        public int J2 { get; set; }
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        
        public TransCoord(int i1, int j1, int i2, int j2, double x1, double y1, double x2, double y2 )
        {
            I1 = i1;
            I2 = i2;
            J1 = j1;
            J2 = j2;
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }
        public int II(double x)
        {
            return I1 + (int)((x - X1) * (I2 - I1) / (X2 - X1));
        }

        public double XX(int I)
        {
            return X1 + (I - I1) * (X2 - X1) / (I2 - I1);
        }

        public int JJ(double y)
        {
            return J2 + (int)((y - Y1) * (J1 - J2) / (Y2 - Y1));
        }

        public double YY(int J)
        {
            return Y1 + (J - J2) * (Y2 - Y1) / (J1 - J2);
        }
    }
}
