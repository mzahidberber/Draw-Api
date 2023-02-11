using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.UI.Views
{
    public partial class LineController : Control
    {
        public LineController(PointF p1, PointF p2)
        {
            InitializeComponent();
            this.MouseEnter += this.mouseEnterEvente;
            this.MouseHover += this.mouseHoverEvent;
            this.p1 = p1;
            this.p2 = p2;
            this.Bounds = new Rectangle(0,0,800,800);
            Console.WriteLine("{0} {1}", p1, p2);
            GraphicsPath a = new GraphicsPath();
            a.StartFigure();
            a.AddLine(p1, p2);
            a.CloseFigure();
            
            var b = a.GetBounds();
            //this.Bounds = new Rectangle((int)b.X, (int)b.Y, (int)b.Width, (int)b.Height);
                
            
        }


        private void mouseHoverEvent(object sender, EventArgs e)
        {
            _pen = Pens.Red;
            this.Refresh();
            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //base.OnPaint(pe);
            //pe.Graphics.DrawLine(_pen, p1,p2);
            // Create a path and add two ellipses.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLine(p1,p2);

            // Draw the original ellipses to the screen in black.
            pe.Graphics.DrawPath(Pens.White, myPath);

            // Widen the path.
            Pen widenPen = new Pen(Color.Black, 5);
            Matrix widenMatrix = new Matrix();
            widenMatrix.Translate(100, 100);
            myPath.Widen(widenPen);

            // Draw the widened path to the screen in red.
            //pe.Graphics.FillPath(new SolidBrush(Color.Red), myPath);

            pe.Graphics.DrawRectangle(_pen, this.Bounds);
            RectangleF[] aasd = new RectangleF[] {myPath.GetBounds()};
            
            pe.Graphics.DrawRectangles(_pen, aasd);

        }
        private PointF p1;
        private PointF p2;
        private Pen _pen = Pens.Plum;

        private void mouseEnterEvente(object sender, EventArgs e)
        {
            _pen = Pens.Pink;
            this.Refresh();
        }

    }
}
