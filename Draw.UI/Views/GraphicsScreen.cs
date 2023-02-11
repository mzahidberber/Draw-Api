
using Draw.UI.Controller.Abstract;
using Draw.UI.DependencyResolvers.Ninject;
using System;
using System.Windows.Forms;

namespace Draw.UI.Views
{
    public class GraphicsScreen : UserControl
    {
        private IController _controller;

        public GraphicsScreen()
        {
            _controller = InstanceFactory.GetInstance<IController>();
            _controller.SetGraphicsScreen(this);

        }

        public void Deneme()
        {

        }

        public void AttachActions()
        {
            this.MouseClick += this.GraphicsScreen_MouseClick;
            this.Paint += this.GraphicsScreen_Paint;
            this.MouseMove += this.GraphicsScreen_MouseMove;
            this.MouseDown += this.GraphicsScreen_MouseDown;
            this.KeyDown += this.GraphicsScreen_KeyDown;
            this.KeyPress += this.GraphicsScreen_KeyPress;
            this.KeyUp += this.GraphicsScreen_KeyUp;
            this.PreviewKeyDown += this.GraphicsScreen_PreviewKeyDown;
            this.Scroll += this.GraphicsScreen_Scroll;
            this.MouseWheel += this.GraphicsScreen_Whell;
            this.MouseUp += this.GraphicsScreen_MouseUp;
        }

        private void GraphicsScreen_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("mouse up {0}", e.Button);
        }

        private void GraphicsScreen_Whell(object sender, MouseEventArgs e)
        {
            
            
        }

        private void GraphicsScreen_Scroll(object sender, ScrollEventArgs e)
        {
            Console.WriteLine(e.ScrollOrientation);
            Console.WriteLine(e.OldValue);

        }


        public void GraphicsScreen_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        public void GraphicsScreen_Paint(object sender, PaintEventArgs e)
        {
            _controller.Paint(e);
        }

        public void GraphicsScreen_MouseMove(object sender, MouseEventArgs e)
        {
            _controller.MouseMove(e);
        }

        private void GraphicsScreen_MouseDown(object sender, MouseEventArgs e)
        {
            _controller.MouseClick(e);
            Console.WriteLine("mouse Down {0}", e.Button);
        }

        private void GraphicsScreen_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("-----------");
            Console.WriteLine("key Down");
            Console.WriteLine(e.Alt);
            Console.WriteLine(e.Control);
            Console.WriteLine(e.Shift);
            Console.WriteLine(e.Handled);
            Console.WriteLine(e.KeyCode);
            Console.WriteLine(e.KeyData);
            Console.WriteLine(e.KeyValue);
            Console.WriteLine(e.Modifiers);
            Console.WriteLine(e.SuppressKeyPress);
          
        }

        private void GraphicsScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("key Press {0}",e.KeyChar);
        }

        private void GraphicsScreen_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("key up {0}", e.KeyValue);
        }

        private void GraphicsScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Console.WriteLine("key PreviewKeyDown");
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GraphicsScreen
            // 
            this.Name = "GraphicsScreen";
            this.MouseEnter += new System.EventHandler(this.GraphicsScreen_MouseEnter);
            this.ResumeLayout(false);

        }

        private void GraphicsScreen_MouseEnter(object sender, EventArgs e)
        {

        }
    }
}
