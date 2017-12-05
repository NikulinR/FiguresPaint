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
        Stack<Figure> Deletes = new Stack<Figure>();
        Stack<Figure> Removed = new Stack<Figure>();

        static public Figure Choose(int x, int y, Picture pic)
        {
            Figure chosen = null;
            bool found = false;
            if(!found)
            foreach (var item in pic.Figures)
            {
                if (item.Width > 0 && item.Height > 0)
                    if ((item.X < x && x < item.X + item.Width) && (item.Y < y && y < item.Y + item.Height))
                    {
                        chosen = item;
                        found = true;
                        break;
                    }
                if (item.Width < 0 && item.Height > 0)
                    if ((item.X + item.Width < x && x < item.X) && (item.Y < y && y < item.Y + item.Height))
                    {
                        chosen = item;
                        found = true;
                        break;
                    }
                if (item.Width > 0 && item.Height < 0)
                    if ((item.X < x && x < item.X + item.Width) && (item.Y + item.Height < y && y < item.Y))
                    {
                        chosen = item;
                        found = true;
                        break;
                    }
                if (item.Width < 0 && item.Height < 0)
                    if ((item.X + item.Width < x && x < item.X) && (item.Y + item.Height < y && y < item.Y))
                    {
                        chosen = item;
                        found = true;
                        break;
                    }
            }
            if (found)
            chosen.Chosed = true;
            return chosen;
        }

        public void Delete(int x, int y, Picture pic)
        {
            Deletes.Push(Choose(x, y, pic));
            Figures.Remove(Choose(x, y,pic));            
        }

        public void Move(Figure chosen, int xd, int yd)
        {
            Removed.Push(chosen.Clone());
            Figures.Remove(chosen);
            Deletes.Push(chosen);
            chosen.X = xd;
            chosen.Y = yd;
            Figures.Add(chosen);
        }

        public Figure Copy(Figure fg)
        {
            return fg.Clone();
        }

        public void ReturnDeleted()
        {
            int count = Deletes.Count;
            for (int i = 0; i < count; i++)
                Figures.Add(Deletes.Pop());
        }

        public void Return()
        {
            if (Figures.Count > 0)
            {
                Deletes.Push(Figures[Figures.Count - 1]);
                Figures.RemoveAt(Figures.Count - 1);
            }
        }

        public void ReturnRemoved()
        {
            if (Figures.Count > 0 && Removed.Count>0)
            {
                Figures.RemoveAt(Figures.Count - 1);
                Figures.Add(Removed.Pop());
            }
        }

        public void Forward()
        {
            if (Deletes.Count > 0 )
                Figures.Add(Deletes.Pop());
        }
    }
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public class CommandDelete:ICommand
    {
        Picture picture;
        int X;
        int Y;
        public CommandDelete(Picture pic, int x, int y)
        {
            picture = pic;
            X = x;
            Y = y;
        }
        public void Execute()
        {
            picture.Delete(X, Y,picture);
        }
        public void Undo()
        {
            picture.Forward();
        }
    }

    public class CommandMove : ICommand
    {
        Picture picture;
        Figure fig;
        int X;
        int Y;
        public CommandMove(Picture pic, Figure fig, int x, int y)
        {
            picture = pic;
            this.fig = fig;
            X = x;
            Y = y;
        }
        public void Execute()
        {
            picture.Move(fig, X, Y);
        }
        public void Undo()
        {
            picture.ReturnRemoved();
        }
    }

    public class CommandDraw : ICommand
    {
        Picture picture;
        public CommandDraw(Picture pic)
        {
            picture = pic;
        }
        public void Execute()
        {
            
        }
        public void Undo()
        {
            picture.Return();
        }
    }
    

    public class CommandStep : ICommand
    {
        Picture picture;
        public CommandStep(Picture pic)
        {
            picture = pic;
        }
        public void Execute()
        {
            picture.Forward();
        }
        public void Undo()
        {
            picture.Return();
        }
    }
    

    public class CommandNull:ICommand
    {
        public void Execute()
        {
            
        }
        public void Undo()
        {
            
        }
    }

    public class Invoker
    {
        Stack<ICommand> commandhistory;
        public Invoker()
        {
            commandhistory = new Stack<ICommand>();
        }
        
        public void PressButton(ICommand command)
        {
            command.Execute();
            commandhistory.Push(command);
        }
        public void PressUndoButton()
        {
            if (commandhistory.Count > 0)
            {
                commandhistory.Pop().Undo();
            }
        }
        
    }


}
