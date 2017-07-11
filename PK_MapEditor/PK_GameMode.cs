using System;

namespace PK_MapEditor
{
  public enum PK_GameMode
  {
    Undefined,
    FreeForAll
  }

  public static class PK_GameModeOperations
  {
    public static string EnumToString(PK_GameMode enumValue)
    {
      switch(enumValue)
      {
        case PK_GameMode.Undefined:
          return "undefined";
        case PK_GameMode.FreeForAll:
          return "freeforall";
        default:
          throw new InvalidOperationException("The string conversion of the passed enum as not been coded yet.");
      }
    }
  }
}
