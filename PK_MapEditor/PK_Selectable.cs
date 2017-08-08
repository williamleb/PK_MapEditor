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

    #region Constants

    private int DEFAULT_BORDER_THICKNESS = 3;

    private static readonly Color BORDER_COLOR = Color.Blue;

    #endregion

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
          // This if/else statement is used not to cause a stackoverflow error by calling map.GetInstance
          // when during the construction of the map
          if (value.Left == 0 && value.Top == 0 && value.Width == 0 && value.Height == 0)
          {
            shape.Position = new Vector2f(0, 0);
            shape.Size = new Vector2f(0, 0);
          }
          else
          {
            PK_Map map = PK_Map.GetInstance();

            // Position
            int mapX = (int)((value.Left - map.ViewArea.X) * 1 / map.ViewScale);
            int mapY = (int)((value.Top - map.ViewArea.Y) * 1 / map.ViewScale);
            shape.Position = new Vector2f(mapX, mapY);

            // Dimensions
            int mapWidth = (int)(value.Width * (1 / map.ViewScale));
            int mapHeight = (int)(value.Height * (1 / map.ViewScale));
            shape.Size = new Vector2f(mapWidth, mapHeight);

            // Appearance
            shape.FillColor = Color.Transparent;
            shape.OutlineColor = BORDER_COLOR;
            shape.OutlineThickness = DEFAULT_BORDER_THICKNESS * (1 / map.ViewScale);
          }
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

    /// <summary>
    /// Creates a new selectable.
    /// </summary>
    public PK_Selectable()
      :base()
    {
      selected = false;
      Shape = new IntRect(0, 0, 0, 0);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Select the current item.
    /// </summary>
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

    /// <summary>
    /// Deselect the current item.
    /// </summary>
    public void Deselect()
    {
      if (selected)
      {
        selectedItem = null;
        selected = false;
      }
    }

    /// <summary>
    /// Draw the selectable.
    /// </summary>
    /// <param name="window">The context of the drawing.</param>
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
