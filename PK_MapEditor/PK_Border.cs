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
  /// Represents the border of the map for players.
  /// </summary>
  public class PK_Border : PK_Drawable
  {
    #region Properties

    int radius, height, width;

    PK_BorderShape type;

    #endregion

    #region Accessors

    /// <summary>
    /// Access the type of the border.
    /// </summary>
    public PK_BorderShape Type
    {
      get
      {
        return type;
      }
      set
      {
        // Convert the border dimension from type to type.
        // To undefined : all values reset;
        // To circle : radius becomes the width of the rectangle and the width and height values reset;
        // To rectangle : width and height become the radius of the circle and the radius value resets.
        switch (value)
        {
          case PK_BorderShape.Undefined:
            Radius = Height = Width = 0;
            break;
          case PK_BorderShape.Circle:
            Radius = Width;
            Height = Width = 0;
            break;
          case PK_BorderShape.Rectangle:
            Width = Height = Radius;
            break;
        }

        type = value;
      }
    }

    /// <summary>
    /// Access x coordinate of the border's center.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Access y coordinate of the border's center.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Access the radius of the border if the border is a cricle.
    /// </summary>
    public int Radius
    {
      get
      {
        if (Type != PK_BorderShape.Circle)
        {
          throw new InvalidOperationException("A non-circle border does not contain a radius.");
        }
        return radius;
      }
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException("value", "Radius value should be positive.");
        }
        radius = value;
      }
    }
    
    /// <summary>
    /// Access the height of the border if the border is a rectangle.
    /// </summary>
    public int Height
    {
      get
      {
        if (Type != PK_BorderShape.Rectangle)
        {
          throw new InvalidOperationException("A non-rectangle border does not contain a height.");
        }
        return height;
      }
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException("value", "Height value should be positive.");
        }
        height = value;
      }
    }

    /// <summary>
    /// Access the width of the border if the border is a rectangle.
    /// </summary>
    public int Width
    {
      get
      {
        if (Type != PK_BorderShape.Rectangle)
        {
          throw new InvalidOperationException("A non-rectangle border does not contain a width.");
        }
        return width;
      }
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException("value", "Width value should be positive.");
        }
        width = value;
      }
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new undefined border.
    /// </summary>
    public PK_Border()
    {
      type = PK_BorderShape.Undefined;
      Radius = Height = Width = X = Y = 0;
    }

    /// <summary>
    /// Build an instance of a circle border.
    /// </summary>
    /// <param name="radius">Radius of the border.</param>
    /// <param name="x">X position of the center of the border.</param>
    /// <param name="y">Y position of the center of the border.</param>
    public PK_Border(int radius, int x, int y)
    {
      type = PK_BorderShape.Circle;
      Radius = radius;
      X = X;
      y = Y;

      // Unused properties
      Height = Width = 0;
    }

    /// <summary>
    /// Build an instance of a rectangle border.
    /// </summary>
    /// <param name="width">Width of the border.</param>
    /// <param name="height">Height of the border.</param>
    /// <param name="x">X position of the center of the border.</param>
    /// <param name="y">Y position of the center of the border.</param>
    public PK_Border(int width, int height, int x, int y)
    {
      type = PK_BorderShape.Rectangle;
      Width = width;
      Height = height;
      X = x;
      Y = y;

      // Unused property
      Radius = 0;
    }

    #endregion

    #region Method

    /// <summary>
    /// Draw the border on the window.
    /// </summary>
    /// <param name="window">The context of the drawing.</param>
    public override void Draw(RenderWindow window)
    {
      if (Visible)
      {
        if (Type == PK_BorderShape.Circle)
        {
          CircleShape shape = new CircleShape(Radius);
          shape.FillColor = Color.Transparent;
          shape.OutlineColor = Color.Red;
          shape.OutlineThickness = 5;
          shape.Origin = new Vector2f(Radius / 2, Radius / 2);
          shape.Position = new Vector2f(X, Y);

          window.Draw(shape);
        }
        else if (Type == PK_BorderShape.Rectangle)
        {
          RectangleShape shape = new RectangleShape(new Vector2f(Width, Height));
          shape.FillColor = Color.Transparent;
          shape.OutlineColor = Color.Red;
          shape.OutlineThickness = 5;
          shape.Origin = new Vector2f(Width / 2, Height / 2);
          shape.Position = new Vector2f(X, Y);

          window.Draw(shape);
        }
      }
    }

    #endregion
  }
}
