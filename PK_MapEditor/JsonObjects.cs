using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_MapEditor
{
  /* This file contains classes used
   * to interact with JSON map files.
   */

    public class Json_Map
    {
    public string name;
    public string version;
    public string mode;
    public string map;
    public string backgroundImage;
    public Json_MapItem[] items;
    public Json_SpawnArea[] spawnAreas;
    public int height;
    public int width;
    public Json_Border border;

    public Json_Map()
    {
      name = "";
      version = "";
      mode = "";
      backgroundImage = "";
      items = null;
      spawnAreas = null;
      height = 0;
      width = 0;
      border = null;
    }
  }

  public class Json_MapItem
  {
    public string name;
    public Json_Position position;

    public Json_MapItem()
    {
      name = "";
      position = null;
    }
  }

  public class Json_SpawnArea
  {
    public string type;
    public string name;
    public int height;
    public int width;
    public Json_Position position;

    public Json_SpawnArea()
    {
      type = "";
      name = "";
      height = 0;
      width = 0;
      position = null;
    }
  }

  public class Json_Position
  {
    public int x;
    public int y;

    public Json_Position()
    {
      x = 0;
      y = 0;
    }
  }

  public class Json_Border
  {
    public string type;
    public Json_Shape shape;
    public Json_Position center;

    public Json_Border()
    {
      type = "";
      shape = null;
      center = null;
    }
  }

  public class Json_Shape
  {
    public int radius;
    public int height;
    public int width;

    public Json_Shape()
    {
      radius = 0;
      height = 0;
      width = 0;
    }
  }

  public class Json_Item
  {
    public string name;
    public string path;
    public string img;
    public string thumbnail;
    public Json_Position position;
    public Json_Box box;
    public Json_Box collisionBox;

    public Json_Item()
    {
      name = "";
      path = "";
      img = "";
      thumbnail = "";
      position = null;
      box = null;
      collisionBox = null;
    }
  }

  public class Json_Box
  {
    public int offsetX;
    public int offsetY;
    public int width;
    public int height;

    public Json_Box()
    {
      offsetX = 0;
      offsetY = 0;
      width = 0;
      height = 0;
    }
  }

  public class Json_Monster
  {
    public string thumbnail;
    public string name;

    public Json_Monster()
    {
      thumbnail = "";
      name = "";
    }
  }
}
