﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;

namespace PK_MapEditor
{
  public class PK_Map : PK_Drawable
  {

    #region Properties

    #region Static Properties

    static PK_Map instance = null;

    #endregion

    #region Lists

    List<PK_Drawable> allDrawables = new List<PK_Drawable>();

    List<PK_Drawable> allSeenDrawables = new List<PK_Drawable>();

    #endregion

    string name;

    float viewScale;

    PK_ViewArea viewArea;

    Texture backgroundImage;

    #endregion

    #region Accessors

    public PK_ViewArea ViewArea
    {
      get
      {
        return viewArea;
      }
      private set
      {
        viewArea = value;
      }
    }

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
          ViewArea.X = 0;
          ViewArea.Y = 0;
          ViewScale = 1;

          // TODO: Clear objects that are out of bounds (which don't intesect with the new global view area.

        }
        else
        {
          allDrawables.Clear();
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
        ViewArea.Width = (int)(PK_MapEditor.GAMEMAP_WIDTH * value);
        ViewArea.Height = (int)(PK_MapEditor.GAMEMAP_HEIGHT * value);
      }
    }

    #endregion

    #region Constructors

    private PK_Map()
    {
      ViewArea = new PK_ViewArea();
      BackgroundImage = null;
      Name = "Undefined";
      Version = new Version();
      GameMode = PK_GameMode.Undefined;

      AddDrawable(new PK_Area(20, 20, 100, 100));
      AddDrawable(new PK_CharacterSpawnArea(20, 20, 100, 100));
      AddDrawable(new PK_Item(JsonConvert.DeserializeObject<Json_Item>(File.ReadAllText("Assets/items/TestTree.json"))));
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

    public void AddDrawable(PK_Drawable drawable)
    {
      allDrawables.Add(drawable);
    }

    public void RemoveDrawable(PK_Drawable drawable)
    {
      if (!allDrawables.Contains(drawable))
      {
        throw new KeyNotFoundException("The item sent was not in the list of used items.");
      }

      allDrawables.Remove(drawable);
    }

    // TODO: Parse from file

    public override void Draw(RenderWindow window)
    {
      if (Visible)
      {
        // Draws the background depending of the view area.
        Sprite viewedBackground = new Sprite(BackgroundImage,
                                              new IntRect(ViewArea.X, ViewArea.Y, ViewArea.Width, ViewArea.Height));
        viewedBackground.Position = new Vector2f(0, 0);
        viewedBackground.Scale = new Vector2f(1 / viewScale, 1 / viewScale);
        window.Draw(viewedBackground);

        // Draws drawables that collide with the view area
        foreach (PK_Drawable drawable in allSeenDrawables)
        {
          drawable.Draw(window);
        }

        //TODO: Draw items, spawn areas and borders larger if they are nearer
      }
    }

    /// <summary>
    /// Updates the map.
    /// </summary>
    /// <param name="mouseX">The x coordinate of the mouse on the form.</param>
    /// <param name="mouseY">The y coordinate of the map on the form.</param>
    public void Update(int mouseX, int mouseY)
    {
      // Resets the list of seen drawables
      allSeenDrawables.Clear();

      // Determines the new seen drawables
      List<PK_Drawable> viewedDrawables = new List<PK_Drawable>();
      foreach(PK_Drawable drawable in allDrawables)
      {
        // In case of an area
        if (drawable is PK_Area)
        {
          PK_Area area = drawable as PK_Area;
          
          if (viewArea.CollideWith(area))
          {
            viewedDrawables.Add(area);
          }
        }
        // In case of an item
        else if (drawable is PK_Item)
        {
          PK_Item item = drawable as PK_Item;

          if (viewArea.CollideWith(item.SurroundingArea))
          {
            viewedDrawables.Add(item);
          }
        }
        // TODO: In case of a border
      }

      // Add the drawables that can be seen in the right list
      foreach(PK_Drawable drawable in viewedDrawables)
      {
        allSeenDrawables.Add(drawable);
      }
      

      // Updates the picked item
      if (PK_Movable.PickedItem != null)
      {
        int mapMouseX = GetMapXFromFormX(mouseX);
        int mapMouseY = GetMapYFromFormY(mouseY);
        PK_Movable.PickedItem.Update(mapMouseX, mapMouseY);
      }
    }

    /// <summary>
    /// Method called whenever the mouse buttons are pressed on the game map.
    /// Picks the clicked item or the background.
    /// </summary>
    public void OnMouseDown(object sender, MouseEventArgs e)
    {
      int mouseX = GetMapXFromGameMapX(e.X);
      int mouseY = GetMapYFromGameMapY(e.Y);

      bool somethingPiked = false;
      foreach(PK_Drawable drawable in allSeenDrawables)
      {
        PK_Movable movable = drawable as PK_Movable;
        if (movable is PK_Movable)
        {
          bool isPicked = false;
          // In case of a spawn area
          if (movable is PK_Area)
          {
            PK_Area area = movable as PK_Area;

            if (area.Contains(mouseX, mouseY))
            {
              isPicked = true;
            }
          }
          // In case of an item
          else if (movable is PK_Item)
          {
            PK_Item item = movable as PK_Item;

            if (item.SurroundingArea.Contains(mouseX, mouseY))
            {
              isPicked = true;
            }
          }
          // TODO: In case of a border

          if (isPicked)
          {
            movable.Select();
            movable.Pick(mouseX, mouseY);
            somethingPiked = true;
            break;
          }
        }
      }

      // If no item was picked, picks the view area.
      if (!somethingPiked)
      {
        viewArea.Pick(mouseX, mouseY);
      }
    }

    #region Coordinates converter

    /// <summary>
    /// Converts the form's X coordinate to the game map control's X coordinate.
    /// </summary>
    /// <param name="formX">The form's X coordinate.</param>
    /// <returns>The converted game map control's X coordinate.</returns>
    public int GetGameMapXFromFormX(int formX)
    {
      return formX - PK_MapEditor.GetInstance().GameMapControl.Left;
    }

    /// <summary>
    /// Converts the form's Y coordinate to the game map control's Y coordinate.
    /// </summary>
    /// <param name="formX">The form's Y coordinate.</param>
    /// <returns>The converted game map control's Y coordinate.</returns>
    public int GetGameMapYFromFormY(int formY)
    {
      return formY - PK_MapEditor.GetInstance().GameMapControl.Top;
    }

    /// <summary>
    /// Converts the form's X coordinate to the map's X coordinate.
    /// </summary>
    /// <param name="formX">The form's X coordinate.</param>
    /// <returns>The converted map's X coordinate.</returns>
    public int GetMapXFromFormX(int formX)
    {
      return GetMapXFromGameMapX(GetGameMapXFromFormX(formX));
    }

    /// <summary>
    /// Converts the form's Y coordinate to the map's Y coordinate.
    /// </summary>
    /// <param name="formX">The form's Y coordinate.</param>
    /// <returns>The converted map's Y coordinate.</returns>
    public int GetMapYFromFormY(int formY)
    {
      return GetMapYFromGameMapY(GetGameMapYFromFormY(formY));
    }

    /// <summary>
    /// Converts the game map control's X coordinate to the map's X coordinate.
    /// </summary>
    /// <param name="gameMapX">The game map control's X coordinate.</param>
    /// <returns>The map's X coordinate.</returns>
    public int GetMapXFromGameMapX(int gameMapX)
    {
      return (int)(gameMapX * ViewScale + ViewArea.X);
    }

    /// <summary>
    /// Converts the game map control's Y coordinate to the map's Y coordinate.
    /// </summary>
    /// <param name="gameMapX">The game map control's Y coordinate.</param>
    /// <returns>The map's Y coordinate.</returns>
    public int GetMapYFromGameMapY(int gameMapY)
    {
      return (int)(gameMapY * ViewScale + ViewArea.Y);
    }

    /// <summary>
    /// Converts the map's X coordinate to the game map control's X coordinate.
    /// </summary>
    /// <param name="mapX">The map's X coordinate.</param>
    /// <returns>The game map control's X coordinate.</returns>
    public int GetGameMapXFromMapX(int mapX)
    {
      return (int)(mapX / ViewScale - ViewArea.X/ViewScale);
    }

    /// <summary>
    /// Converts the map's Y coordinate to the game map control's Y coordinate.
    /// </summary>
    /// <param name="mapX">The map's Y coordinate.</param>
    /// <returns>The game map control's Y coordinate.</returns>
    public int GetGameMapYFromMapY(int mapY)
    {
      return (int)(mapY / ViewScale - ViewArea.Y/ViewScale);
    }

    #endregion

    #endregion
  }
}
