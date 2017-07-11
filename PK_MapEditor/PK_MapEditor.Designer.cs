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
      this.DrawTimer = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // GameMap
      // 
      this.GameMap.Location = new System.Drawing.Point(230, 176);
      this.GameMap.Name = "GameMap";
      this.GameMap.Size = new System.Drawing.Size(258, 185);
      this.GameMap.TabIndex = 0;
      this.GameMap.Text = "sfmlCanvas1";
      // 
      // DrawTimer
      // 
      this.DrawTimer.Enabled = true;
      this.DrawTimer.Interval = 33;
      this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_OnTick);
      // 
      // PK_MapEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(500, 373);
      this.Controls.Add(this.GameMap);
      this.Name = "PK_MapEditor";
      this.Text = "Project Kindom: Map Editor";
      this.ResumeLayout(false);

    }

    #endregion

    private PK_MapViewer.SFMLCanvas GameMap;
    private System.Windows.Forms.Timer DrawTimer;
  }
}

