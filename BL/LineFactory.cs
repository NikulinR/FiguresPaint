using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BL
{
    public class LineFactory: FigureFactory
    {
        public void CreateFigure(int x, int y, Color color, int height, int width, int lineWidth, ref Picture pic)
        {
            pic.Figures.Add(new FLine(x, y, color, height, width, lineWidth));
        }
    }
}
