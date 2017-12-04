using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BL
{
    class Controller
    {
       
    }
    class Box : Figure
    {
        public int X { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Color FColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int LineWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Type => throw new NotImplementedException();

        public void AddToBox(Figure f)
        {

        }

        public Figure Clone()
        {
            throw new NotImplementedException();
        }

        public void Draw(ref Bitmap bmp)
        {
            throw new NotImplementedException();
        }

        public void RemoveFigure()
        {

        }

       

        void ReturnBox()
        {

        }

       
    }
    class Single : Figure
    {
        int Figure.X { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int Figure.Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Color Figure.FColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int Figure.Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int Figure.Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int Figure.LineWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        int Figure.Type => throw new NotImplementedException();

        public void AddToBox(Figure f)
        {

        }
        public void RemoveFigure()
        {

        }

        
        Figure Figure.Clone()
        {
            throw new NotImplementedException();
        }

        void Figure.Draw(ref Bitmap bmp)
        {
            throw new NotImplementedException();
        }
      
        public void ReturnBox()
        {

        }

       
    }
}
