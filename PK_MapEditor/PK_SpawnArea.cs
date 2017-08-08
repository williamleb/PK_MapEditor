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
  /// Represents a spawn area on the map.
  /// </summary>
  public class PK_SpawnArea : PK_Area
  {

    #region Properties

    #region Constants

    private const int TUMBNAIL_SIZE = 35;

    #endregion

    Texture image;

    #endregion

    #region Accessors

    /// <summary>
    /// Access the name of the object being spawned by the spawn area.
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Access the tumbnail of the object being spawned by the spawn area.
    /// </summary>
    public Texture Image
    {
      get
      {
        return image;
      }
      protected set
      {
        image = value;

        if (value != null)
        {
          // Changes the sprite
          Sprite = new Sprite(value);

          // Adjusts the sprite so it has the right dimensions
          float spriteScaleX = TUMBNAIL_SIZE / (float)value.Size.X;
          float spriteScaleY = TUMBNAIL_SIZE / (float)value.Size.Y;
          Sprite.Scale = new Vector2f(spriteScaleX, spriteScaleY);
        }
      }
    }

    /// <summary>
    /// Access the tumbnail of the object being spawned by the spawn area.
    /// </summary>
    private Sprite Sprite { get; set; }

    /// <summary>
    /// Indicates if the object is spawned during the day.
    /// </summary>
    public bool Day { get; set; }

    /// <summary>
    /// Indicates if the object is spawed during dusk.
    /// </summary>
    public bool Dusk { get; set; }
    
    /// <summary>
    /// Indicates if the object is spawned during night.
    /// </summary>
    public bool Night { get; set; }

    /// <summary>
    /// Indicates if the object is spawned during dawn.
    /// </summary>
    public bool Dawn { get; set; }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new spawn area.
    /// </summary>
    /// <param name="x">The X coordinate of the top-left corner.</param>
    /// <param name="y">They Y coordinate of the top-left corner.</param>
    /// <param name="width">The width of the spawn area.</param>
    /// <param name="height">The height of the spawn area.</param>
    /// <param name="color">The color of the spawn area.</param>
    protected PK_SpawnArea(int x, int y, int width, int height, Color color)
      :base(x, y, width, height, color, false)
    {
      Day = true;
      Dusk = true;
      Night = true;
      Dawn = true;

      Image = null;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Draws the spawn area.
    /// </summary>
    /// <param name="window">The context of the drawing.</param>
    public override void Draw(RenderWindow window)
    {
      if (Visible)
      {

        // Draws the area
        base.Draw(window);

        // Draws the image if it is not null.
        if (Image != null)
        {
          PK_Map map = PK_Map.GetInstance();

          // Position of the area on the map
          int areaMapX = (int)((X - map.ViewArea.X) * 1 / map.ViewScale);
          int areaMapY = (int)((Y - map.ViewArea.Y) * 1 / map.ViewScale);

          // Dimensions of the area on the map
          int areaMapWidth = (int)(Width * (1 / map.ViewScale));
          int areaMapHeight = (int)(Height * (1 / map.ViewScale));

          // Middle point of the area on the map
          int areaMapMiddleX = areaMapX + (areaMapWidth / 2);
          int areaMapMiddleY = areaMapY + (areaMapHeight / 2);

          // Position of the image on the map
          int imageMapX = areaMapMiddleX - (TUMBNAIL_SIZE / 2);
          int imageMapY = areaMapMiddleY - (TUMBNAIL_SIZE / 2);
          Sprite.Position = new Vector2f(imageMapX, imageMapY);

          window.Draw(Sprite);
        }
      }
    }

    #endregion

  }

  /// <summary>
  /// Represents a spawn area that spawns monsters on the map.
  /// </summary>
  public class PK_MonsterSpawnArea : PK_SpawnArea
  {

    #region Properties

    #region Constants

    private static readonly Color MONSTER_SPAWN_AREA_COLOR = Color.Red;

    #endregion

    // The monster being spawned
    PK_Monster monster;

    #endregion

    #region Accessors

    /// <summary>
    /// Access the monster being spawned by the spawn area.
    /// </summary>
    public PK_Monster Monster
    {
      get
      {
        return monster;
      }
      set
      {
        if (value == null)
        {
          throw new ArgumentNullException("value");
        }

        // If the monster is not the same
        if (value != monster)
        {
          // Ajusts the PK_SpawnArea's properties
          Name = value.Name;
          Image = new Texture(value.Thumbnail);

          // Change the monster
          monster = value;
        }
      }
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a monster spawn area.
    /// </summary>
    /// <param name="area">The area which represents the spawn area.</param>
    /// <param name="monster">The monster that will be spawned by the spawn area.</param>
    public PK_MonsterSpawnArea(PK_Area area, PK_Monster monster)
      :this(area.X, area.Y, area.Width, area.Height, monster)
    {
    }

    /// <summary>
    /// Creates a monster spawn area.
    /// </summary>
    /// <param name="x">The X coordinate of the top-left corner.</param>
    /// <param name="y">They Y coordinate of the top-left corner.</param>
    /// <param name="width">The width of the spawn area.</param>
    /// <param name="height">The height of the spawn area.</param>
    /// <param name="monster">The monster that will be spawned by the spawn area.</param>
    public PK_MonsterSpawnArea(int x, int y, int width, int height, PK_Monster monster)
      :base(x, y, width, height, MONSTER_SPAWN_AREA_COLOR)
    {
      Monster = monster;
    }

    #endregion
  }

  /// <summary>
  /// Represents a spawn area that spawns characters on the map.
  /// </summary>
  public class PK_CharacterSpawnArea : PK_SpawnArea
  {
    #region Constants

    private const string CHARACTER_SPAWN_AREA_NAME = "character";
    private const string CHARACTER_THUMBNAIL_PATH = "Assets/img/character_thumbnail.png";
    private static readonly Color CHARACTER_SPAWN_AREA_COLOR = Color.Green;

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a character spawn area.
    /// </summary>
    /// <param name="area">The area which represents the spawn area.</param>
    public PK_CharacterSpawnArea(PK_Area area)
      :this(area.X, area.Y, area.Width, area.Height)
    {
    }

    /// <summary>
    /// Creates a character spawn area.
    /// </summary>
    /// <param name="x">The X coordinate of the top-left corner.</param>
    /// <param name="y">They Y coordinate of the top-left corner.</param>
    /// <param name="width">The width of the spawn area.</param>
    /// <param name="height">The height of the spawn area.</param>
    public PK_CharacterSpawnArea(int x, int y, int width, int height)
      :base(x, y, width, height, CHARACTER_SPAWN_AREA_COLOR)
    {
      Name = CHARACTER_SPAWN_AREA_NAME;
      Image = new Texture(CHARACTER_THUMBNAIL_PATH);
    }

    #endregion
  }

  /// <summary>
  /// Represents a spawn area that spawns items on the map.
  /// </summary>
  public class PK_ItemSpawnArea : PK_SpawnArea
  {

    #region Properties

    #region Constants

    private static readonly Color ITEM_SPAWN_AREA_COLOR = Color.Yellow;

    #endregion

    // The item being spawned.
    PK_Item item;

    #endregion

    #region Accessors

    /// <summary>
    /// Access the item being spawned by the spawn area.
    /// </summary>
    public PK_Item Item
    {
      get
      {
        return item;
      }
      set
      {
        if (value == null)
        {
          throw new ArgumentNullException("value");
        }

        // If the item is not the same
        if (value != item)
        {
          // Ajusts the PK_SpawnArea's properties
          Name = value.Name;
          Image = new Texture(value.Thumbnail);

          // Change the item
          item = value;
        }
      }
    }

    #endregion

    /// <summary>
    /// Creates a item spawn area.
    /// </summary>
    /// <param name="area">The area which represents the spawn area.</param>
    /// <param name="item">The item that will be spawned by the spawn area.</param>
    public PK_ItemSpawnArea(PK_Area area, PK_Item item)
      :this(area.X, area.Y, area.Width, area.Height, item)
    {
    }

    /// <summary>
    /// Creates an item spawn area.
    /// </summary>
    /// <param name="x">The X coordinate of the top-left corner.</param>
    /// <param name="y">They Y coordinate of the top-left corner.</param>
    /// <param name="width">The width of the spawn area.</param>
    /// <param name="height">The height of the spawn area.</param>
    /// <param name="item">The item that will be spawned by the spawn area.</param>
    public PK_ItemSpawnArea(int x, int y, int width, int height, PK_Item item)
      :base(x, y, width, height, ITEM_SPAWN_AREA_COLOR)
    {
      // NOTE: If it causes trouble assigning the passed item, could use a clone instead
      Item = item;
    }
  }
}
