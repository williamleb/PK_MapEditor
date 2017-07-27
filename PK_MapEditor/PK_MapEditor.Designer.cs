namespace PK_MapEditor
{
  partial class PK_MapEditor
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.GameMap = new PK_MapViewer.SFMLCanvas();
      this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // GameMap
      // 
      this.GameMap.Location = new System.Drawing.Point(233, 106);
      this.GameMap.Name = "GameMap";
      this.GameMap.Size = new System.Drawing.Size(255, 255);
      this.GameMap.TabIndex = 0;
      this.GameMap.Text = "sfmlCanvas1";
      this.GameMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameMap_MouseDown);
      this.GameMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameMap_MouseUp);
      // 
      // UpdateTimer
      // 
      this.UpdateTimer.Enabled = true;
      this.UpdateTimer.Interval = 33;
      this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_OnTick);
      // 
      // PK_MapEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(500, 373);
      this.Controls.Add(this.GameMap);
      this.Name = "PK_MapEditor";
      this.Text = "Project Kindom: Map Editor";
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PK_MapEditor_MouseUp);
      this.ResumeLayout(false);

    }

    #endregion

    private PK_MapViewer.SFMLCanvas GameMap;
    private System.Windows.Forms.Timer UpdateTimer;
  }
}

