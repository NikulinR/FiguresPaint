using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BL
{
    public class FDrawing
    {

        Bitmap bmp;

        public FDrawing(Bitmap bmp)
        {
            this.bmp = bmp;
        }

        public void FDraw(Picture pic, ref Bitmap bmp)
        {
            Graphics.FromImage(bmp).Clear(Color.White);
            foreach (var item in pic.Figures)
            {
                item.Draw(ref bmp);
            }
        }

    }

    public class Decorator
    {
        public FDrawing fd;


        public Decorator(Bitmap bmp)
        {
            fd = new FDrawing(bmp);
        }        

        public void FDrawMove(int idfigure, int x, int y, int width,int height, ref Bitmap bmp)
        {
            Figure fig=null;
            if (idfigure == 1)
                fig = new FRectangle(x, y, Color.DarkRed, Color.Empty, height, width, 2);
            else if (idfigure == 2)
                fig = new FOval(x, y, Color.DarkRed, Color.Empty, height, width, 2);
            else if(idfigure == 3)
                fig = new FLine(x, y, Color.DarkRed, Color.Empty, height, width, 2);


            if (fig != null)
                Decorate(ref bmp, fig);
                fig.Draw(ref bmp);
        }

        public void Decorate(ref Bitmap bmp, Figure chosen)
        {
                Graphics g = Graphics.FromImage(bmp);


                RectangleF[] rects = new RectangleF[4];
                rects[0] = new RectangleF(chosen.X, chosen.Y, 10, 10);
                rects[1] = new RectangleF(chosen.X + chosen.Width-10, chosen.Y, 10, 10);
                rects[2] = new RectangleF(chosen.X, chosen.Y + chosen.Height-10, 10, 10);
                rects[3] = new RectangleF(chosen.X + chosen.Width-10, chosen.Y + chosen.Height-10, 10, 10);

            Pen myPen = new Pen(Color.Red, 3);

                g.DrawRectangles(myPen, rects);

                g.Dispose();
        }

    }
}
