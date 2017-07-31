using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PK_MapEditor
{
  public class PK_Selectable : PK_Drawable
  {
    #region Properties

    #region Static Properties

    /// <summary>
    /// Represents the item that is currently selected.
    /// Is set to null if there is no selected item.
    /// </summary>
    public static PK_Selectable selectedItem;

    #endregion

    RectangleShape shape;

    bool selected;

    #endregion

    #region Accessors

    /// <summary>
    /// Determine whether the current object can be selected or not.
    /// </summary>
    public bool Enable { get; set; }

    /// <summary>
    /// Determine whether the item is currently selected or not.
    /// </summary>
    protected bool Selected
    {
      get
      {
        return selected;
      }
      private set
      {
        selected = value;
      }
    }

    /// <summary>
    /// Represents the drawable shape of the item being draw (if it is selected).
    /// It must be set before the item's drawing, as it is used to
    /// surround the item with a border if it is selected.
    /// </summary>
    public IntRect Shape
    {
      set
      {
        // Creates a new RectangleShape corresponding to the new shape.
        if (shape == null)
        {
          shape = new RectangleShape();
        }
        if (value != null)
        {
          shape.Position = new Vector2f(value.Left, value.Top);
          shape.Size = new Vector2f(value.Width, value.Height);
          shape.FillColor = Color.Transparent;
          shape.OutlineColor = Color.Blue;
          shape.OutlineThickness = 3;
        }

      }
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Sets the selected item to null.
    /// </summary>
    static PK_Selectable()
    {
      selectedItem = null;
    }

    public PK_Selectable()
      :base()
    {
      selected = false;
      Shape = new IntRect(0, 0, 0, 0);
    }

    #endregion

    #region Methods

    public void Select()
    {
      if (Visible && Enable)
      {
        if (selectedItem != null)
        {
          selectedItem.Deselect();
        }

        selectedItem = this;
        selected = true;
      }
    }

    public void Deselect()
    {
      if (selected)
      {
        selectedItem = null;
        selected = false;
      }
    }

    public override void Draw(RenderWindow window)
    {
      if (Visible && Selected)
      {
        window.Draw(shape);
      }
    }

    #endregion

  }
}
