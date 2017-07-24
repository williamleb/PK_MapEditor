using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PK_MapEditor
{
  public class PK_SpawnArea : PK_Area
  {

    #region Accessors

    public string Name { get; protected set; }

    public Texture Image { get; protected set; }

    public bool Day { get; set; }

    public bool Dusk { get; set; }

    public bool Night { get; set; }

    public bool Dawn { get; set; }

    #endregion

    #region Constructor

    public PK_SpawnArea(int x, int y, int width, int height)
      :base(x, y, width, height)
    {
      Day = true;
      Dusk = true;
      Night = true;
      Dawn = true;
    }

    #endregion

    #region Methods

    public override void Draw(RenderWindow window)
    {
      if (Visible)
      {
        // Draw the image
        base.Draw(window);
      }
    }

    #endregion

  }

  public class PK_MonsterSpawnArea : PK_SpawnArea
  {
    PK_Monster monster;

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

    public PK_MonsterSpawnArea(PK_Area area, PK_Monster monster)
      :this(area.X, area.Y, area.Width, area.Height, monster)
    {
    }

    public PK_MonsterSpawnArea(int x, int y, int width, int height, PK_Monster monster)
      :base(x, y, width, height)
    {
      Monster = monster;
    }
  }

  public class PK_CharacterSpawnArea : PK_SpawnArea
  {
    private const string CHARACTER_SPAWN_AREA_NAME = "character";
    private const string CHARACTER_TUMBNAIL_PATH = "Assets/img/character_tumb.png";

    public PK_CharacterSpawnArea(PK_Area area)
      :this(area.X, area.Y, area.Width, area.Height)
    {
    }

    public PK_CharacterSpawnArea(int x, int y, int width, int height)
      :base(x, y, width, height)
    {
      Name = CHARACTER_SPAWN_AREA_NAME;
      Image = new Texture(CHARACTER_TUMBNAIL_PATH);
    }
  }

  public class PK_ItemSpawnArea : PK_SpawnArea
  {

    PK_Item item;

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

        // If the monster is not the same
        if (value != item)
        {
          // Ajusts the PK_SpawnArea's properties
          Name = value.Name;
          Image = new Texture(value.Thumbnail);

          // Change the monster
          item = value;
        }
      }
    }

    public PK_ItemSpawnArea(PK_Area area, PK_Item item)
      :this(area.X, area.Y, area.Width, area.Height, item)
    {
    }

    public PK_ItemSpawnArea(int x, int y, int width, int height, PK_Item item)
      :base(x, y, width, height)
    {
      Item = item;
    }
  }
}
