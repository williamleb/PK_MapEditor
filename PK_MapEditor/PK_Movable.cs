using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PK_MapEditor
{
  /// <summary>
  /// Represents objects that can be moved on the map viewer.
  /// </summary>
  public class PK_Movable : PK_Selectable
  {
    #region Properties

    #region Static Properties

    /// <summary>
    /// Represents the item that is currently picked.
    /// Is set to null if there is no picked item.
    /// </summary>
    public static PK_Movable PickedItem;

    #endregion

    protected bool picked;

    // Those values are updated when the object is picked.
    // They are used to know where the cursor is in relation with the
    // object so it can be properly moved.
    protected int offsetX;
    protected int offsetY;

    // Those values are updated when the object is picked.
    // They are used to know where was the object picked to return
    // it to its original position if the pick is canceled.
    protected int origX;
    protected int origY;

    #endregion

    #region Constructors

    /// <summary>
    /// Sets the picked item to null.
    /// </summary>
    static PK_Movable()
    {
      PickedItem = null;
    }

    /// <summary>
    /// Creates a new movable.
    /// </summary>
    protected PK_Movable()
      : base()
    {
      picked = false;
      Enable = true;

      offsetX = offsetY = 0;
      origX = origY = 0;
    }

    #endregion

    #region Accessors

    /// <summary>
    /// The x coordinate of the object.
    /// </summary>
    public virtual int X { get; set; }

    /// <summary>
    /// The y coordinate of the object.
    /// </summary>
    public virtual int Y { get; set; }

    #endregion

    #region Methods

    /// <summary>
    /// Draws the movable.
    /// </summary>
    /// <param name="window">The context of the drawing.</param>
    public override void Draw(RenderWindow window)
    {
      if (Visible)
      {
        //TODO: If picked, change the color of the little border

        base.Draw(window);
      }
      
    }

    /// <summary>
    /// Picks the movable so it can be dragged with the mouse.
    /// </summary>
    /// <param name="mouseX">Represents the X coordinate of the mouse on the map.</param>
    /// <param name="mouseY">Represents the Y coordinate of the mouse on the map.</param>
    public virtual void Pick(int mouseX, int mouseY)
    {
      // We pick the item if it is visible, enabled and there is not
      // something else being picked
      if (Visible && Enable && PickedItem == null)
      {
        PickedItem = this;
        picked = true;

        offsetX = X - mouseX;
        offsetY = Y - mouseY;

        origX = X;
        origY = Y;
      }
    }

    /// <summary>
    /// Picks the movable so it can be dragged with the mouse.
    /// </summary>
    /// <param name="mousePos">The position of the mouse on the map.</param>
    public void Pick(Vector2i mousePos)
    {
      Pick(mousePos.X, mousePos.Y);
    }

    /// <summary>
    /// Unpicks the movable and drop it on the map.
    /// </summary>
    public void Unpick()
    {
      if (picked)
      {
        PickedItem = null;
        picked = false;
      }
    }

    /// <summary>
    /// Unpicks the movable, but cancel the movement it has done.
    /// </summary>
    public void CancelPick()
    {
      if (picked)
      {
        Unpick();
        X = origX;
        Y = origY;
      }
    }

    /// <summary>
    /// Update a picked item.
    /// This method must be called at least at 30 fps whenever an item is picked.
    /// Picked item can be accessed via the property PK_Movable.PickedItem.
    /// </summary>
    /// <param name="mouseX">Represents the X coordinate of the mouse on the map.</param>
    /// <param name="mouseY">Represents the Y coordinate of the mouse on the map.</param>
    public virtual void Update(int mouseX, int mouseY)
    {
      if (picked)
      {
        X = mouseX + offsetX;
        Y = mouseY + offsetY;
      }
    }

    /// <summary>
    /// Update a picked item.
    /// This method must be called at least at 30 fps whenever an item is picked.
    /// Picked item can be accessed via the property PK_Movable.PickedItem.
    /// </summary>
    /// <param name="mousePos">The position of the mouse on the map.</param>
    public void Update(Vector2i mousePos)
    {
      Update(mousePos.X, mousePos.Y);
    }

    #endregion
  }
}
