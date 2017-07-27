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

    static PK_MapEditor instance = null;

    #endregion

    RenderWindow window;

    int currentViewScaleIndex;

    bool itemSpawnedFromForm;

    #endregion

    #region Accessor

    public Control GameMapControl
    {
      get
      {
        return GameMap;
      }
    }

    #endregion

    PK_Map map = PK_Map.GetInstance();

    Random rnd = new Random();

    private PK_MapEditor()
    {
      InitializeComponent();
      this.MouseWheel += new MouseEventHandler(GameMap_OnMouseWheel);

      window = new RenderWindow(GameMap.Handle);

      GAMEMAP_WIDTH = GameMap.Width;

      GAMEMAP_HEIGHT = GameMap.Height;

      currentViewScaleIndex = Array.IndexOf(allowedViewScales, 1.0f);

      itemSpawnedFromForm = false;

      map.BackgroundImage = new Texture("Assets/img/background_test.png");
      map.ViewScale = allowedViewScales[currentViewScaleIndex];
    }

    public static PK_MapEditor GetInstance()
    {
      if (instance == null)
      {
        instance = new PK_MapEditor();
      }
      return instance;
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

    private void UpdateTimer_OnTick(object sender, EventArgs e)
    {
      // Updates
      map.Update(GetFormXFromGlobalX(MousePosition.X), GetFormYromGlobalY(MousePosition.Y));

      // Draws
      window.Clear(new SFML.Graphics.Color((byte)rnd.Next(0, 255 + 1), (byte)rnd.Next(0, 255 + 1), (byte)rnd.Next(0, 255 + 1)));

      map.Draw(window);

      window.Display();
    }

    private void PK_MapEditor_MouseUp(object sender, MouseEventArgs e)
    {
      if (PK_Movable.PickedItem != null)
      {
        IntRect gameMap = new IntRect(GameMap.Left, GameMap.Top, GameMap.Width, GameMap.Height);

        // If the mouse wasn't released on the game map, we cancel the pick
        if(!gameMap.Contains(e.X, e.Y))
        {
          PK_Movable.PickedItem.CancelPick();

          // And, if the item was spawned from the form, and not picked from the game map
          if (itemSpawnedFromForm)
          {
            // We delete the item
            map.RemoveDrawable(PK_Movable.PickedItem);
          }
        }

        // We tell that the next item that we pick will not necesserly be spawned from the form.
        itemSpawnedFromForm = false;
      }
    }

    private void GameMap_MouseDown(object sender, MouseEventArgs e)
    {
      map.OnMouseDown(sender, e);
    }

    // TODO : GameMapOnResize

    public int GetFormXFromGlobalX(int globalX)
    {
      return globalX - this.Left;
    }

    public int GetFormYromGlobalY(int globalY)
    {
      return globalY - this.Top;
    }

    private void GameMap_MouseUp(object sender, MouseEventArgs e)
    {
      if (PK_Movable.PickedItem != null)
      {
        PK_Movable.PickedItem.Unpick();
      }
    }
  }
}
