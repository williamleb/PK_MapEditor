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
  /// Represents an rectangle area on the map.
  /// </summary>
  public class PK_Area : PK_Drawable
  {
    #region Properties

    #region Constants

    private static readonly Color AREA_DEFAULT_COLOR = Color.Black;

    #endregion

    int width, height;

    #endregion

    #region Accessors

    /// <summary>
    /// Access the X coordinate of the area's top left corner.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Access the Y coordinate of the area's top left corner.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Access the width of the area.
    /// </summary>
    public int Width
    {
      get
      {
        return width;
      }
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException("value", "The width value must not go below 0.");
        }
        width = value;
      }
    }

    /// <summary>
    /// Access the height of the area.
    /// </summary>
    public int Height
    {
      get
      {
        return height;
      }
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException("value", "The height value must not go below 0.");
        }
        height = value;
      }
    }

    /// <summary>
    /// Access the color of the area.
    /// </summary>
    public Color AreaColor { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new area.
    /// </summary>
    /// <param name="x">The X coordinate of the area's top left corner.</param>
    /// <param name="y">The Y coordinate of the area's top left corner.</param>
    /// <param name="width">The width of the area.</param>
    /// <param name="height">The height of the area.</param>
    public PK_Area(int x, int y, int width, int height, Color color)
    {
      X = x;
      Y = y;
      Width = width;
      Height = height;
      AreaColor = color;
      color.A = 255 / 2;
    }

    /// <summary>
    /// Creates a new area.
    /// </summary>
    /// <param name="x">The X coordinate of the area's top left corner.</param>
    /// <param name="y">The Y coordinate of the area's top left corner.</param>
    /// <param name="width">The width of the area.</param>
    /// <param name="height">The height of the area.</param>
    public PK_Area(int x, int y, int width, int height)
      :this(x, y, width, height, AREA_DEFAULT_COLOR)
    {
    }

    /// <summary>
    /// Creates a new area.
    /// </summary>
    /// <param name="x">The X coordinate of the area's top left corner.</param>
    /// <param name="y">The Y coordinate of the area's top left corner.</param>
    public PK_Area(int x, int y)
      :this(x, y, 0, 0, AREA_DEFAULT_COLOR)
    {
    }

    /// <summary>
    /// Creates a new area.
    /// </summary>
    public PK_Area()
      :this(0, 0, 0, 0, AREA_DEFAULT_COLOR)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Draws the area.
    /// </summary>
    /// <param name="window">The context of the drawing.</param>
    public override void Draw(RenderWindow window)
    {
      if (Visible)
      {
        RectangleShape shape = new RectangleShape();
        shape.Position = new Vector2f(X, Y);
        shape.Size = new Vector2f(Width, Height);
        shape.FillColor = AreaColor;

        window.Draw(shape);
      }
    }

    #endregion
  }
}
