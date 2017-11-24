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
    }
}
