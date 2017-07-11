using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PK_MapEditor;

namespace Test_PK_MapEditor
{
  /// <summary>
  /// Tests the PK_Version class.
  /// During the tests, we assume that the Accessors Major, Minor and Patch are working as intended.
  /// </summary>
  [TestClass]
  public class Test_PK_Version
  {
    #region Test_PK_Version

    #region Test_PK_Version1

    /// <summary>
    ///  Tests the first constructor with valid parameters.
    /// </summary>
    [TestMethod]
    public void Test_PK_Version1_01()
    {
      PK_Version version = new PK_Version(1, 2, 3);

      Assert.AreEqual(1, version.Major);
      Assert.AreEqual(2, version.Minor);
      Assert.AreEqual(3, version.Patch);
    }

    /// <summary>
    /// Tests the first constructor with an invalid major.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_PK_Version1_02()
    {
      PK_Version version = new PK_Version(-4, 2, 3);
    }

    /// <summary>
    /// Tests the first constructor with an invalid minor.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_PK_Version1_03()
    {
      PK_Version version = new PK_Version(1, -2, 3);
    }

    /// <summary>
    /// Tests the first constructor with an invalid patch.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_PK_Version1_04()
    {
      PK_Version version = new PK_Version(1, 2, -53);
    }

    #endregion

    #region Test_PK_Version2

    /// <summary>
    ///  Tests the 2nd constructor.
    /// </summary>
    [TestMethod]
    public void Test_PK_Version2_01()
    {
      PK_Version version = new PK_Version();

      Assert.AreEqual(0, version.Major);
      Assert.AreEqual(0, version.Minor);
      Assert.AreEqual(0, version.Patch);
    }

    #endregion

    #region Test_PK_Version3

    /// <summary>
    ///  Tests the 3rd constructor with a valid parameter.
    /// </summary>
    [TestMethod]
    public void Test_PK_Version3_01()
    {
      PK_Version version = new PK_Version(32);

      Assert.AreEqual(32, version.Major);
      Assert.AreEqual(0, version.Minor);
      Assert.AreEqual(0, version.Patch);
    }

    /// <summary>
    /// Tests the 3rd constructor with an invalid major.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_PK_Version3_02()
    {
      PK_Version version = new PK_Version(-4);
    }

    #endregion

    #region Test_PK_Version4

    /// <summary>
    ///  Tests the 4th constructor with valid parameters.
    /// </summary>
    [TestMethod]
    public void Test_PK_Version4_01()
    {
      PK_Version version = new PK_Version(2, 41);

      Assert.AreEqual(2, version.Major);
      Assert.AreEqual(41, version.Minor);
      Assert.AreEqual(0, version.Patch);
    }

    /// <summary>
    /// Tests the 4th constructor with an invalid minor.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_PK_Version4_02()
    {
      PK_Version version = new PK_Version(2, -4);
    }

    #endregion

    #region Test_PK_Version5

    /// <summary>
    ///  Tests the 5th constructor with valid parameters.
    /// </summary>
    [TestMethod]
    public void Test_PK_Version5_01()
    {
      PK_Version version = new PK_Version("1.2.3");

      Assert.AreEqual(1, version.Major);
      Assert.AreEqual(2, version.Minor);
      Assert.AreEqual(3, version.Patch);
    }

    /// <summary>
    /// Tests the 5th constructor with an invalid major.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_PK_Version5_02()
    {
      PK_Version version = new PK_Version("-4.2.4");
    }

    /// <summary>
    /// Tests the 5th constructor with an invalid minor.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_PK_Version5_03()
    {
      PK_Version version = new PK_Version("2.-2.2");
    }

    /// <summary>
    /// Tests the 5th constructor with an invalid patch.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_PK_Version5_04()
    {
      PK_Version version = new PK_Version("5.1.-6");
    }

    /// <summary>
    /// Tests the 5th constructor with too many parameters.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Test_PK_Version5_05()
    {
      PK_Version version = new PK_Version("5.1.6.5");
    }

    /// <summary>
    /// Tests the 5th constructor with too few parameters.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Test_PK_Version5_06()
    {
      PK_Version version = new PK_Version("5");
    }

    /// <summary>
    /// Tests the 5th constructor with invalid parameters.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Test_PK_Version5_07()
    {
      PK_Version version = new PK_Version("ab.2.@$");
    }

    #endregion

    #endregion

    #region Test_ToString

    /// <summary>
    /// Tests if the returned string is valid
    /// </summary>
    [TestMethod]
    public void Test_ToString_01()
    {
      PK_Version version = new PK_Version(1, 2, 3);

      Assert.AreEqual(version.ToString(), "1.2.3");
    }

    #endregion

    #region Test_ToInt32

    #region Test_ToInt321

    /// <summary>
    /// Tests if the returned values are valid
    /// </summary>
    [TestMethod]
    public void Test_ToInt321_01()
    {
      int major, minor, patch;
      PK_Version version = new PK_Version(1, 2, 3);

      version.ToInt32(out major, out minor, out patch);

      Assert.AreEqual(major, 1);
      Assert.AreEqual(minor, 2);
      Assert.AreEqual(patch, 3);
    }

    #endregion

    #region Test_ToInt322

    /// <summary>
    /// Tests if the returned values are valid
    /// </summary>
    [TestMethod]
    public void Test_ToInt322_01()
    {
      int major, minor;
      PK_Version version = new PK_Version(1, 2, 3);

      version.ToInt32(out major, out minor);

      Assert.AreEqual(major, 1);
      Assert.AreEqual(minor, 2);
    }

    #endregion

    #endregion

    #region Test_AddMajor

    /// <summary>
    /// Test adding a major update on a normal situation
    /// </summary>
    [TestMethod]
    public void Test_AddMajor_01()
    {
      PK_Version version = new PK_Version(1, 1, 1);

      version.AddMajor();

      Assert.AreEqual(version.Major, 2);
    }

    /// <summary>
    /// Test adding a major update when the major value is at 0
    /// </summary>
    [TestMethod]
    public void Test_AddMajor_02()
    {
      PK_Version version = new PK_Version(0, 0, 0);

      version.AddMajor();

      Assert.AreEqual(version.Major, 1);
    }

    #endregion

    #region Test_RemoveMajor

    /// <summary>
    /// Test removing a major update on a normal situation
    /// </summary>
    [TestMethod]
    public void Test_RemoveMajor_01()
    {
      PK_Version version = new PK_Version(1, 1, 1);

      version.RemoveMajor();

      Assert.AreEqual(version.Major, 0);
    }

    /// <summary>
    /// Test removing a major update when the major value is at 0
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Test_RemoveMajor_02()
    {
      PK_Version version = new PK_Version(0, 0, 0);

      version.RemoveMajor();
    }

    #endregion

    #region Test_AddMinor

    /// <summary>
    /// Test adding a minor update on a normal situation
    /// </summary>
    [TestMethod]
    public void Test_AddMinor_01()
    {
      PK_Version version = new PK_Version(1, 1, 1);

      version.AddMinor();

      Assert.AreEqual(version.Minor, 2);
    }

    /// <summary>
    /// Test adding a minor update when the minor value is at 0
    /// </summary>
    [TestMethod]
    public void Test_AddMinor_02()
    {
      PK_Version version = new PK_Version(0, 0, 0);

      version.AddMinor();

      Assert.AreEqual(version.Minor, 1);
    }

    #endregion

    #region Test_RemoveMinor

    /// <summary>
    /// Test removing a minor update on a normal situation
    /// </summary>
    [TestMethod]
    public void Test_RemoveMinor_01()
    {
      PK_Version version = new PK_Version(1, 1, 1);

      version.RemoveMinor();

      Assert.AreEqual(version.Minor, 0);
    }

    /// <summary>
    /// Test removing a minor update when the minor value is at 0
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Test_RemoveMinor_02()
    {
      PK_Version version = new PK_Version(0, 0, 0);

      version.RemoveMinor();
    }

    #endregion

    #region Test_AddPatch

    /// <summary>
    /// Test adding a patch update on a normal situation
    /// </summary>
    [TestMethod]
    public void Test_AddPatch_01()
    {
      PK_Version version = new PK_Version(1, 1, 1);

      version.AddPatch();

      Assert.AreEqual(version.Patch, 2);
    }

    /// <summary>
    /// Test adding a patch update when the patch value is at 0
    /// </summary>
    [TestMethod]
    public void Test_AddPatch_02()
    {
      PK_Version version = new PK_Version(0, 0, 0);

      version.AddPatch();

      Assert.AreEqual(version.Patch, 1);
    }

    #endregion

    #region Test_RemovePatch

    /// <summary>
    /// Test removing a patch update on a normal situation
    /// </summary>
    [TestMethod]
    public void Test_RemovePatch_01()
    {
      PK_Version version = new PK_Version(1, 1, 1);

      version.RemovePatch();

      Assert.AreEqual(version.Patch, 0);
    }

    /// <summary>
    /// Test removing a patch update when the patch value is at 0
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Test_RemovePatch_02()
    {
      PK_Version version = new PK_Version(0, 0, 0);

      version.RemovePatch();
    }

    #endregion

    #region Test_Clear

    /// <summary>
    /// Tests that the version clears correctly on method's call
    /// </summary>
    [TestMethod]
    public void Test_Clear_01()
    {
      PK_Version version = new PK_Version(1, 2, 3);

      version.Clear();

      Assert.AreEqual(version.Major, 0);
      Assert.AreEqual(version.Minor, 0);
      Assert.AreEqual(version.Patch, 0);
    }

    #endregion

    #region Test_Set

    #region Test_Set1

    /// <summary>
    ///  Tests the first set with valid parameters.
    /// </summary>
    [TestMethod]
    public void Test_Set1_01()
    {
      PK_Version version = new PK_Version();

      version.Set(1, 2, 3);

      Assert.AreEqual(1, version.Major);
      Assert.AreEqual(2, version.Minor);
      Assert.AreEqual(3, version.Patch);
    }

    /// <summary>
    /// Tests the first set with an invalid major.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_Set1_02()
    {
      PK_Version version = new PK_Version();

      version.Set(-4, 2, 3);
    }

    /// <summary>
    /// Tests the first set with an invalid minor.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_Set1_03()
    {
      PK_Version version = new PK_Version();

      version.Set(1, -2, 3);
    }

    /// <summary>
    /// Tests the first set with an invalid patch.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_Set1_04()
    {
      PK_Version version = new PK_Version();

      version.Set(1, 2, -3);
    }

    #endregion

    #region Test_Set2

    /// <summary>
    ///  Tests the 2nd set with a valid parameter.
    /// </summary>
    [TestMethod]
    public void Test_Set2_01()
    {
      PK_Version version = new PK_Version();

      version.Set(32);

      Assert.AreEqual(32, version.Major);
      Assert.AreEqual(0, version.Minor);
      Assert.AreEqual(0, version.Patch);
    }

    /// <summary>
    /// Tests the 2nd set with an invalid major.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_Set2_02()
    {
      PK_Version version = new PK_Version();

      version.Set(-4);
    }

    /// <summary>
    ///  Tests non-specified parameters are set to 0.
    /// </summary>
    [TestMethod]
    public void Test_Set2_03()
    {
      PK_Version version = new PK_Version(4, 4, 4);

      version.Set(32);

      Assert.AreEqual(32, version.Major);
      Assert.AreEqual(0, version.Minor);
      Assert.AreEqual(0, version.Patch);
    }

    #endregion

    #region Test_Set3

    /// <summary>
    ///  Tests the 3rd set with valid parameters.
    /// </summary>
    [TestMethod]
    public void Test_Set3_01()
    {
      PK_Version version = new PK_Version();

      version.Set(2, 41);

      Assert.AreEqual(2, version.Major);
      Assert.AreEqual(41, version.Minor);
      Assert.AreEqual(0, version.Patch);
    }

    /// <summary>
    /// Tests the 3rd set with an invalid minor.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_Set3_02()
    {
      PK_Version version = new PK_Version(2, -4);

      version.Set(2, -4);
    }

    /// <summary>
    ///  Tests non-specified parameters are set to 0.
    /// </summary>
    [TestMethod]
    public void Test_Set3_03()
    {
      PK_Version version = new PK_Version(4, 4, 3);

      version.Set(2, 41);

      Assert.AreEqual(2, version.Major);
      Assert.AreEqual(41, version.Minor);
      Assert.AreEqual(0, version.Patch);
    }

    #endregion

    #endregion
  }
}
