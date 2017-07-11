using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PK_MapViewer
{
  public class SFMLCanvas : Control
  {
    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
      // Don't call base.OnPaint(e) to prevent forground painting
      // base.OnPaint(e);
    }
    protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
    {
      // Don't call base.OnPaintBackground(e) to prevent background painting
      // base.OnPaintBackground(pevent);
    }
  }
}
