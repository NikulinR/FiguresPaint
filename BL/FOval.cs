using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BL
{

    public class FOval:Figure
    {
        
        public int X { get; set; }
        public int Y { get; set; }
        public Color FColor { get; set; }
        public Color FillColor { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public float LineWidth { get; set; }
        public int Type { get; }
        public bool Chosed { get; set; }
        public bool isBox { get; set; }

        public FOval(int x, int y, Color color, Color fill, int height, int width, float lineWidth)
        {
            X = x;
            Y = y;
            FColor = color;
            Height = height;
            Width = width;
            LineWidth = lineWidth;
            FillColor = fill;
            Type = 2;
            Chosed = false;
        }

        public void Draw(ref Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            Rectangle rect = new Rectangle();

            if (Width > 0 && Height > 0)
                rect = new Rectangle(X, Y, Width, Height);

            if (Width < 0 && Height > 0)
                rect = new Rectangle(X + Width, Y, -Width, Height);

            if (Width > 0 && Height < 0)
                rect = new Rectangle(X, Y + Height, Width, -Height);

            if (Width < 0 && Height < 0)
                rect = new Rectangle(X + Width, Y + Height, -Width, -Height);

            Pen myPen = new Pen(FColor, LineWidth);
            Brush myBr = new SolidBrush(FillColor);

            g.DrawEllipse(myPen, rect);
            g.FillEllipse(myBr, rect);
            g.Dispose();
        }

        public Figure Clone()
        {
            return new FOval(X, Y, FColor,FillColor, Height, Width, LineWidth);
        }
    }
}
