

using Draw.UI.Views;
using System.Windows.Forms;

namespace Draw.UI.Controller.Abstract
{
    interface IController
    {
        void MouseClick(MouseEventArgs e);
        void MouseMove(MouseEventArgs e);
        void Paint(PaintEventArgs e);
        void SetGraphicsScreen(GraphicsScreen graphicsScreen);
    }
}
