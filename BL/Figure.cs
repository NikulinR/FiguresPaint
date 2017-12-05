using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace BL
{
    public interface Figure
    {
        int X { get; set; }
        int Y { get; set; }
        Color FColor { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        int LineWidth { get; set; }
        void Draw(ref Bitmap bmp);
        Figure Clone();
       // void ReturnBox();
      //  void AddToBox(Figure f);
       // void RemoveFigure();
        int Type { get; }
        bool Chosed { get; set; }
    }
}
