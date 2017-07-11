using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PK_MapEditor
{
  public class PK_Map
  {

    #region Properties

    #region Static Properties

    static PK_Map instance = null;

    #endregion

    #region SFML Properties

    Texture backgroundImage = null;

    #endregion

    #region Lists

    List<PK_Item> allItems = new List<PK_Item>();

    List<PK_SpawnArea> allSpawnAreas = new List<PK_SpawnArea>();

    #endregion

    string name;

    #endregion

    #region Accessors
    
    string FileName
    {
      get
      {
        return name.Replace(" ", "") + '_' + PK_GameModeOperations.EnumToString(GameMode) + ".json";
      }
    }
    
    string Name
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

    Version Version { get; set; }

    PK_GameMode GameMode { get; set; }

    #endregion

    private PK_Map()
    {
      //backgroundImage = new Texture(""); ???
      Name = "Undefined";
      Version = new Version();
      GameMode = PK_GameMode.Undefined;
    }

    public PK_Map GetInstance()
    {
      if (instance == null)
      {
        instance = new PK_Map();
      }

      return instance;
    }

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

    // TODO : GetInstace, Parse from file
  }
}
