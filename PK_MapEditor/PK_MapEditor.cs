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
    RenderWindow renderWindow = null;

    Random rnd = new Random();

    public PK_MapEditor()
    {
      InitializeComponent();

      renderWindow = new RenderWindow(GameMap.Handle);
    }

    private void DrawTimer_OnTick(object sender, EventArgs e)
    {
      renderWindow.Clear(new SFML.Graphics.Color((byte)rnd.Next(0, 255 + 1), (byte)rnd.Next(0, 255 + 1), (byte)rnd.Next(0, 255 + 1)));
      renderWindow.Display();
    }
  }
}
