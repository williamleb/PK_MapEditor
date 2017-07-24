using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_MapEditor
{
  /// <summary>
  /// Represents a version on the format "major.minor.patch".
  /// </summary>
  public class PK_Version
  {
    #region Properties

    Int32 major, minor, patch;

    #endregion

    #region Accessors

    /// <summary>
    /// Access the version's major value.
    /// </summary>
    public Int32 Major
    {
      get
      {
        return major;
      }
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException("value");
        }
        major = value;
      }
    }

    /// <summary>
    /// Access the version's minor value.
    /// </summary>
    public Int32 Minor
    {
      get
      {
        return minor;
      }
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException("value");
        }
        minor = value;
      }
    }

    /// <summary>
    /// Access the version's patch value.
    /// </summary>
    public Int32 Patch
    {
      get
      {
        return patch;
      }
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException("value");
        }
        patch = value;
      }
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new version.
    /// </summary>
    /// <param name="major">The version's major value.</param>
    /// <param name="minor">The version's minor value.</param>
    /// <param name="patch">The version's patch value.</param>
    public PK_Version(Int32 major, Int32 minor, Int32 patch)
    {
      Set(major, minor, patch);
    }

    /// <summary>
    /// Creates a new empty version.
    /// </summary>
    public PK_Version()
      : this(0, 0, 0)
    {
    }

    /// <summary>
    /// Creates a new version.
    /// </summary>
    /// <param name="major">The version's major value.</param>
    public PK_Version(Int32 major)
      : this(major, 0, 0)
    {
    }

    /// <summary>
    /// Creates a new version.
    /// </summary>
    /// <param name="major">The version's major value.</param>
    /// <param name="minor">The version's minor value.</param>
    public PK_Version(Int32 major, Int32 minor)
      : this(major, minor, 0)
    {
    }

    /// <summary>
    /// Creates a new version with a string on the format "major.minor.patch"
    /// where major, minor and patch represents integers.
    /// </summary>
    /// <param name="version">The version string.</param>
    public PK_Version(string version)
    {
      string[] values = version.Split('.');

      if (values.Length != 3)
      {
        throw new FormatException("Version string is not the right format. Must be \"major.minor.patch\"");
      }

      try
      {
        Major = Int32.Parse(values[0]);
        Minor = Int32.Parse(values[1]);
        Patch = Int32.Parse(values[2]);
      }
      catch (FormatException)
      {
        throw new FormatException("Major, minor and patch values must be numbers.");
      }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Returns a string on the format "major.minor.patch" representing
    /// the version object.
    /// </summary>
    /// <returns>The version string</returns>
    public override string ToString()
    {
      return Major.ToString() + '.' + Minor.ToString() + '.' + Patch.ToString();
    }

    /// <summary>
    /// Give the version's numerical values.
    /// </summary>
    /// <param name="major">The version's major value.</param>
    /// <param name="minor">The version's minor value.</param>
    /// <param name="patch">The version's patch value.</param>
    public void ToInt32(out Int32 major, out Int32 minor, out Int32 patch)
    {
      major = Major;
      minor = Minor;
      patch = Patch;
    }

    /// <summary>
    /// Give the version's numerical values.
    /// </summary>
    /// <param name="major">The version's major value.</param>
    /// <param name="minor">The version's minor value.</param>
    public void ToInt32(out Int32 major, out Int32 minor)
    {
      major = this.major;
      minor = this.minor;
    }

    /// <summary>
    /// Add a major update to the version.
    /// </summary>
    public void AddMajor()
    {
      major++;
    }

    /// <summary>
    /// Remove a major update to the version.
    /// </summary>
    public void RemoveMajor()
    {
      if (major - 1 < 0)
      {
        throw new InvalidOperationException("The major value cannot go bellow 0");
      }
      major--;
    }

    /// <summary>
    /// Add a minor update to the version.
    /// </summary>
    public void AddMinor()
    {
      minor++;
    }

    /// <summary>
    /// Remove a minor update to the version.
    /// </summary>
    public void RemoveMinor()
    {
      if (minor - 1 < 0)
      {
        throw new InvalidOperationException("The minor value cannot go bellow 0");
      }
      minor--;
    }

    /// <summary>
    /// Add a patch update to the version.
    /// </summary>
    public void AddPatch()
    {
      patch++;
    }

    /// <summary>
    /// Remove a patch update to the version.
    /// </summary>
    public void RemovePatch()
    {
      if (patch - 1 < 0)
      {
        throw new InvalidOperationException("The patch value cannot go bellow 0");
      }
      patch--;
    }

    /// <summary>
    /// Resets the version to 0.0.0.
    /// </summary>
    public void Clear()
    {
      Major = Minor = Patch = 0;
    }

    /// <summary>
    /// Sets a new version.
    /// </summary>
    /// <param name="major">The new version's major value.</param>
    /// <param name="minor">The new version's minor value.</param>
    /// <param name="patch">The new version's patch value.</param>
    public void Set(Int32 major, Int32 minor, Int32 patch)
    {
      Major = major;
      Minor = minor;
      Patch = patch;
    }

    /// <summary>
    /// Sets a new version.
    /// </summary>
    /// <param name="major">The new version's major value.</param>
    /// <param name="minor">The new version's minor value.</param>
    public void Set(Int32 major, Int32 minor)
    {
      Major = major;
      Minor = minor;
      Patch = 0;
    }

    /// <summary>
    /// Sets a new version.
    /// </summary>
    /// <param name="major">The new version's major value.</param>
    public void Set(Int32 major)
    {
      Major = major;
      Minor = 0;
      Patch = 0;
    }

    #endregion
  }
}
