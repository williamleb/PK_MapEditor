using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PK_MapEditor
{
  /// <summary>
  /// Represents something that can be drawn on the map.
  /// </summary>
  public abstract class PK_Drawable
  {
    #region Properties

    bool visible = true;

    #endregion

    #region Accessors

    /// <summary>
    /// Access the visibility of the drawable.
    /// </summary>
    public bool Visible
    {
      get
      {
        return visible;
      }
      set
      {
        visible = value;
      }
    }

    #endregion

    public abstract void Draw(RenderWindow window);
  }
}
