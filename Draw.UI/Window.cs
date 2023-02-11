using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.UI
{
    public class Window:UserControl
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Window
            // 
            this.AutoSize = true;
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Name = "Window";
            this.Size = new System.Drawing.Size(800, 800);
            this.ResumeLayout(false);
           
            

        }
    }
}
