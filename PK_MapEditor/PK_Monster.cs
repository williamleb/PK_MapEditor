using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace PK_MapEditor
{
  /// <summary>
  /// This class represents a monster or a monster group to place
  /// in a spawn area.
  /// </summary>
  public class PK_Monster
  {
    #region Accessors
    
    /// <summary>
    /// Access the name of the monster.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Access the path of the monster's tumbnail.
    /// </summary>
    public string Thumbnail { get; private set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Build a monster.
    /// </summary>
    /// <param name="name">The name of the monster.</param>
    /// <param name="thumbnail">The path of the monster's tumbnail.</param>
    public PK_Monster(string name, string thumbnail)
    {
      Name = name;
      Thumbnail = thumbnail;
    }

    /// <summary>
    /// Build a monster from a parsed-from-JSON monster.
    /// </summary>
    /// <param name="jsonMonster">The parsed-from-JSON monster.</param>
    public PK_Monster(Json_Monster jsonMonster)
      :this(jsonMonster.name, "Assets/" + jsonMonster.thumbnail)
    {
    }

    #endregion
  }
}
