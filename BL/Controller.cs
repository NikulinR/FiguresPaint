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

     public abstract class FigureComponent
    {
        protected Figure fig;
        
       public FigureComponent(Figure f)
        {
            fig = f;
        }

        public abstract void AddToBox(Figure f);
        public abstract void Remove(Figure f);
    }
    public class FigureBox: FigureComponent
    {
        List<Figure> box = new List<Figure>();
        public FigureBox(Figure f)
          :  base(f)
        { }

        public override void AddToBox(Figure component)
        {
            bool a = (fig.Width > 0) && (fig.Height > 0) && ((component.X >= fig.X) && (component.Y >= fig.Y)
                      && (component.X + component.Width <= fig.X + fig.Width && component.Y + component.Height <= fig.Y + fig.Height));
            bool b = ((fig.Width > 0) && (fig.Height < 0)) && ((component.X >= fig.X) && (component.Y <= fig.Y)
                      && (component.X + component.Width <= fig.X + fig.Width && component.Y + component.Height >= fig.Y + fig.Height));
            bool c = ((fig.Width < 0) && (fig.Height > 0)) && ((component.X <= fig.X) && (component.Y >= fig.Y)
                      && (component.X + component.Width >= fig.X + fig.Width && component.Y + component.Height <= fig.Y + fig.Height));
            bool d = ((fig.Width < 0) && (fig.Height < 0)) && ((component.X <= fig.X) && (component.Y <= fig.Y)
                      && (component.X + component.Width >= fig.X + fig.Width && component.Y + component.Height >= fig.Y + fig.Height));
            // if (leaf.X >= X) && () && () && ()
            bool ok = a || b || c || d;
            if (ok)
                box.Add(component);
        }
        public override void Remove(Figure f)
        {
            throw new NotImplementedException();
        }
    }

    class FigureLeaf: FigureComponent
    {     
        public FigureLeaf(Figure f)
          :  base(f)
        { }
        public override void AddToBox(Figure component)
        {
            throw new NotImplementedException();
        }
        
        public override void Remove(Figure f)
        {
            throw new NotImplementedException();
        }

    }
    class Box : Figure // мб убрать это наследование и сделать абстрактный класс с полем фигуры?
    {
         public int X { get; set; }
        public int Y { get; set; }
        public Color FColor { get; set; }
        public Color FillColor { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public float LineWidth { get; set; }
        public int Type { get; }
        public bool isBox { get { return true; } set { value = true; } } //фигня какая-то
        List<Figure> components = new List<Figure>();
        public bool Chosed { get; set; }

        // у класса компонент (фигура) придётся реализовывать эти методы в каждом потомке, я хз как это делать 
        public void AddToBox(Figure component)
        {
            bool a = ((Width > 0) && (Height > 0)) && ((component.X >= X) && (component.Y >= Y)
                      && (component.X + component.Width <= X + Width && component.Y + component.Height <= Y + Height));
            bool b = ((Width > 0) && (Height < 0)) && ((component.X >= X) && (component.Y <= Y)
                      && (component.X + component.Width <= X + Width && component.Y + component.Height >= Y + Height));
            bool c = ((Width < 0) && (Height > 0)) && ((component.X <= X) && (component.Y >= Y)
                      && (component.X + component.Width >= X + Width && component.Y + component.Height <= Y + Height));
            bool d = ((Width < 0) && (Height < 0)) && ((component.X <= X) && (component.Y <= Y)
                      && (component.X + component.Width >= X + Width && component.Y + component.Height >= Y + Height));
            // if (leaf.X >= X) && () && () && ()
            bool ok = a || b || c || d;
            if (ok)
                components.Add(component);
        }

        public Figure Clone()
        {
            throw new NotImplementedException();
        }

        public void Draw(ref Bitmap bmp)
        {
            throw new NotImplementedException();
        }

        public void RemoveFigure(Figure comp)
        {
            components.Remove(comp);
        }

       

        void ReturnBox()
        {

        }

       
    }
    class Single : Figure
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

        public void AddToBox(Figure f)
        {
            throw new NotImplementedException();
        }
        public void RemoveFigure()
        {
            throw new NotImplementedException();
        }

        
        Figure Figure.Clone()
        {
            throw new NotImplementedException();
        }

        void Figure.Draw(ref Bitmap bmp)
        {
            throw new NotImplementedException();
        }
      

       
    }
}
