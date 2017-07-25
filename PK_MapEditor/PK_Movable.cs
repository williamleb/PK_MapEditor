using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PK_MapEditor
{
  /// <summary>
  /// Represents objects that can be moves on the map viewer.
  /// </summary>
  public class PK_Movable : PK_Drawable
  {
    #region Properties

    #region Static Properties

    public static bool SomethingPicked;

    #endregion

    bool canBePicked;

    bool picked;

    // Those values are updated when the object is picked.
    // They are used to know where the cursor is in relation with the
    // object so it can be properly moved.
    int offsetX;
    int offsetY;

    // Those values are updated when the object is picked.
    // They are used to know where was the object picked to return
    // it to its original position if the pick is canceled.
    int origX;
    int origY;

    #endregion

    #region Constructors

    static PK_Movable()
    {
      SomethingPicked = false;
    }

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
    /// Determine whether the current object can be picked or not.
    /// </summary>
    public bool Enable { get; set; }

    /// <summary>
    /// The x coordinate of the object.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// The y coordinate of the object.
    /// </summary>
    public int Y { get; set; }

    #endregion

    #region Methods

    public override void Draw(RenderWindow window)
    {
      if (Visible)
      {
        //TODO: If picked, draw a little border
      }
    }

    //TODO: Pick (add event handler), Unpick
    public void Pick()// TODO: Maybe have the mouse position?
    {
      // We pick the item if it is visible, enabled and there is not
      // something else being picked
      if (Visible && Enable && !SomethingPicked)
      {
        SomethingPicked = true;
        picked = true;

        origX = X;
        origY = Y;

        // TODO: Set offsets
      }
    }

    public void Unpick()
    {
      if (picked)
      {
        SomethingPicked = false;
        picked = false;
      }
    }

    public void CancelPick()
    {
      if (picked)
      {
        Unpick();
        X = origX;
        Y = origY;
      }
    }
    #endregion
  }
}
