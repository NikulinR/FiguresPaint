using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BL
{
    public class FLine:Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color FColor { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public float LineWidth { get; set; }
        public int Type { get; }
        public bool Chosed { get; set; }

        public FLine(int x, int y, Color color, int height, int width, float lineWidth)
        {
            X = x;
            Y = y;
            FColor = color;
            Height = height;
            Width = width;
            LineWidth = lineWidth;
            Type = 3;
            Chosed = false;
        }

        public void Draw(ref Bitmap bmp)
        {
            Graphics G = Graphics.FromImage(bmp);
            Point p1 = new Point(X, Y);
            Point p2 = new Point(X + Width, Y + Height);
            Pen myPen = new Pen(FColor, LineWidth);
            G.DrawLine(myPen, p1, p2);
            G.Dispose();
        }

        public Figure Clone()
        {
            return new FLine(X, Y, FColor, Height, Width, LineWidth);
        }
    }
}
