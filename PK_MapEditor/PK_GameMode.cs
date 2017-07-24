using System;

namespace PK_MapEditor
{
  /// <summary>
  /// Represents the different gamemodes for a map.
  /// </summary>
  public enum PK_GameMode
  {
    Undefined,
    FreeForAll
  }

  /// <summary>
  /// Class containing operation for the enum PK_GameMode.
  /// </summary>
  public static class PK_GameModeOperations
  {
    /// <summary>
    /// Transform a PK_GameMode enum into a string.
    /// </summary>
    /// <param name="gameMode">The enum to transform.</param>
    /// <returns></returns>
    public static string EnumToString(PK_GameMode gameMode)
    {
      switch(gameMode)
      {
        case PK_GameMode.Undefined:
          return "undefined";
        case PK_GameMode.FreeForAll:
          return "freeforall";
        default:
          throw new InvalidOperationException("The string conversion of the passed enum as not been coded yet.");
      }
    }

    /// <summary>
    /// Transform a string into a PK_GameMode enum.
    /// </summary>
    /// <param name="gameMode">The string to transform.</param>
    /// <returns></returns>
    public static PK_GameMode StringToEnum(string gameMode)
    {
      switch (gameMode)
      {
        case "undefined":
          return PK_GameMode.Undefined;
        case "freeforall":
          return PK_GameMode.FreeForAll;
        default:
          throw new InvalidOperationException("The enum conversion of the passed string as not been coded yet or is not defined.");
      }
    }
  }
}
