using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace PK_MapEditor
{
  public class PK_Item : PK_Movable
  {

    #region Properties

    #region Constants

    private static readonly Color BOX_DEFAULT_COLOR = Color.Yellow;
    private static readonly Color COLLISION_BOX_DEFAULT_COLOR = Color.Red;

    #endregion

    PK_Area box;
    int boxOffsetX;
    int boxOffsetY;

    PK_Area collisionBox;
    int collisionBoxOffsetX;
    int collisionBoxOffsetY;

    int x;
    int y;

    Texture image;

    #endregion

    #region Accessors

    /// <summary>
    /// Access the image of the item.
    /// </summary>
    public Texture Image {
      get
      {
        return image;
      }
      private set
      {
        image = value;

        if (value != null)
        {
          // Changes the sprite
          Sprite = new Sprite(value);
        }
      }
    }

    /// <summary>
    /// Access the sprite of the item.
    /// </summary>
    private Sprite Sprite { get; set; }

    /// <summary>
    /// Access the path of the item's tumbnail.
    /// </summary>
    public string Thumbnail { get; set; }

    /// <summary>
    /// Access the name of the item.
    /// </summary>
    public string Name { get; private set; }

    public PK_Area SurroundingArea
    {
      get
      {
        return box;
      }
    }

    /// <summary>
    /// Access the x coordinate of the item on the map.
    /// </summary>
    public override int X
    {
      get
      {
        return x;
      }
      set
      {
        try
        {
          x = value;

          // When the item is moved, we change the position of its boxes accordingly
          if (box != null)
          {
            box.X = value + boxOffsetX;
          }
          if (collisionBox != null)
          {
            collisionBox.X = value + collisionBoxOffsetX;
          }
        }
        catch (ArgumentNullException)
        {
          throw new InvalidOperationException("The position of the item cannot be changed if it's box or it's collision box do not exist.");
        }
      }
    }

    /// <summary>
    /// Access the y coordinate of the item on the map.
    /// </summary>
    public override int Y
    {
      get
      {
        return y;
      }
      set
      {
        try
        {
          y = value;

          // When the item is moved, we change the position of its boxes accordingly
          if (box != null)
          {
            box.Y = value + boxOffsetY;
          }
          if (collisionBox != null)
          {
            collisionBox.Y = value + collisionBoxOffsetY;
          }
        }
        catch (NullReferenceException)
        {
          throw new InvalidOperationException("The position of the item cannot be changed if it's box or it's collision box do not exist.");
        }
      }
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new item with which its position is set to its top-left corner and where
    /// is collision box takes all the sprite.
    /// </summary>
    /// <param name="name">The name of the item.</param>
    /// <param name="x">The x coordinate of the item on the map.</param>
    /// <param name="y">The y coordinate of the item on the map.</param>
    /// <param name="imagePath">The path to the sprite of the item.</param>
    public PK_Item(string name, int x, int y, string imagePath)
    {
      Name = name;
      X = x;
      Y = y;

      Image = new Texture(imagePath);
      Thumbnail = imagePath;

      // Creates the collision box so it takes all the sprite.
      this.collisionBox = new PK_Area(X, Y, (int)Image.Size.X, (int)Image.Size.Y, COLLISION_BOX_DEFAULT_COLOR);
      this.collisionBox.Visible = false;
      this.collisionBox.Enable = false;
      collisionBoxOffsetX = 0;
      collisionBoxOffsetY = 0;

      // Creates the box so it takes all the sprite
      this.box = new PK_Area(X, Y, (int)Image.Size.X, (int)Image.Size.Y, BOX_DEFAULT_COLOR);
      this.box.Visible = false;
      this.box.Enable = false;
      boxOffsetX = 0;
      boxOffsetY = 0;
    }

    /// <summary>
    /// Creates a new item with which its position is set to its top-left corner.
    /// </summary>
    /// <param name="name">The name of the item.</param>
    /// <param name="x">The x coordinate of the item on the map.</param>
    /// <param name="y">The y coordinate of the item on the map.</param>
    /// <param name="imagePath">The path to the sprite of the item.</param>
    /// <param name="collisionBox">The area where the items collide with other items.</param>
    public PK_Item(string name, int x, int y, string imagePath, PK_Area collisionBox)
    {
      Name = name;
      X = x;
      Y = y;

      Image = new Texture(imagePath);
      Thumbnail = imagePath;

      this.collisionBox = collisionBox;
      this.collisionBox.Visible = false;
      this.collisionBox.AreaColor = COLLISION_BOX_DEFAULT_COLOR;
      this.collisionBox.Enable = false;
      collisionBoxOffsetX = collisionBox.X - this.X;
      collisionBoxOffsetY = collisionBox.Y - this.Y;

      // Creates the box so it takes all the sprited
      this.box = new PK_Area(X, Y, (int)Image.Size.X, (int)Image.Size.Y, BOX_DEFAULT_COLOR);
      this.box.Visible = false;
      this.box.Enable = false;
      boxOffsetX = 0;
      boxOffsetY = 0;
    }

    /// <summary>
    /// Creates a new item.
    /// </summary>
    /// <param name="name">The name of the item.</param>
    /// <param name="x">The x coordinate of the item on the map.</param>
    /// <param name="y">The y coordinate of the item on the map.</param>
    /// <param name="imagePath">The path to the sprite of the item.</param>
    /// <param name="collisionBox">The area where the items collide with other items.</param>
    /// <param name="box">The box covering the item sprite.</param>
    public PK_Item(string name, int x, int y, string imagePath, PK_Area collisionBox, PK_Area box)
    {
      Name = name;
      X = x;
      Y = y;

      Image = new Texture(imagePath);
      Thumbnail = imagePath;

      this.collisionBox = collisionBox;
      this.collisionBox.Visible = false;
      this.collisionBox.Enable = false;
      collisionBoxOffsetX = collisionBox.X - this.X;
      collisionBoxOffsetY = collisionBox.Y - this.Y;

      this.box = box;
      this.box.Visible = false;
      this.box.Enable = false;
      boxOffsetX = box.X - this.X;
      boxOffsetY = box.Y - this.Y;
    }

    /// <summary>
    /// Creates an item from a parsed-from-JSON item.
    /// </summary>
    /// <param name="jsonItem">The parsed-from-JSON item.</param>
    public PK_Item(Json_Item jsonItem)
      :this(jsonItem.name, 
         jsonItem.position.x, 
         jsonItem.position.y, 
         "Assets/" + jsonItem.img, 
         new PK_Area(jsonItem.position.x + jsonItem.collisionBox.offsetX, 
           jsonItem.position.y + jsonItem.collisionBox.offsetY, 
           jsonItem.collisionBox.width, 
           jsonItem.collisionBox.height,
           COLLISION_BOX_DEFAULT_COLOR,
           false),
         new PK_Area(jsonItem.position.x + jsonItem.box.offsetX,
           jsonItem.position.y + jsonItem.box.offsetY,
           jsonItem.box.width,
           jsonItem.box.height,
           BOX_DEFAULT_COLOR,
           false)
         )
    {
      Thumbnail = "Assets/" + jsonItem.thumbnail;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Draws the item on a surface.
    /// </summary>
    /// <param name="window">The drawing context.</param>
    public override void Draw(RenderWindow window)
    {
      if (Visible)
      {
        // If the item is selected, we update it's shape
        // so it can be drawn correctly
        if (Selected)
        {
          Shape = new IntRect(box.X, box.Y, box.Width, box.Height);
        }

        // If the item has an image, we draw it
        if (Image != null)
        {
          PK_Map map = PK_Map.GetInstance();

          // Position
          int mapX = (int)((box.X - map.ViewArea.X) * 1 / map.ViewScale);
          int mapY = (int)((box.Y - map.ViewArea.Y) * 1 / map.ViewScale);
          Sprite.Position = new Vector2f(mapX, mapY);

          // Scale
          Sprite.Scale = new Vector2f(1 / map.ViewScale, 1 / map.ViewScale);

          window.Draw(Sprite);

          base.Draw(window);
        }

        // If the box or the collision box are visible, we draw them
        if (box.Visible)
        {
          box.Draw(window);
        }
      }
        
      if (collisionBox.Visible)
      {
        collisionBox.Draw(window);
      }
    }

    #endregion
  }
}
