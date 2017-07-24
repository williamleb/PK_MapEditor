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
    RenderWindow window = null;

    PK_Border border = new PK_Border(50, 50, 100, 100);

    PK_Area area = new PK_Area(100, 100, 100, 100, SFML.Graphics.Color.White);

    Random rnd = new Random();

    public PK_MapEditor()
    {
      InitializeComponent();

      window = new RenderWindow(GameMap.Handle);
    }

    private void DrawTimer_OnTick(object sender, EventArgs e)
    {
      window.Clear(new SFML.Graphics.Color((byte)rnd.Next(0, 255 + 1), (byte)rnd.Next(0, 255 + 1), (byte)rnd.Next(0, 255 + 1)));

      border.Draw(window);
      area.Draw(window);

      window.Display();
    }

    private void boop(object sender, EventArgs e)
    {
      border.X = MousePosition.X - (sender as Control).Left - this.Left;
      border.Y = MousePosition.Y - (sender as Control).Top - this.Top;
    }
  }
}
