
using Draw.UI.Views;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Draw.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();

            InitializeComponent();
            graphicsScreen.AttachActions();

            this.ActiveControl = tbxCommand;

            this.merkezX = graphicsScreen.Width / 2;
            this.merkezY = graphicsScreen.Height / 2;
        }
        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private void tbxCommand_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            {
                listBox.Items.Add(tbxCommand.Text);
                listBox.TopIndex = listBox.Items.Count - 1;
                tbxCommand.Clear();            
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (tbxCommand.Text == " ")
                {
                    tbxCommand.Clear();
                }
                else
                {
                    listBox.Items.Add(tbxCommand.Text);
                    listBox.TopIndex = listBox.Items.Count - 1;
                    tbxCommand.Clear();
                }
                
            }
        }
        private float merkezX ;
        private float merkezY ;
        private float panX =0f;
        private float panY=0f;
        private float zoom = 0.5567f;
        
        private PointF ScreenToWorld(float x,float y)
        {
            var pointx =((x-this.merkezX) * zoom)-panX;
            var pointy =-((y-this.merkezY) * zoom)-panY;
            return new PointF(pointx,pointy);
        }

        private PointF WorldToScreen(float x,float y)
        {
            var pointx = ((x+panX)/zoom)+(this.merkezX);
            var pointy = - ((y+panY)/zoom)+(this.merkezY);
            return new PointF(pointx,pointy);
        }

        private PointF MerkezNokta()
        {
            var genislik=graphicsScreen.Width / 2;
            var yukseklik = graphicsScreen.Height / 2;

            var merkeez = new PointF(genislik, yukseklik);

            return merkeez;
        }

        private void graphicsScreen_MouseMove(object sender, MouseEventArgs e)
        {
            lblX.Text = "X : "+ String.Format("{0:0.0000}" ,ScreenToWorld(e.X, e.Y).X);
            lblY.Text = "Y : "+ String.Format("{0:0.0000}", ScreenToWorld(e.X, e.Y).Y);
           
        }

        private void graphicsScreen_MouseWhell(object sender, MouseEventArgs e)
        {
            if(e.Delta<0)
            {
                this.zoom /= 0.9f;
            }
            else
            {
                this.zoom *= 0.9f;
            }
            graphicsScreen.Refresh();
        }

        private void graphicsScreen_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawLine(Pens.White,new PointF(graphicsScreen.Width/2-100,graphicsScreen.Height/2), new PointF(graphicsScreen.Width/2 + 100, graphicsScreen.Height/2));
            //e.Graphics.DrawLine(Pens.White, new PointF(graphicsScreen.Width/2,graphicsScreen.Height/2-100), new PointF(graphicsScreen.Width/2, graphicsScreen.Height/2+100));
            e.Graphics.DrawLine(Pens.White,WorldToScreen(0,-100),WorldToScreen(0,100));
            e.Graphics.DrawLine(Pens.White,WorldToScreen(-100,0),WorldToScreen(100,0));
            

            e.Graphics.DrawLine(Pens.Wheat, WorldToScreen(0, 0), WorldToScreen(100, 56.5789f));
            var line = new LineController(WorldToScreen(0, 0), WorldToScreen(50, 50));
            line.Location = new Point(100, 100);
            this.graphicsScreen.Controls.Add(line);

        }



        private void tsbLine_Click(object sender, EventArgs e)
        {
        }

        private void tsbCircle_Click(object sender, EventArgs e)
        {
        }

        private PointF mouseDownLocation = new PointF(0, 0);

        private void graphicsScreen_MouseUp(object sender, MouseEventArgs e)
        {
            var location = ScreenToWorld(e.X, e.Y);
            var farkx = location.X - mouseDownLocation.X;
            var farky = location.Y - mouseDownLocation.Y;
            Console.WriteLine("x:{0} y:{1}",farkx,farky);
            this.panX += farkx;
            this.panY += farky;
            graphicsScreen.Refresh();
        }

        private void graphicsScreen_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDownLocation = ScreenToWorld(e.X,e.Y);
        }
    }
    class Line : Control
    {
        private PointF p1;
        private PointF p2;
        private Pen _pen=Pens.Plum;
        
        public Line(PointF p1, PointF p2)
        {
            this.MouseEnter += this.mouseEnterEvente;
            this.p1 = p1;
            this.p2 = p2;
        }

        private void mouseEnterEvente(object sender, EventArgs e)
        {
            _pen = Pens.Pink;
        }


    }
}
