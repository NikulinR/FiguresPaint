using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BL
{
    public class FRectangle:Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color FColor { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int LineWidth { get; set; }
        

        public FRectangle(int x, int y, Color color, int height, int width, int lineWidth)
        {
            X = x;
            Y = y;
            FColor = color;
            Height = height;
            Width = width;
            LineWidth = lineWidth;
        }

        public void Draw(ref Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            Rectangle rect = new Rectangle(X, Y, Width, Height);
            Pen myPen = new Pen(FColor, LineWidth);
            g.DrawRectangle(myPen, rect);
            g.Dispose();
        }
    }
}
