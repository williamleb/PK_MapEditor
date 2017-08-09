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

    /// <summary>
    /// Top padding due to the form's shape.
    /// </summary>
    private const int FORM_TOP_PADDING = 31;

    /// <summary>
    /// Left padding due to the form's shape.
    /// </summary>
    private const int FORM_LEFT_PADDING = 8;

    /// <summary>
    /// Represents the width of the game map.
    /// </summary>
    public static int GAMEMAP_WIDTH;

    /// <summary>
    /// Represents te height of the game map.
    /// </summary>
    public static int GAMEMAP_HEIGHT;

    /// <summary>
    /// Represents every view scales that the map can have.
    /// Lower indexes are more distant than higher indexes.
    /// </summary>
    private static float[] allowedViewScales = new float[] { 10.0f, 2.0f, 1.0f, 0.75f, 0.5f, 0.25f };

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

    // TODO : GameMapOnResize

    public int GetFormXFromGlobalX(int globalX)
    {
      return globalX - this.Left - FORM_LEFT_PADDING;
    }

    public int GetFormYromGlobalY(int globalY)
    {
      return globalY - this.Top - FORM_TOP_PADDING;
    }

    #region Event Handlers

    /// <summary>
    /// Method called on the tick of a timer (it should be called at least 30 times / seconds)
    /// It updates the logic and the view of the map.
    /// </summary>
    private void UpdateTimer_OnTick(object sender, EventArgs e)
    {
      // Updates
      int mouseX = GetFormXFromGlobalX(MousePosition.X);
      int mouseY = GetFormYromGlobalY(MousePosition.Y);
      map.Update(mouseX, mouseY);

      // Draws
      window.Clear(new SFML.Graphics.Color((byte)rnd.Next(0, 255 + 1), (byte)rnd.Next(0, 255 + 1), (byte)rnd.Next(0, 255 + 1)));

      map.Draw(window);

      window.Display();

      // TOREMOVE
      GlobalX.Text = "Global X: " + MousePosition.X.ToString();
      GlobalY.Text = "Global Y: " + MousePosition.Y.ToString();
      FormX.Text = "Form X: " + mouseX.ToString();
      FormY.Text = "Form Y: " + mouseY.ToString();
      GameMapX.Text = "Game Map X: " + map.GetGameMapXFromFormX(mouseX).ToString();
      GameMapY.Text = "Game Map Y: " + map.GetGameMapYFromFormY(mouseY).ToString();
      MapX.Text = "Map X: " + map.GetMapXFromFormX(mouseX).ToString();
      MapY.Text = "Map Y: " + map.GetMapYFromFormY(mouseY).ToString();
    }

    /// <summary>
    /// Method called when the mouse wheel is used on the game map.
    /// It zooms or unzoom the view of the map depending of which direction the wheel has gone.
    /// </summary>
    private void GameMap_OnMouseWheel(object sender, MouseEventArgs e)
    {
      // We can onl change the view scale if there is no items currently being picked.
      if (PK_Movable.PickedItem == null)
      {
        // Zooms or unzooms depending of which direction the wheel has gone.
        int delta = e.Delta;
        if (delta <= -120)
        {
          currentViewScaleIndex = Math.Max(currentViewScaleIndex - 1, 0);
        }
        else if (delta >= 120)
        {
          currentViewScaleIndex = Math.Min(currentViewScaleIndex + 1, allowedViewScales.Length - 1);
        }

        // Sets the new scale on the map.
        map.ViewScale = allowedViewScales[currentViewScaleIndex];
      }
    }

    /// <summary>
    /// Method called when the mouse buttons are pressed on the game map.
    /// It redirects the event to the logic of the map itself.
    /// </summary>
    private void GameMap_MouseDown(object sender, MouseEventArgs e)
    {
      map.OnMouseDown(sender, e);
    }

    /// <summary>
    /// Method called when the mouse buttons are released after being pressed on the form itself.
    /// Cancels the pick of an item if the cursor is not on the game map.
    /// </summary>
    public void PK_MapEditor_MouseUp(object sender, MouseEventArgs e)
    {
      // If an item is currently picked
      if (PK_Movable.PickedItem != null)
      {
        // Get X and Y from global mouse position because the event may
        // come from a child.
        int mouseX = GetFormXFromGlobalX(MousePosition.X);
        int mouseY = GetFormYromGlobalY(MousePosition.Y);

        IntRect gameMap = new IntRect(GameMap.Left, GameMap.Top, GameMap.Width, GameMap.Height);

        // If the mouse wasn't released on the game map, we cancel the pick.
        if (!gameMap.Contains(mouseX, mouseY))
        {
          // But only if the picked item is not the view area.
          if (PK_Movable.PickedItem is PK_ViewArea)
          {
            PK_Movable.PickedItem.Unpick();
          }
          else
          {
            PK_Movable.PickedItem.CancelPick();
          }

          // And, if the item was spawned from the form, and not picked from the game map
          if (itemSpawnedFromForm)
          {
            // We delete the item
            map.RemoveDrawable(PK_Movable.PickedItem);
          }

          // We tell that the next item that we pick will not necesserly be spawned from the form.
          itemSpawnedFromForm = false;
        }
      }
    }

    /// <summary>
    /// Method called when the mouse buttons are released after being pressed on the map.
    /// It basically redirects the event to the form, which will treat it
    /// accordingly if the mouse was released outside of the map area.
    /// Else, this event handler will unpicked a picked item on the map.
    /// </summary>
    private void GameMap_MouseUp(object sender, MouseEventArgs e)
    {
      // Redirect the event to the form
      PK_MapEditor_MouseUp(sender, e);

      if (PK_Movable.PickedItem != null)
      {
        PK_Movable.PickedItem.Unpick();
        itemSpawnedFromForm = false;
      }
    }

    #endregion
  }
}
