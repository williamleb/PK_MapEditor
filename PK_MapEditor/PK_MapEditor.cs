using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Graphics;

namespace PK_MapEditor
{
  public partial class PK_MapEditor : Form
  {
    #region Properties

    #region Static properties

    public static int GAMEMAP_WIDTH;

    public static int GAMEMAP_HEIGHT;

    // Lower indexes are more distant than higher indexes
    private static float[] allowedViewScales = new float[] { 2.0f, 1.0f, 0.75f, 0.5f, 0.25f };

    #endregion

    RenderWindow window;

    int currentViewScaleIndex;

    #endregion

    PK_Border border = new PK_Border(50, 50, 100, 100);

    PK_Area area = new PK_Area(100, 100, 100, 100, SFML.Graphics.Color.White);

    PK_Map map = PK_Map.GetInstance();

    Random rnd = new Random();

    public PK_MapEditor()
    {
      InitializeComponent();
      this.MouseWheel += new MouseEventHandler(GameMap_OnMouseWheel);

      window = new RenderWindow(GameMap.Handle);

      GAMEMAP_WIDTH = GameMap.Width;

      GAMEMAP_HEIGHT = GameMap.Height;

      currentViewScaleIndex = Array.IndexOf(allowedViewScales, 1.0f);

      map.BackgroundImage = new Texture("Assets/img/background_test.png");
      map.ViewScale = allowedViewScales[currentViewScaleIndex];
    }

    private void DrawTimer_OnTick(object sender, EventArgs e)
    {
      window.Clear(new SFML.Graphics.Color((byte)rnd.Next(0, 255 + 1), (byte)rnd.Next(0, 255 + 1), (byte)rnd.Next(0, 255 + 1)));

      map.Draw(window);

      border.Draw(window);
      area.Draw(window);

      window.Display();
    }

    private void boop(object sender, EventArgs e)
    {
      border.X = MousePosition.X - (sender as Control).Left - this.Left;
      border.Y = MousePosition.Y - (sender as Control).Top - this.Top;
    }

    private void GameMap_OnMouseWheel(object sender, EventArgs e)
    {
      int delta = (e as MouseEventArgs).Delta;
      if (delta <= -120)
      {
        currentViewScaleIndex = Math.Max(currentViewScaleIndex - 1, 0);
      }
      else if (delta >= 120)
      {
        currentViewScaleIndex = Math.Min(currentViewScaleIndex + 1, allowedViewScales.Length - 1);
      }

      map.ViewScale = allowedViewScales[currentViewScaleIndex];
    }

      // TODO : GameMapOnResize
    }
}
