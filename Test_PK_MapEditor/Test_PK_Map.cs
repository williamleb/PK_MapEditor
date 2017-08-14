using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PK_MapEditor;
using System.Windows.Forms;

namespace Test_PK_MapEditor
{
  /// <summary>
  /// Tests the PK_Map class.
  /// </summary>
  [TestClass]
  public class Test_PK_Map
  {

    // Each point represent a specific position on the form related to the game map control (if it is placed at (20, 20)).
    // Point 1 is left;
    // Point 2 is top;
    // Point 3 is right;
    // Point 4 is bottom;
    // Point 5 is on its top-left corner;
    // Point 6 is on the control surface.
    Point[] FormPoints = new Point[] {
                                      new Point(10, 20),
                                      new Point(20, 10),
                                      new Point(30, 20),
                                      new Point(20, 30),
                                      new Point(20, 20),
                                      new Point(30, 30)
                                    };

    #region Test_GetGameMapXFromFormX

    /// <summary>
    /// Tests if the first point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetGameMapXFromFormX_01()
    {
      // Prepare the form and its game map control.
      PK_MapEditor.PK_MapEditor mapForm = PK_MapEditor.PK_MapEditor.GetInstance();
      mapForm.GameMapControl.Left = mapForm.GameMapControl.Top = 20;
      mapForm.GameMapControl.Width = mapForm.GameMapControl.Height = 100;

      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();

      // Tests the method.
      Assert.AreEqual(-10, map.GetGameMapXFromFormX(FormPoints[0].X));

      // Clean-up
      mapForm.Delete();
      map.Delete();
    }

    /// <summary>
    /// Tests if the second point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetGameMapXFromFormX_02()
    {
      // Prepare the form and its game map control.
      PK_MapEditor.PK_MapEditor mapForm = PK_MapEditor.PK_MapEditor.GetInstance();
      mapForm.GameMapControl.Left = mapForm.GameMapControl.Top = 20;
      mapForm.GameMapControl.Width = mapForm.GameMapControl.Height = 100;

      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();

      // Tests the method.
      Assert.AreEqual(0, map.GetGameMapXFromFormX(FormPoints[1].X));

      // Clean-up
      mapForm.Delete();
      map.Delete();
    }

    /// <summary>
    /// Tests if the third point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetGameMapXFromFormX_03()
    {
      // Prepare the form and its game map control.
      PK_MapEditor.PK_MapEditor mapForm = PK_MapEditor.PK_MapEditor.GetInstance();
      mapForm.GameMapControl.Left = mapForm.GameMapControl.Top = 20;
      mapForm.GameMapControl.Width = mapForm.GameMapControl.Height = 100;

      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();

      // Tests the method.
      Assert.AreEqual(10, map.GetGameMapXFromFormX(FormPoints[2].X));

      // Clean-up
      mapForm.Delete();
      map.Delete();
    }

    /// <summary>
    /// Tests if the fourth point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetGameMapXFromFormX_04()
    {
      // Prepare the form and its game map control.
      PK_MapEditor.PK_MapEditor mapForm = PK_MapEditor.PK_MapEditor.GetInstance();
      mapForm.GameMapControl.Left = mapForm.GameMapControl.Top = 20;
      mapForm.GameMapControl.Width = mapForm.GameMapControl.Height = 100;

      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();

      // Tests the method.
      Assert.AreEqual(0, map.GetGameMapXFromFormX(FormPoints[3].X));

      // Clean-up
      mapForm.Delete();
      map.Delete();
    }

    /// <summary>
    /// Tests if the fifth point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetGameMapXFromFormX_05()
    {
      // Prepare the form and its game map control.
      PK_MapEditor.PK_MapEditor mapForm = PK_MapEditor.PK_MapEditor.GetInstance();
      mapForm.GameMapControl.Left = mapForm.GameMapControl.Top = 20;
      mapForm.GameMapControl.Width = mapForm.GameMapControl.Height = 100;

      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();

      // Tests the method.
      Assert.AreEqual(0, map.GetGameMapXFromFormX(FormPoints[4].X));

      // Clean-up
      mapForm.Delete();
      map.Delete();
    }

    /// <summary>
    /// Tests if the sixth point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetGameMapXFromFormX_06()
    {
      // Prepare the form and its game map control.
      PK_MapEditor.PK_MapEditor mapForm = PK_MapEditor.PK_MapEditor.GetInstance();
      mapForm.GameMapControl.Left = mapForm.GameMapControl.Top = 20;
      mapForm.GameMapControl.Width = mapForm.GameMapControl.Height = 100;

      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();

      // Tests the method.
      Assert.AreEqual(10, map.GetGameMapXFromFormX(FormPoints[5].X));

      // Clean-up
      mapForm.Delete();
      map.Delete();
    }

    #endregion

    #region Test_GetGameMapYFromFormY

    /// <summary>
    /// Tests if the first point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetGameMapYFromFormY_01()
    {
      // Prepare the form and its game map control.
      PK_MapEditor.PK_MapEditor mapForm = PK_MapEditor.PK_MapEditor.GetInstance();
      mapForm.GameMapControl.Left = mapForm.GameMapControl.Top = 20;
      mapForm.GameMapControl.Width = mapForm.GameMapControl.Height = 100;

      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();

      // Tests the method.
      Assert.AreEqual(0, map.GetGameMapYFromFormY(FormPoints[0].Y));

      // Clean-up
      mapForm.Delete();
      map.Delete();
    }

    /// <summary>
    /// Tests if the second point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetGameMapYFromFormY_02()
    {
      // Prepare the form and its game map control.
      PK_MapEditor.PK_MapEditor mapForm = PK_MapEditor.PK_MapEditor.GetInstance();
      mapForm.GameMapControl.Left = mapForm.GameMapControl.Top = 20;
      mapForm.GameMapControl.Width = mapForm.GameMapControl.Height = 100;

      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();

      // Tests the method.
      Assert.AreEqual(-10, map.GetGameMapYFromFormY(FormPoints[1].Y));

      // Clean-up
      mapForm.Delete();
      map.Delete();
    }

    /// <summary>
    /// Tests if the third point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetGameMapYFromFormY_03()
    {
      // Prepare the form and its game map control.
      PK_MapEditor.PK_MapEditor mapForm = PK_MapEditor.PK_MapEditor.GetInstance();
      mapForm.GameMapControl.Left = mapForm.GameMapControl.Top = 20;
      mapForm.GameMapControl.Width = mapForm.GameMapControl.Height = 100;

      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();

      // Tests the method.
      Assert.AreEqual(0, map.GetGameMapYFromFormY(FormPoints[2].Y));

      // Clean-up
      mapForm.Delete();
      map.Delete();
    }

    /// <summary>
    /// Tests if the fourth point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetGameMapYFromFormY_04()
    {
      // Prepare the form and its game map control.
      PK_MapEditor.PK_MapEditor mapForm = PK_MapEditor.PK_MapEditor.GetInstance();
      mapForm.GameMapControl.Left = mapForm.GameMapControl.Top = 20;
      mapForm.GameMapControl.Width = mapForm.GameMapControl.Height = 100;

      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();

      // Tests the method.
      Assert.AreEqual(10, map.GetGameMapYFromFormY(FormPoints[3].Y));

      // Clean-up
      mapForm.Delete();
      map.Delete();
    }

    /// <summary>
    /// Tests if the fifth point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetGameMapYFromFormY_05()
    {
      // Prepare the form and its game map control.
      PK_MapEditor.PK_MapEditor mapForm = PK_MapEditor.PK_MapEditor.GetInstance();
      mapForm.GameMapControl.Left = mapForm.GameMapControl.Top = 20;
      mapForm.GameMapControl.Width = mapForm.GameMapControl.Height = 100;

      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();

      // Tests the method.
      Assert.AreEqual(0, map.GetGameMapYFromFormY(FormPoints[4].Y));

      // Clean-up
      mapForm.Delete();
      map.Delete();
    }

    /// <summary>
    /// Tests if the sixth point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetGameMapYFromFormY_06()
    {
      // Prepare the form and its game map control.
      PK_MapEditor.PK_MapEditor mapForm = PK_MapEditor.PK_MapEditor.GetInstance();
      mapForm.GameMapControl.Left = mapForm.GameMapControl.Top = 20;
      mapForm.GameMapControl.Width = mapForm.GameMapControl.Height = 100;

      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();

      // Tests the method.
      Assert.AreEqual(10, map.GetGameMapYFromFormY(FormPoints[5].Y));

      // Clean-up
      mapForm.Delete();
      map.Delete();
    }

    #endregion

    // Each point represent a specific position from the game map or the map.
    // Point 1 is left;
    // Point 2 is top;
    // Point 3 is right;
    // Point 4 is bottom;
    // Point 5 is on its top-left corner;
    // Point 6 is diagonal bottom-right;
    // Point 7 is diagonal top-left.
    Point[] GamePoints = new Point[] {
                                      new Point(-10, 0),
                                      new Point(0, -10),
                                      new Point(10, 0),
                                      new Point(0, 10),
                                      new Point(0, 0),
                                      new Point(10, 10),
                                      new Point(-10, -10)
                                    };

    #region Test_GetMapXFromGameMapX

    /// <summary>
    /// Tests if the first point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_01()
    {
      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(-10, map.GetMapXFromGameMapX(GamePoints[0].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the second point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_02()
    {
      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(0, map.GetMapXFromGameMapX(GamePoints[1].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the third point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_03()
    {
      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(10, map.GetMapXFromGameMapX(GamePoints[2].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the fourth point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_04()
    {
      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(0, map.GetMapXFromGameMapX(GamePoints[3].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the fifth point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_05()
    {
      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(0, map.GetMapXFromGameMapX(GamePoints[4].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the sixth point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_06()
    {
      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(10, map.GetMapXFromGameMapX(GamePoints[5].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the first point is evaluated correctly when the view is scrolled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_07()
    {
      // Initializes the map class (scroll by 10).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(0, map.GetMapXFromGameMapX(GamePoints[0].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the second point is evaluated correctly when the view is scrolled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_08()
    {
      // Initializes the map class (scroll by 10).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(10, map.GetMapXFromGameMapX(GamePoints[1].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the third point is evaluated correctly when the view is scrolled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_09()
    {
      // Initializes the map class (scroll by 10).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(20, map.GetMapXFromGameMapX(GamePoints[2].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the fourth point is evaluated correctly when the view is scrolled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_10()
    {
      // Initializes the map class (scroll by 10).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(10, map.GetMapXFromGameMapX(GamePoints[3].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the fifth point is evaluated correctly when the view is scrolled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_11()
    {
      // Initializes the map class (scroll by 10).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(10, map.GetMapXFromGameMapX(GamePoints[4].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the sixth point is evaluated correctly when the view is scrolled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_12()
    {
      // Initializes the map class (scroll by 10).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(20, map.GetMapXFromGameMapX(GamePoints[5].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the seventh point is evaluated correctly when the view is scaled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_13()
    {
      // Initializes the map class (scale by a factor of 2).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 2.0f;

      // Tests the method.
      Assert.AreEqual(-20, map.GetMapXFromGameMapX(GamePoints[6].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the fifth point is evaluated correctly when the view is scaled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_14()
    {
      // Initializes the map class (scale by a factor of 2).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 2.0f;

      // Tests the method.
      Assert.AreEqual(0, map.GetMapXFromGameMapX(GamePoints[4].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the sixth point is evaluated correctly when the view is scaled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_15()
    {
      // Initializes the map class (scale by a factor of 2).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 2.0f;

      // Tests the method.
      Assert.AreEqual(20, map.GetMapXFromGameMapX(GamePoints[5].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the seventh point is evaluated correctly when the view is scrolled and scaled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_16()
    {
      // Initializes the map class (scroll by 10 and scale by a factor of 0.5).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 0.5f;

      // Tests the method.
      Assert.AreEqual(0, map.GetMapXFromGameMapX(GamePoints[6].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the fifth point is evaluated correctly when the view is scrolled and scaled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_17()
    {
      // Initializes the map class (scroll by 10 and scale by a factor of 0.5).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 0.5f;

      // Tests the method.
      Assert.AreEqual(5, map.GetMapXFromGameMapX(GamePoints[4].X));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the sixth point is evaluated correctly when the view is scrolled and scaled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapXFromGameMapX_18()
    {
      // Initializes the map class (scroll by 10 and scale by a factor of 0.5).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 0.5f;

      // Tests the method.
      Assert.AreEqual(10, map.GetMapXFromGameMapX(GamePoints[5].X));

      // Clean-up
      map.Delete();
    }

    #endregion

    #region Test_GetMapYFromGameMapY

    /// <summary>
    /// Tests if the first point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_01()
    {
      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(0, map.GetMapYFromGameMapY(GamePoints[0].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the second point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_02()
    {
      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(-10, map.GetMapYFromGameMapY(GamePoints[1].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the third point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_03()
    {
      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(0, map.GetMapYFromGameMapY(GamePoints[2].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the fourth point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_04()
    {
      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(10, map.GetMapYFromGameMapY(GamePoints[3].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the fifth point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_05()
    {
      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(0, map.GetMapYFromGameMapY(GamePoints[4].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the sixth point is evaluated correctly.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_06()
    {
      // Initializes the map class.
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(10, map.GetMapYFromGameMapY(GamePoints[5].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the first point is evaluated correctly when the view is scrolled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_07()
    {
      // Initializes the map class (scroll by 10).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(10, map.GetMapYFromGameMapY(GamePoints[0].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the second point is evaluated correctly when the view is scrolled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_08()
    {
      // Initializes the map class (scroll by 10).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(0, map.GetMapYFromGameMapY(GamePoints[1].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the third point is evaluated correctly when the view is scrolled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_09()
    {
      // Initializes the map class (scroll by 10).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(10, map.GetMapYFromGameMapY(GamePoints[2].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the fourth point is evaluated correctly when the view is scrolled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_10()
    {
      // Initializes the map class (scroll by 10).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(20, map.GetMapYFromGameMapY(GamePoints[3].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the fifth point is evaluated correctly when the view is scrolled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_11()
    {
      // Initializes the map class (scroll by 10).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(10, map.GetMapYFromGameMapY(GamePoints[4].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the sixth point is evaluated correctly when the view is scrolled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_12()
    {
      // Initializes the map class (scroll by 10).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 1.0f;

      // Tests the method.
      Assert.AreEqual(20, map.GetMapYFromGameMapY(GamePoints[5].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the seventh point is evaluated correctly when the view is scaled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_13()
    {
      // Initializes the map class (scale by a factor of 2).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 2.0f;

      // Tests the method.
      Assert.AreEqual(-20, map.GetMapYFromGameMapY(GamePoints[6].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the fifth point is evaluated correctly when the view is scaled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_14()
    {
      // Initializes the map class (scale by a factor of 2).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 2.0f;

      // Tests the method.
      Assert.AreEqual(0, map.GetMapYFromGameMapY(GamePoints[4].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the sixth point is evaluated correctly when the view is scaled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_15()
    {
      // Initializes the map class (scale by a factor of 2).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 0;
      map.ViewArea.Y = 0;
      map.ViewScale = 2.0f;

      // Tests the method.
      Assert.AreEqual(20, map.GetMapYFromGameMapY(GamePoints[5].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the seventh point is evaluated correctly when the view is scrolled and scaled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_16()
    {
      // Initializes the map class (scroll by 10 and scale by a factor of 0.5).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 0.5f;

      // Tests the method.
      Assert.AreEqual(0, map.GetMapYFromGameMapY(GamePoints[6].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the fifth point is evaluated correctly when the view is scrolled and scaled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_17()
    {
      // Initializes the map class (scroll by 10 and scale by a factor of 0.5).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 0.5f;

      // Tests the method.
      Assert.AreEqual(5, map.GetMapYFromGameMapY(GamePoints[4].Y));

      // Clean-up
      map.Delete();
    }

    /// <summary>
    /// Tests if the sixth point is evaluated correctly when the view is scrolled and scaled.
    /// </summary>
    [TestMethod]
    public void Test_GetMapYFromGameMapY_18()
    {
      // Initializes the map class (scroll by 10 and scale by a factor of 0.5).
      PK_Map map = PK_Map.GetInstance();
      map.ViewArea.X = 10;
      map.ViewArea.Y = 10;
      map.ViewScale = 0.5f;

      // Tests the method.
      Assert.AreEqual(10, map.GetMapYFromGameMapY(GamePoints[5].Y));

      // Clean-up
      map.Delete();
    }

    #endregion
  }
}
