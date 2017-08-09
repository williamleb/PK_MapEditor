using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_MapEditor
{

  /// <summary>
  /// Represents the field of view on the map.
  /// </summary>
  public class PK_ViewArea : PK_Area
  {
    #region Properties

    // Those values are updated when the object is picked.
    // They are used to know where was the mouse when the object was picked
    // to know by how much the mouse has moved.
    int origMouseX;
    int origMouseY;

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new view area.
    /// </summary>
    /// <param name="x">The X coordinate of the view area's top left corner.</param>
    /// <param name="y">The Y coordinate of the view area's top left corner.</param>
    /// <param name="width">The width of the view area.</param>
    /// <param name="height">The height of the view area.</param>
    public PK_ViewArea(int x, int y, int width, int height)
      :base(x, y, width, height)
    {
      origMouseX = 0;
      origMouseY = 0;
    }

    /// <summary>
    /// Creates a new area.
    /// </summary>
    /// <param name="x">The X coordinate of the view area's top left corner.</param>
    /// <param name="y">The Y coordinate of the view area's top left corner.</param>
    public PK_ViewArea(int x, int y)
      :this(x, y, 0, 0)
    {
    }

    /// <summary>
    /// Creates a new view area.
    /// </summary>
    public PK_ViewArea()
      :this(0, 0, 0, 0)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Update a picked item.
    /// This method must be called at least at 30 fps whenever the view area is picked.
    /// Picked item can be accessed via the property PK_Movable.PickedItem.
    /// </summary>
    /// <param name="mouseX">Represents the X coordinate of the mouse on the map.</param>
    /// <param name="mouseY">Represents the Y coordinate of the mouse on the map.</param>
    public override void Update(int mouseX, int mouseY)
    {
      if (picked)
      {
        // The view area moves to the opposite of the mouse.

        PK_Map map = PK_Map.GetInstance();

        // travelX and travelY represent the movement the mouse has done by the origin.
        int travelX = map.GetGameMapXFromMapX(mouseX) - origMouseX;
        int travelY = map.GetGameMapYFromMapY(mouseY) - origMouseY;

        X = origMouseX + offsetX - travelX;
        Y = origMouseY + offsetY - travelY;
      }
    }

    /// <summary>
    /// Picks the view area so it can be dragged with the mouse.
    /// </summary>
    /// <param name="mouseX">Represents the X coordinate of the mouse on the map.</param>
    /// <param name="mouseY">Represents the Y coordinate of the mouse on the map.</param>
    public override void Pick(int mouseX, int mouseY)
    {
      // We pick the view area if it is visible, enabled and there is not
      // something else being picked
      if (Visible && Enable && PickedItem == null)
      {
        PK_Map map = PK_Map.GetInstance();

        origMouseX = map.GetGameMapXFromMapX(mouseX);
        origMouseY = map.GetGameMapYFromMapY(mouseY);

        base.Pick(mouseX, mouseY);
      }
    }

    #endregion
  }
}
