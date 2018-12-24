using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2_
{
    public class Points
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Color Clr { get; set; }
        public Points(float x, float y, Color color)
        {
            X = x;
            Y = y;
            Clr = color;
        }
    }
}
