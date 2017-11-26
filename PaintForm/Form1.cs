using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace PaintForm
{
    public partial class FormPaint : Form
    {
        public FormPaint()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            draw = new BL.FDrawing(bmp);
            invoker.SetCommand(1, new StepCommand(pic));

        }

        BL.FigureFactory RF= new BL.RectFactory();
        BL.FigureFactory OF = new BL.OvalFactory();
        BL.FigureFactory LF = new BL.LineFactory();
        
        BL.FDrawing draw;



        Invoker invoker = new Invoker();    // мультипульт
        Picture pic = new Picture();

        Bitmap bmp;


        bool clicked = false;
        Point begin = new Point(0, 0);
        int xdist = 0;
        int ydist = 0;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (rbDel.Checked)
            {
                invoker.SetCommand(0, new DeleteCommand(pic, e.Location.X, e.Location.Y));
                invoker.PressButton(0);
                draw.FDraw(pic, ref bmp);
                pictureBox1.Image = bmp;
            }
            clicked = true;
            begin = e.Location;
            xdist = 0;
            ydist = 0;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {            
            clicked = false;
            if (rbRectangle.Checked)
                RF.CreateFigure(begin.X, begin.Y, Color.Black, ydist, xdist, 2, ref pic);
            else if (rbOval.Checked)
                OF.CreateFigure(begin.X, begin.Y, Color.Black, ydist, xdist, 2, ref pic);
            else if (rbLine.Checked)
                LF.CreateFigure(begin.X, begin.Y, Color.Black, ydist, xdist, 2, ref pic);
            draw.FDraw(pic,ref bmp);
            pictureBox1.Image = bmp;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                xdist = -begin.X + e.Location.X;
                ydist = -begin.Y + e.Location.Y;                
            }
            
        }
        
        private void btnBack_Click_1(object sender, EventArgs e)
        {
            invoker.SetCommand(1, new StepCommand(pic));
            invoker.PressUndoButton();
            draw.FDraw(pic, ref bmp);
            pictureBox1.Image = bmp;
        }

        private void btnForward_Click_1(object sender, EventArgs e)
        {
            invoker.PressButton(1);
            draw.FDraw(pic, ref bmp);
            pictureBox1.Image = bmp;
        }
    }
}
