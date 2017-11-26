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
        public void Delete(int x, int y)
        {
            bool found = false;
            foreach (var item in Figures)
            {
                if (item.Width > 0 && item.Height > 0)
                    if ((item.X < x && x < item.X + item.Width) && (item.Y < y && y < item.Y + item.Height))
                    {
                        Deletes.Push(item);
                        found = true;
                        break;
                    }
                if (item.Width < 0 && item.Height > 0)
                    if ((item.X + item.Width < x && x < item.X) && (item.Y < y && y < item.Y + item.Height))
                    {
                        Deletes.Push(item);
                        found = true;
                        break;
                    }  
                if (item.Width > 0 && item.Height < 0)
                    if ((item.X < x && x < item.X + item.Width) && (item.Y + item.Height < y && y < item.Y))
                    {
                        Deletes.Push(item);
                        found = true;
                        break;
                    }  
                if (item.Width < 0 && item.Height < 0)
                    if ((item.X + item.Width < x && x < item.X) && (item.Y + item.Height < y && y < item.Y))
                    {
                        Deletes.Push(item);
                        found = true;
                        break;
                    }
            }
            if (found)
            {
                Figures.Remove(Deletes.Peek());
            }
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
        public void Forward()
        {
            if (Deletes.Count > 0)
                Figures.Add(Deletes.Pop());
        }
    }
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public class DeleteCommand:ICommand
    {
        Picture picture;
        int X;
        int Y;
        public DeleteCommand(Picture pic, int x, int y)
        {
            picture = pic;
            X = x;
            Y = y;
        }
        public void Execute()
        {
            picture.Delete(X, Y);
        }
        public void Undo()
        {
            picture.Return();
        }
    }
    public class StepCommand:ICommand
    {
        Picture picture;
        public StepCommand(Picture pic)
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
    public class noCommand:ICommand
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
        ICommand[] commands;
        Stack<ICommand> commandhistory;
        public Invoker()
        {
            commands = new ICommand[3];
            for (int i = 0; i < commands.Length; i++)
                commands[i] = new noCommand();
            commandhistory = new Stack<ICommand>();
        }

        public void SetCommand(int number, ICommand c)
        {
            commands[number] = c;
        }
        public void PressButton(int number)
        {
            commands[number].Execute();
            commandhistory.Push(commands[number]);
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
