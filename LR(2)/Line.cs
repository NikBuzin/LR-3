using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2_
{
    public class Line
    {
        public List<Points> Points { get; set; }
        public Line()
        {
            Points = new List<Points>();
        }
        public void Add(Points p)
        {
            Points.Add(p);
        }
    }
}
