using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2_
{
    public interface ISplines
    {
        void SetColor();
        void DrawSplines(Bitmap bmp, TransCoord TC, List<Points> list);
    }
}
