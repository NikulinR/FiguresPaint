﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BL
{
    public class RectFactory:FigureFactory
    {
        public void CreateFigure(int x, int y, Color color, Color fillColor, int height, int width, float lineWidth,ref Picture pic)
        {
            pic.Figures.Add(new FRectangle(x, y, color, fillColor, height, width, lineWidth));
        }
    }
}
