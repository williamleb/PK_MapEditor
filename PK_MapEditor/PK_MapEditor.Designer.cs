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
      this.GlobalX = new System.Windows.Forms.Label();
      this.GlobalY = new System.Windows.Forms.Label();
      this.FormX = new System.Windows.Forms.Label();
      this.FormY = new System.Windows.Forms.Label();
      this.GameMapX = new System.Windows.Forms.Label();
      this.GameMapY = new System.Windows.Forms.Label();
      this.MapX = new System.Windows.Forms.Label();
      this.MapY = new System.Windows.Forms.Label();
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
      // GlobalX
      // 
      this.GlobalX.AutoSize = true;
      this.GlobalX.Location = new System.Drawing.Point(12, 20);
      this.GlobalX.Name = "GlobalX";
      this.GlobalX.Size = new System.Drawing.Size(59, 13);
      this.GlobalX.TabIndex = 1;
      this.GlobalX.Text = "Global X: 0";
      // 
      // GlobalY
      // 
      this.GlobalY.AutoSize = true;
      this.GlobalY.Location = new System.Drawing.Point(12, 33);
      this.GlobalY.Name = "GlobalY";
      this.GlobalY.Size = new System.Drawing.Size(59, 13);
      this.GlobalY.TabIndex = 2;
      this.GlobalY.Text = "Global Y: 0";
      // 
      // FormX
      // 
      this.FormX.AutoSize = true;
      this.FormX.Location = new System.Drawing.Point(12, 63);
      this.FormX.Name = "FormX";
      this.FormX.Size = new System.Drawing.Size(52, 13);
      this.FormX.TabIndex = 3;
      this.FormX.Text = "Form X: 0";
      // 
      // FormY
      // 
      this.FormY.AutoSize = true;
      this.FormY.Location = new System.Drawing.Point(12, 76);
      this.FormY.Name = "FormY";
      this.FormY.Size = new System.Drawing.Size(52, 13);
      this.FormY.TabIndex = 4;
      this.FormY.Text = "Form Y: 0";
      // 
      // GameMapX
      // 
      this.GameMapX.AutoSize = true;
      this.GameMapX.Location = new System.Drawing.Point(12, 102);
      this.GameMapX.Name = "GameMapX";
      this.GameMapX.Size = new System.Drawing.Size(81, 13);
      this.GameMapX.TabIndex = 5;
      this.GameMapX.Text = "Game Map X: 0";
      // 
      // GameMapY
      // 
      this.GameMapY.AutoSize = true;
      this.GameMapY.Location = new System.Drawing.Point(12, 115);
      this.GameMapY.Name = "GameMapY";
      this.GameMapY.Size = new System.Drawing.Size(81, 13);
      this.GameMapY.TabIndex = 6;
      this.GameMapY.Text = "Game Map Y: 0";
      // 
      // MapX
      // 
      this.MapX.AutoSize = true;
      this.MapX.Location = new System.Drawing.Point(12, 142);
      this.MapX.Name = "MapX";
      this.MapX.Size = new System.Drawing.Size(50, 13);
      this.MapX.TabIndex = 7;
      this.MapX.Text = "Map X: 0";
      // 
      // MapY
      // 
      this.MapY.AutoSize = true;
      this.MapY.Location = new System.Drawing.Point(12, 155);
      this.MapY.Name = "MapY";
      this.MapY.Size = new System.Drawing.Size(50, 13);
      this.MapY.TabIndex = 8;
      this.MapY.Text = "Map X: 0";
      // 
      // PK_MapEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(500, 373);
      this.Controls.Add(this.MapY);
      this.Controls.Add(this.MapX);
      this.Controls.Add(this.GameMapY);
      this.Controls.Add(this.GameMapX);
      this.Controls.Add(this.FormY);
      this.Controls.Add(this.FormX);
      this.Controls.Add(this.GlobalY);
      this.Controls.Add(this.GlobalX);
      this.Controls.Add(this.GameMap);
      this.Name = "PK_MapEditor";
      this.Text = "Project Kindom: Map Editor";
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PK_MapEditor_MouseUp);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private PK_MapViewer.SFMLCanvas GameMap;
    private System.Windows.Forms.Timer UpdateTimer;
    private System.Windows.Forms.Label GlobalX;
    private System.Windows.Forms.Label GlobalY;
    private System.Windows.Forms.Label FormX;
    private System.Windows.Forms.Label FormY;
    private System.Windows.Forms.Label GameMapX;
    private System.Windows.Forms.Label GameMapY;
    private System.Windows.Forms.Label MapX;
    private System.Windows.Forms.Label MapY;
  }
}

