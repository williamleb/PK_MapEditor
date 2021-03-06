﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PK_MapEditor
{
  /// <summary>
  /// Represents a rectangle area on the map.
  /// </summary>
  public class PK_Area : PK_Movable
  {
    #region Properties

    #region Constants

    private static readonly Color AREA_DEFAULT_COLOR = Color.Black;

    #endregion

    int width, height;

    #endregion

    #region Accessors

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
    /// <param name="color">The color that fills the area.</param>
    /// <param name="fullyVisible">Indicates if the area is fully (true) or partialy (false) visible.</param>
    public PK_Area(int x, int y, int width, int height, Color color, bool fullyVisible)
    {
      X = x;
      Y = y;
      Width = width;
      Height = height;

      Color colorClone = new Color(color);
      if (!fullyVisible && colorClone.A != 0)
      {
        colorClone.A = 255 / 2;
      }
      AreaColor = colorClone;
    }

    /// <summary>
    /// Creates a new area.
    /// </summary>
    /// <param name="x">The X coordinate of the area's top left corner.</param>
    /// <param name="y">The Y coordinate of the area's top left corner.</param>
    /// <param name="width">The width of the area.</param>
    /// <param name="height">The height of the area.</param>
    /// <param name="color">The color that fills the area.</param>
    public PK_Area(int x, int y, int width, int height, Color color)
      :this(x, y, width, height, color, true)
    {
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
    /// Checks if the area collides with another area.
    /// </summary>
    /// <param name="area">The area to check collision with.</param>
    /// <returns>True if the areas collide, false if they don't.</returns>
    public bool CollideWith(PK_Area area)
    {
      // Area1 is the current area
      FloatRect area1 = new FloatRect(this.X, this.Y, this.Width, this.Height);

      // Area2 is the given area
      FloatRect area2 = new FloatRect(area.X, area.Y, area.Width, area.Height);

      return area1.Intersects(area2);
    }

    /// <summary>
    /// Checks if the area contains a specific point.
    /// </summary>
    /// <param name="x">The X coordinate of the point.</param>
    /// <param name="y">The Y coordinate of the point.</param>
    /// <returns>True if the area contains the point, false if it doesn't.</returns>
    public bool Contains(int x, int y)
    {
      return new FloatRect(this.X, this.Y, this.Width, this.Height).Contains(x, y);
    }

    /// <summary>
    /// Checks if the area contains a specific point.
    /// </summary>
    /// <param name="coord">The coordinates of the point.</param>
    /// <returns>True if the area contains the point, false if it doesn't.</returns>
    public bool Contains(Vector2f coord)
    {
      return new FloatRect(this.X, this.Y, this.Width, this.Height).Contains(coord.X, coord.Y);
    }

    /// <summary>
    /// Draws the area.
    /// </summary>
    /// <param name="window">The context of the drawing.</param>
    public override void Draw(RenderWindow window)
    {
      if (Visible)
      {
        // If the item is selected, we update it's shape
        // so it can be drawn correctly
        if (Selected)
        {
          Shape = new IntRect(X, Y, Width, Height);
        }

        RectangleShape shape = new RectangleShape();

        PK_Map map = PK_Map.GetInstance();

        // Position
        int mapX = (int)((X - map.ViewArea.X) * 1 / map.ViewScale);
        int mapY = (int)((Y - map.ViewArea.Y) * 1 / map.ViewScale);
        shape.Position = new Vector2f(mapX, mapY);

        // Dimensions
        int mapWidth = (int)(Width * (1 / map.ViewScale));
        int mapHeight = (int)(Height * (1 / map.ViewScale));
        shape.Size = new Vector2f(mapWidth, mapHeight);

        // Color
        shape.FillColor = AreaColor;

        window.Draw(shape);

        base.Draw(window);
      }
    }

    #endregion
  }
}
