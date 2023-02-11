

using Draw.UI.Views;
using System.Windows.Forms;

namespace Draw.UI.Controller.Abstract
{
    public abstract class ControllerAbstract : IController
    {
        public abstract void MouseClick(MouseEventArgs e);

        public abstract void MouseMove(MouseEventArgs e);

        public abstract void Paint(PaintEventArgs e);


        public abstract void SetGraphicsScreen(GraphicsScreen graphicsScreen);
    }
}
