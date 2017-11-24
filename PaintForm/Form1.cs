using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintForm
{
    public partial class FormPaint : Form
    {
        public FormPaint()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
        }

        BL.RectFactory RF= new BL.RectFactory();
        BL.Picture pic = new BL.Picture();
        

        Bitmap bmp;
        Graphics g;


        bool clicked = false;
        Point begin = new Point(0, 0);
        int xdist = 0;
        int ydist = 0;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            begin = Cursor.Position;
            xdist = 0;
            ydist = 0;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            BL.FDrawing draw = new BL.FDrawing(bmp);
            clicked = false;
            RF.CreateFigure(begin.X, begin.Y, Color.Black, xdist, ydist, 2,ref pic);
            draw.FDraw(pic);
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                xdist = begin.X + Cursor.Position.X;
                ydist = begin.Y + Cursor.Position.Y;
            }
        }
    }
}
