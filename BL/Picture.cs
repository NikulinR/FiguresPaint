using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Picture
    {
        public List<Figure> Figures = new List<Figure>();
        public Stack<Figure> InStack = new Stack<Figure>();
        public void Delete(int x, int y)
        {
            List<Figure> Deletes = new List<Figure>();
            foreach (var item in Figures)
            {
                if (item.Width > 0 && item.Height > 0)
                {
                    if ((item.X < x && x < item.X + item.Width) && (item.Y < y && y < item.Y + item.Height))
                        Deletes.Add(item);
                }

                if (item.Width < 0 && item.Height > 0)
                {
                    if ((item.X + item.Width < x && x < item.X) && (item.Y < y && y < item.Y + item.Height))
                        Deletes.Add(item);
                }

                if (item.Width > 0 && item.Height < 0)
                {
                    if ((item.X < x && x < item.X + item.Width) && (item.Y + item.Height < y && y < item.Y))
                        Deletes.Add(item);
                }

                if (item.Width < 0 && item.Height < 0)
                {
                    if ((item.X + item.Width < x && x < item.X) && (item.Y + item.Height < y && y < item.Y))
                        Deletes.Add(item);
                }
            }
            Figures.RemoveAll(a => Deletes.Contains(a));
        }
        public void Return()
        {
            if (Figures.Count > 0)
            {
                InStack.Push(Figures.ElementAt<Figure>(Figures.Count - 1));
                Figures.RemoveAt(Figures.Count - 1);
            }
        }
        public void Forward()
        {
            if (InStack.Count > 0)
                Figures.Add(InStack.Pop());
        }
    }
}
