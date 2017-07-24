using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_MapEditor
{
  /// <summary>
  /// Represents the dfferent possible shapes for a border.
  /// </summary>
  public enum PK_BorderShape
  {
    Undefined,
    Circle,
    Rectangle
  }

  /// <summary>
  /// Class containing operation for the enum PK_BorderShape.
  /// </summary>
  public static class PK_BorderShapeOperations
  {
    /// <summary>
    /// Transform a PK_BorderShape enum into a string.
    /// </summary>
    /// <param name="borderShape">The enum to transform.</param>
    /// <returns></returns>
    public static string EnumToString(PK_BorderShape borderShape)
    {
      switch (borderShape)
      {
        case PK_BorderShape.Undefined:
          return "undefined";
        case PK_BorderShape.Circle:
          return "circle";
        case PK_BorderShape.Rectangle:
          return "rectangle";
        default:
          throw new InvalidOperationException("The string conversion of the passed enum as not been coded yet.");
      }
    }

    /// <summary>
    /// Transform a string into a PK_BorderShape enum.
    /// </summary>
    /// <param name="borderShape">The string to transform.</param>
    /// <returns></returns>
    public static PK_BorderShape StringToEnum(string borderShape)
    {
      switch (borderShape)
      {
        case "undefined":
          return PK_BorderShape.Undefined;
        case "circle":
          return PK_BorderShape.Circle;
        case "rectangle":
          return PK_BorderShape.Rectangle;
        default:
          throw new InvalidOperationException("The enum conversion of the passed string as not been coded yet or is not defined.");
      }
    }
  }
}
