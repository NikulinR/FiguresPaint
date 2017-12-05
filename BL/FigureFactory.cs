using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BL
{
    public interface FigureFactory
    {
        void CreateFigure(int x, int y, Color color, int height, int width, float lineWidth, ref Picture pic);
    }
}
