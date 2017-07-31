using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PK_MapEditor
{
  /// <summary>
  /// This class is used to redirect mouse events to a specified method.
  /// </summary>
  public static class GlobalMouseHandler
  {
    /// <summary>
    /// Initialize the global mouse handler for the specified control.
    /// </summary>
    /// <param name="control"></param>
    /// <param name="callback">
    public static void InitializeGlobalMouseHandler(Control control, Func<object, MouseEventArgs> callback)
    {
      // Redirect the "MouseUp" event.
      // control.MouseUp += new MouseEventHandler(callback);
    }
  }

}
