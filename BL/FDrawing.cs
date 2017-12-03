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

        public void FDraw(Picture pic,ref Bitmap bmp)
        {
            Graphics.FromImage(bmp).Clear(Color.White);
            foreach (var item in pic.Figures)
            {
                item.Draw(ref bmp);
            }
        }

        public void FDrawMove(int idfigure, int x, int y, int width,int height, ref Bitmap bmp)
        {
            Figure fig=null;
            if (idfigure == 1)
                fig = new FRectangle(x, y, Color.DarkRed, height, width, 2);
            else if (idfigure == 2)
                fig = new FOval(x, y, Color.DarkRed, height, width, 2);
            else if(idfigure == 3)
                fig = new FLine(x, y, Color.DarkRed, height, width, 2);

            if(fig != null)
                fig.Draw(ref bmp);
        }

    }
}
