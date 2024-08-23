using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodByeCSharp
{
    public class CircleButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath g = new GraphicsPath();
            //ClientSize : 사용자가 늘렸다 줄였다 하는 사이즈
            g.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(g);
            base.OnPaint(pevent);
        }
    }
}
