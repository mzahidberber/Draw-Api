using Draw.UI.Controller.Abstract;
using Draw.UI.Views;
using System.Windows.Forms;

namespace Draw.UI.Controller.Concrete
{
    public class GraphicsScreenController : ControllerAbstract
    {
        //private DrawManager _manager=new DrawManager();
        private GraphicsScreen _graphicsScreen;

        public override void SetGraphicsScreen(GraphicsScreen graphicsScreen)
        {
            _graphicsScreen = graphicsScreen;
        }

        public override void Paint(PaintEventArgs e)
        {
        }

        public override void MouseClick(MouseEventArgs e)
        {
            _graphicsScreen.Refresh();
        }

        public override void MouseMove(MouseEventArgs e)
        {
           
            //Console.WriteLine(MousePositionSingleton.GetMouseMovePosition());
            
        }
        
    }

    
}
