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
           // color_btn.Click += color_btn_Click;
            // colorDialog1.FullOpen = true;
            bmptemp = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            draw = new BL.Decorator(bmp);
        }

        BL.FigureFactory RF= new BL.RectFactory();
        BL.FigureFactory OF = new BL.OvalFactory();
        BL.FigureFactory LF = new BL.LineFactory();

        int figid;
        
        BL.Decorator draw;

        Color color;

        Invoker invoker = new Invoker();    // мультипульт
        Picture pic = new Picture();

        Bitmap bmp;
        Bitmap bmptemp;

        Figure chosen;
        Figure copied;
        bool clicked = false;
        Point begin = new Point(0, 0);
        int xdist = 0;
        int ydist = 0;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            /////////////ACTIONS////////////////////////////////
            if (rbDel.Checked)
            {
                invoker.PressButton(new CommandDelete(pic, e.Location.X, e.Location.Y));
                draw.fd.FDraw(pic, ref bmp);
                pictureBox1.Image = bmp;
            }
            //
            if (rbMove.Checked)
            {

                chosen = Picture.Choose(e.Location.X, e.Location.Y,pic);
                if (chosen != null)
                chosen.FColor = Color.White;
                draw.fd.FDraw(pic, ref bmp);
            }
                if (rbCopy.Checked)
                copied = chosen.Clone();
            ///////////////////////////////////////////////////
                  if(color.Name == "0")
                     color = Color.Black;

            //////////////COLORS//////////////
           /* if (rbBlack.Checked)
                color = Color.Black;
            if (rbRed.Checked)
                color = Color.Red;
            if (rbOrange.Checked)
                color = Color.Orange;
            if (rbYellow.Checked)
                color = Color.Yellow;
            if (rbGreen.Checked)
                color = Color.Green;
            if (rbBlue.Checked)
                color = Color.Blue;
            if (rbIndigo.Checked)
                color = Color.Indigo;
            if (rbViolet.Checked)
                color = Color.Violet;*/
            ///////////////////////////////////////////////////////


            ////////////FIGURES/////////////////
            if (rbRectangle.Checked)
                figid = 1;
            else if (rbOval.Checked)
                figid = 2;
            else if (rbLine.Checked)
                figid = 3;
            else
                figid = -1;
            //////////////////////////////////////


            clicked = true;
            begin = e.Location;
            xdist = 0;
            ydist = 0;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {            
            clicked = false;

            if (rbDraw.Checked)
            {
                invoker.PressButton(new CommandDraw(pic));
                if (figid == 1)
                    RF.CreateFigure(begin.X, begin.Y, color, ydist, xdist, 2, ref pic);
                else if (figid == 2)
                    OF.CreateFigure(begin.X, begin.Y, color, ydist, xdist, 2, ref pic);
                else if (figid == 3)
                    LF.CreateFigure(begin.X, begin.Y, color, ydist, xdist, 2, ref pic);

                draw.fd.FDraw(pic, ref bmp);
                pictureBox1.Image = bmp;
                bmptemp = bmp;
            }
            if(rbMove.Checked && chosen != null)
            {
                chosen.FColor = color;
                invoker.PressButton(new CommandMove(pic, chosen, e.Location.X, e.Location.Y));
                draw.fd.FDraw(pic, ref bmp);
                pictureBox1.Image = bmp;
                bmptemp = bmp;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked && rbDraw.Checked)
            {                
                bmptemp = (Bitmap)bmp.Clone();
                xdist = -begin.X + e.Location.X;
                ydist = -begin.Y + e.Location.Y;
                draw.FDrawMove(figid, begin.X, begin.Y, xdist, ydist, ref bmptemp);
                pictureBox1.Image = bmptemp;
            }            
            if (clicked && rbMove.Checked && chosen!=null)
            {                
                bmptemp = (Bitmap)bmp.Clone();                
                draw.FDrawMove(chosen.Type, e.Location.X, e.Location.Y, chosen.Width, chosen.Height, ref bmptemp);

                pictureBox1.Image = bmptemp;
            }            
        }
        
        private void btnBack_Click_1(object sender, EventArgs e)
        {
            invoker.PressUndoButton();
            draw.fd.FDraw(pic, ref bmp);
            pictureBox1.Image = bmp;
        }

        private void btnForward_Click_1(object sender, EventArgs e)
        {
            invoker.PressButton(new CommandStep(pic));
            draw.fd.FDraw(pic, ref bmp);
            pictureBox1.Image = bmp;
        }

        private void color_btn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                color = colorDialog1.Color;
         //   else color = Color.Black;
        }

        private void FormPaint_Load(object sender, EventArgs e)
        {
          ///  DialogResult result = colorDialog1.ShowDialog();
          //  if (result == DialogResult.Cancel)
          //      color = colorDialog1.Color;
          //  else color = Color.Black;
        }
    }
}
