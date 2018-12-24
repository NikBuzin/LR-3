using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_2_
{
    public partial class LR6 : Form
    {
        public Logic L { get; set; }
        public TransCoord TC { get; set; }
        public int N { get; set; }
        public Line Line { get; set; }
        double coeff = 1;
        bool drawingAll = false, drawingPoint = false;
        public Points pointsF;
        public Bitmap b;
        public List<ISplines> splines;
        MouseEventArgs e0;
        public LR6()
        {
            InitializeComponent();
            splines = new List<ISplines>();
            Line = new Line();
            CB_Betta.Tag = new Betta_spline();
            CB_Bezie.Tag = new Bezie();
            TC = new TransCoord(0, Width, Height, 0, -50, -50, 50, 50);                        
        }

        public void MyDraw(Graphics g, Rectangle r)
        {
            b = new Bitmap(r.Width, r.Height);           
            Logic.Draw(b, TC, splines, Line);
            this.Focus();
            g.DrawImage(b, r);
            b.Dispose();
        }
        private void ChangeCheck(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if(cb.Checked)
            {
                splines.Add((ISplines)cb.Tag);
            }
            else
            {
                splines.Remove((ISplines)cb.Tag);
            }
        }

        private void LR3_Paint(object sender, PaintEventArgs e)
        {            
            var R = new Rectangle(0,0, Width, Height);
            MyDraw(e.Graphics,  R);          
        }

        private void LR3_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingAll)
            {
                double dx = TC.XX(e.X) - TC.XX(e0.X);
                double dy = TC.YY(e.Y) - TC.YY(e0.Y);
                e0 = e;
                TC.X1 -= dx; TC.Y1 -= dy;
                TC.X2 -= dx; TC.Y2 -= dy;
                Invalidate();
            }
            if (drawingPoint)
            {
                pointsF = new Points((float)(TC.XX(e.Location.X)), (float)TC.YY(e.Location.Y), Color.Black);
                double dx = TC.XX(e.X) - TC.XX(e0.X);
                double dy = TC.YY(e.Y) - TC.YY(e0.Y);
                e0 = e;
                if (FoundPoint(pointsF) != -1)
                {
                    Line.Points[FoundPoint(pointsF)] = new Points(Line.Points[FoundPoint(pointsF)].X + (float)dx, Line.Points[FoundPoint(pointsF)].Y + (float)dy, Color.Red);
                }
                Invalidate();
            }
        }
        public int FoundPoint(Points point)
        {
            int temp1 = -1;
            double delta = 5;
            for (int i = 0; i < Line.Points.Count; i++)
            {
                double dx = point.X - Line.Points[i].X;
                double dy = point.Y - Line.Points[i].Y;
                double temp2 = Math.Sqrt(dx * dx + dy * dy);
                if (delta > temp2)
                {
                    delta = temp2;
                    temp1 = i;
                }                
            }
            return temp1;
        }

        private void LR3_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void LR3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawingAll = true;
            }
            if ( e.Button == MouseButtons.Right)
            {                
                drawingPoint = true;
            }
            e0 = e;       
        }

        private void LR3_MouseUp(object sender, MouseEventArgs e)
        {           
            drawingAll = false;
            drawingPoint = false;
            Invalidate();
        }
        private void ReDraw()
        {
            for (int i = 0; i < Line.Points.Count; i++)
            {
                Line.Points[i].Clr = Color.Black;
            }
        }
        private void LR3_Load(object sender, EventArgs e)
        {
            MouseWheel += new MouseEventHandler(LR3_MouseWheel);
        }

        void LR3_MouseWheel(object sender, MouseEventArgs e)
        {
            double x = TC.XX(e.X);
            double y = TC.YY(e.Y);
            if (e.Delta < 0)
                coeff = 1.5;
            else
                coeff = 0.5;
            TC.X1 = x - (x - TC.X1) * coeff;
            TC.X2 = x + (TC.X2 - x) * coeff;
            TC.Y1 = y - (y - TC.Y1) * coeff;
            TC.Y2 = y + (TC.Y2 - y) * coeff;
            Invalidate();
        }             

        private void But_Clean_Click(object sender, EventArgs e)
        {
            Line.Points.Clear();
            Invalidate();
        }

        private void CB_Betta_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void LR6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pointsF = new Points((float)(TC.XX(e.Location.X)), (float)TC.YY(e.Location.Y), Color.Black);
            if (e.Button == MouseButtons.Left && FoundPoint(pointsF) == -1)
            {
                N++;
                if (Line.Points.Count < N)
                {
                    Line.Add(pointsF);
                }
            }
            if (e.Button == MouseButtons.Right && FoundPoint(pointsF) == -1)
            {
                if (Line.Points.Count < N)
                {
                    Line.Points[FoundPoint(pointsF)].Clr = Color.Red;
                }
            }
            Invalidate();
        }

        private void LR6_MouseClick(object sender, MouseEventArgs e)
        {
            ReDraw();
            pointsF = new Points((float)(TC.XX(e.Location.X)), (float)TC.YY(e.Location.Y), Color.Black);
            if ( e.Button == MouseButtons.Right)
            {
                if (FoundPoint(pointsF) != -1)
                {
                    Line.Points[FoundPoint(pointsF)].Clr = Color.Red;
                }
            }
            Invalidate();
        }

        private void LR6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (FoundPoint(pointsF) != -1)
                {
                    Line.Points.RemoveAt(FoundPoint(pointsF));
                }
            }
            Invalidate();
        }

    }
}
