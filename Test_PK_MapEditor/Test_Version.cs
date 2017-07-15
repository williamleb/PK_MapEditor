using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PK_MapEditor;

namespace Test_PK_MapEditor
{
  /// <summary>
  /// Tests the Version class.
  /// During the tests, we assume that the Accessors Major, Minor and Patch are working as intended.
  /// </summary>
  [TestClass]
  public class Test_Version
  {
    #region Test_Version1

    /// <summary>
    ///  Tests the first constructor with valid parameters.
    /// </summary>
    [TestMethod]
    public void Test_Version1_01()
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
    public void Test_Version1_02()
    {
      PK_Version version = new PK_Version(-4, 2, 3);
    }

    /// <summary>
    /// Tests the first constructor with an invalid minor.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_Version1_03()
    {
      PK_Version version = new PK_Version(1, -2, 3);
    }

    /// <summary>
    /// Tests the first constructor with an invalid patch.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_Version1_04()
    {
      PK_Version version = new PK_Version(1, 2, -53);
    }

    #endregion

    #region Test_Version2

    /// <summary>
    ///  Tests the 2nd constructor.
    /// </summary>
    [TestMethod]
    public void Test_Version2_01()
    {
      PK_Version version = new PK_Version();

      Assert.AreEqual(0, version.Major);
      Assert.AreEqual(0, version.Minor);
      Assert.AreEqual(0, version.Patch);
    }

    #endregion

    #region Test_Version3

    /// <summary>
    ///  Tests the 3rd constructor with a valid parameter.
    /// </summary>
    [TestMethod]
    public void Test_Version3_01()
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
    public void Test_Version3_02()
    {
      PK_Version version = new PK_Version(-4);
    }

    #endregion

    #region Test_Version4

    /// <summary>
    ///  Tests the 4th constructor with valid parameters.
    /// </summary>
    [TestMethod]
    public void Test_Version4_01()
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
    public void Test_Version4_02()
    {
      PK_Version version = new PK_Version(2, -4);
    }

    #endregion

    #region Test_Version5

    /// <summary>
    ///  Tests the 5th constructor with valid parameters.
    /// </summary>
    [TestMethod]
    public void Test_Version5_01()
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
    public void Test_Version5_02()
    {
      PK_Version version = new PK_Version("-4.2.4");
    }

    /// <summary>
    /// Tests the 5th constructor with an invalid minor.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_Version5_03()
    {
      PK_Version version = new PK_Version("2.-2.2");
    }

    /// <summary>
    /// Tests the 5th constructor with an invalid patch.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_Version5_04()
    {
      PK_Version version = new PK_Version("5.1.-6");
    }

    /// <summary>
    /// Tests the 5th constructor with too many parameters.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Test_Version5_05()
    {
      PK_Version version = new PK_Version("5.1.6.5");
    }

    /// <summary>
    /// Tests the 5th constructor with too few parameters.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Test_Version5_06()
    {
      PK_Version version = new PK_Version("5");
    }

    /// <summary>
    /// Tests the 5th constructor with invalid parameters.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Test_Version5_07()
    {
      PK_Version version = new PK_Version("ab.2.@$");
    }

    #endregion
  }
}
