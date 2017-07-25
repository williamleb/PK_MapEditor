using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using Newtonsoft.Json;

namespace PK_MapEditor
{
  public class PK_Map : PK_Drawable
  {

    #region Properties

    #region Static Properties

    static PK_Map instance = null;

    #endregion

    #region Lists

    List<PK_Item> allItems = new List<PK_Item>();

    List<PK_SpawnArea> allSpawnAreas = new List<PK_SpawnArea>();

    #endregion

    string name;

    float viewScale;

    PK_Area viewArea;

    Texture backgroundImage;

    #endregion

    #region Accessors

    public string FileName
    {
      get
      {
        return name.Replace(" ", "") + '_' + PK_GameModeOperations.EnumToString(GameMode) + ".json";
      }
    }
    
    public string Name
    {
      get
      {
        return name;
      }
      set
      {
        if (value.Length == 0)
        {
          throw new FormatException("The name of the map cannot be ntothing.");  
        }

        bool hasALetter = false;
        for (int i = 0; i < value.Length; i++)
        {
          if (Char.IsLetter(value[i]))
          {
            hasALetter = true;
            break;
          }
        }

        if (!hasALetter)
        {
          throw new FormatException("The name of the map must contain at least 1 letter.");
        }

        name = value;
      }
    }

    public Version Version { get; set; }

    public PK_GameMode GameMode { get; set; }

    public Texture BackgroundImage
    {
      get
      {
        return backgroundImage;
      }
      set
      {
        backgroundImage = value;

        if (value != null)
        {
          // Resets the view area
          viewArea.X = 0;
          viewArea.Y = 0;
          ViewScale = 1;

          // TODO: Clear objects that are out of bounds (which don't intesect with the new global view area.

        }
        else
        {
          allItems.Clear();
          allSpawnAreas.Clear();
        }
      }
    }

    public float ViewScale
    {
      get
      {
        return viewScale;
      }
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException("value", "Scale must be positive.");
        }

        viewScale = value;

        // Changes the view area according to the new view scale.
        viewArea.Width = (int)(PK_MapEditor.GAMEMAP_WIDTH * value);
        viewArea.Height = (int)(PK_MapEditor.GAMEMAP_HEIGHT * value);
      }
    }

    #endregion

    #region Constructors

    private PK_Map()
    {
      viewArea = new PK_Area();
      BackgroundImage = null;
      Name = "Undefined";
      Version = new Version();
      GameMode = PK_GameMode.Undefined;
    }

    #endregion

    #region Methods

    #region Static Methods

    public static PK_Map GetInstance()
    {
      if (instance == null)
      {
        instance = new PK_Map();
      }

      return instance;
    }

    #endregion

    public void Delete()
    {
      instance = null;
    }

    public void AddItem(PK_Item item)
    {
      allItems.Add(item);
    }

    public void RemoveItem(PK_Item item)
    {
      if (!allItems.Contains(item))
      {
        throw new KeyNotFoundException("The item sent was not in the list of used items.");
      }

      allItems.Remove(item);
    }

    public void AddSpawnArea(PK_SpawnArea spawnArea)
    {
      allSpawnAreas.Add(spawnArea);
    }

    public void RemoveSpawnArea(PK_SpawnArea spawnArea)
    {
      if (!allSpawnAreas.Contains(spawnArea))
      {
        throw new KeyNotFoundException("The spawn area sent was not in the list of used items.");
      }

      allSpawnAreas.Remove(spawnArea);
    }

    public void SetViewScale(float scale)
    {

    }

    // TODO: Parse from file

    public override void Draw(RenderWindow window)
    {
      if (Visible)
      {
        // Draws the background depending of the view area.
        Sprite viewedBackground = new Sprite(BackgroundImage,
                                              new IntRect(viewArea.X, viewArea.Y, viewArea.Width, viewArea.Height));
        viewedBackground.Position = new Vector2f(0, 0);
        viewedBackground.Scale = new Vector2f(1 / viewScale, 1 / viewScale);
        window.Draw(viewedBackground);

        //TODO: Draw items spawn areas if they collide with the watch area

        //TODO: Draw items, spawn areas and borders larger if they are nearer
      }
    }

    #endregion
  }
}
