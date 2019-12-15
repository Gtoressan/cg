namespace CG
{
	partial class Workbench
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
			if (disposing && (components != null)) {
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
			this.AddRandomCut = new System.Windows.Forms.Button();
			this.RemoveSelected = new System.Windows.Forms.Button();
			this.ToggleGlobalPlane = new System.Windows.Forms.Button();
			this.ClearScene = new System.Windows.Forms.Button();
			this.ExportScene = new System.Windows.Forms.Button();
			this.ImportScene = new System.Windows.Forms.Button();
			this.ToggleLocalPlane = new System.Windows.Forms.Button();
			this.GroupSelected = new System.Windows.Forms.Button();
			this.UngroupSelected = new System.Windows.Forms.Button();
			this.LabelOfAlpha = new System.Windows.Forms.Label();
			this.Alpha = new System.Windows.Forms.TrackBar();
			this.Radius = new System.Windows.Forms.TrackBar();
			this.LabelOfRadius = new System.Windows.Forms.Label();
			this.Tetta = new System.Windows.Forms.TrackBar();
			this.LabelOfTetta = new System.Windows.Forms.Label();
			this.PictureBox = new System.Windows.Forms.PictureBox();
			this.StatusBar = new System.Windows.Forms.RichTextBox();
			this.EditSelected = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Alpha)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Radius)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Tetta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// AddRandomCut
			// 
			this.AddRandomCut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AddRandomCut.Location = new System.Drawing.Point(632, 12);
			this.AddRandomCut.Name = "AddRandomCut";
			this.AddRandomCut.Size = new System.Drawing.Size(108, 26);
			this.AddRandomCut.TabIndex = 0;
			this.AddRandomCut.Text = "Add random cut";
			this.AddRandomCut.UseVisualStyleBackColor = true;
			this.AddRandomCut.Click += new System.EventHandler(this.AddRandomCut_Click);
			// 
			// RemoveSelected
			// 
			this.RemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveSelected.Location = new System.Drawing.Point(632, 44);
			this.RemoveSelected.Name = "RemoveSelected";
			this.RemoveSelected.Size = new System.Drawing.Size(140, 26);
			this.RemoveSelected.TabIndex = 1;
			this.RemoveSelected.Text = "Remove selected";
			this.RemoveSelected.UseVisualStyleBackColor = true;
			this.RemoveSelected.Click += new System.EventHandler(this.RemoveSelected_Click);
			// 
			// ToggleGlobalPlane
			// 
			this.ToggleGlobalPlane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ToggleGlobalPlane.Location = new System.Drawing.Point(632, 140);
			this.ToggleGlobalPlane.Name = "ToggleGlobalPlane";
			this.ToggleGlobalPlane.Size = new System.Drawing.Size(140, 26);
			this.ToggleGlobalPlane.TabIndex = 2;
			this.ToggleGlobalPlane.Text = "Toggle global plane";
			this.ToggleGlobalPlane.UseVisualStyleBackColor = true;
			this.ToggleGlobalPlane.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToggleGlobalPlane_MouseDown);
			this.ToggleGlobalPlane.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ToggleGlobalPlane_MouseUp);
			// 
			// ClearScene
			// 
			this.ClearScene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ClearScene.Location = new System.Drawing.Point(632, 76);
			this.ClearScene.Name = "ClearScene";
			this.ClearScene.Size = new System.Drawing.Size(140, 26);
			this.ClearScene.TabIndex = 3;
			this.ClearScene.Text = "Clear scene";
			this.ClearScene.UseVisualStyleBackColor = true;
			this.ClearScene.Click += new System.EventHandler(this.ClearScene_Click);
			// 
			// ExportScene
			// 
			this.ExportScene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ExportScene.Location = new System.Drawing.Point(632, 108);
			this.ExportScene.Name = "ExportScene";
			this.ExportScene.Size = new System.Drawing.Size(67, 26);
			this.ExportScene.TabIndex = 4;
			this.ExportScene.Text = "Export";
			this.ExportScene.UseVisualStyleBackColor = true;
			this.ExportScene.Click += new System.EventHandler(this.ExportScene_Click);
			// 
			// ImportScene
			// 
			this.ImportScene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ImportScene.Location = new System.Drawing.Point(705, 108);
			this.ImportScene.Name = "ImportScene";
			this.ImportScene.Size = new System.Drawing.Size(67, 26);
			this.ImportScene.TabIndex = 5;
			this.ImportScene.Text = "Import";
			this.ImportScene.UseVisualStyleBackColor = true;
			this.ImportScene.Click += new System.EventHandler(this.ImportScene_Click);
			// 
			// ToggleLocalPlane
			// 
			this.ToggleLocalPlane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ToggleLocalPlane.Location = new System.Drawing.Point(632, 172);
			this.ToggleLocalPlane.Name = "ToggleLocalPlane";
			this.ToggleLocalPlane.Size = new System.Drawing.Size(140, 26);
			this.ToggleLocalPlane.TabIndex = 6;
			this.ToggleLocalPlane.Text = "Toggle local plane";
			this.ToggleLocalPlane.UseVisualStyleBackColor = true;
			this.ToggleLocalPlane.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToggleLocalPlane_MouseDown);
			this.ToggleLocalPlane.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ToggleLocalPlane_MouseUp);
			// 
			// GroupSelected
			// 
			this.GroupSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.GroupSelected.Location = new System.Drawing.Point(632, 204);
			this.GroupSelected.Name = "GroupSelected";
			this.GroupSelected.Size = new System.Drawing.Size(67, 26);
			this.GroupSelected.TabIndex = 7;
			this.GroupSelected.Text = "Group";
			this.GroupSelected.UseVisualStyleBackColor = true;
			this.GroupSelected.Click += new System.EventHandler(this.GroupSelected_Click);
			// 
			// UngroupSelected
			// 
			this.UngroupSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.UngroupSelected.Location = new System.Drawing.Point(705, 204);
			this.UngroupSelected.Name = "UngroupSelected";
			this.UngroupSelected.Size = new System.Drawing.Size(67, 26);
			this.UngroupSelected.TabIndex = 8;
			this.UngroupSelected.Text = "Ungroup";
			this.UngroupSelected.UseVisualStyleBackColor = true;
			this.UngroupSelected.Click += new System.EventHandler(this.UngroupSelected_Click);
			// 
			// LabelOfAlpha
			// 
			this.LabelOfAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LabelOfAlpha.AutoSize = true;
			this.LabelOfAlpha.Location = new System.Drawing.Point(629, 242);
			this.LabelOfAlpha.Name = "LabelOfAlpha";
			this.LabelOfAlpha.Size = new System.Drawing.Size(88, 13);
			this.LabelOfAlpha.TabIndex = 9;
			this.LabelOfAlpha.Text = "Rotate on X-axis:";
			// 
			// Alpha
			// 
			this.Alpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Alpha.Location = new System.Drawing.Point(632, 258);
			this.Alpha.Maximum = 179;
			this.Alpha.Name = "Alpha";
			this.Alpha.Size = new System.Drawing.Size(140, 45);
			this.Alpha.TabIndex = 10;
			this.Alpha.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.Alpha.Scroll += new System.EventHandler(this.Alpha_Scroll);
			// 
			// Radius
			// 
			this.Radius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Radius.Location = new System.Drawing.Point(632, 386);
			this.Radius.Maximum = 725;
			this.Radius.Minimum = 700;
			this.Radius.Name = "Radius";
			this.Radius.Size = new System.Drawing.Size(140, 45);
			this.Radius.TabIndex = 12;
			this.Radius.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.Radius.Value = 700;
			this.Radius.Scroll += new System.EventHandler(this.Radius_Scroll);
			// 
			// LabelOfRadius
			// 
			this.LabelOfRadius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LabelOfRadius.AutoSize = true;
			this.LabelOfRadius.Location = new System.Drawing.Point(629, 370);
			this.LabelOfRadius.Name = "LabelOfRadius";
			this.LabelOfRadius.Size = new System.Drawing.Size(43, 13);
			this.LabelOfRadius.TabIndex = 11;
			this.LabelOfRadius.Text = "Radius:";
			// 
			// Tetta
			// 
			this.Tetta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Tetta.Location = new System.Drawing.Point(632, 322);
			this.Tetta.Maximum = 179;
			this.Tetta.Name = "Tetta";
			this.Tetta.Size = new System.Drawing.Size(140, 45);
			this.Tetta.TabIndex = 14;
			this.Tetta.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.Tetta.Scroll += new System.EventHandler(this.Tetta_Scroll);
			// 
			// LabelOfTetta
			// 
			this.LabelOfTetta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LabelOfTetta.AutoSize = true;
			this.LabelOfTetta.Location = new System.Drawing.Point(629, 306);
			this.LabelOfTetta.Name = "LabelOfTetta";
			this.LabelOfTetta.Size = new System.Drawing.Size(88, 13);
			this.LabelOfTetta.TabIndex = 13;
			this.LabelOfTetta.Text = "Rotate on Y-axis:";
			// 
			// PictureBox
			// 
			this.PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PictureBox.BackColor = System.Drawing.Color.White;
			this.PictureBox.Location = new System.Drawing.Point(12, 12);
			this.PictureBox.Name = "PictureBox";
			this.PictureBox.Size = new System.Drawing.Size(614, 511);
			this.PictureBox.TabIndex = 15;
			this.PictureBox.TabStop = false;
			this.PictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
			this.PictureBox.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
			this.PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
			this.PictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseUp);
			// 
			// StatusBar
			// 
			this.StatusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.StatusBar.Location = new System.Drawing.Point(12, 529);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.ReadOnly = true;
			this.StatusBar.Size = new System.Drawing.Size(614, 20);
			this.StatusBar.TabIndex = 16;
			this.StatusBar.Text = "";
			// 
			// EditSelected
			// 
			this.EditSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.EditSelected.Location = new System.Drawing.Point(746, 12);
			this.EditSelected.Name = "EditSelected";
			this.EditSelected.Size = new System.Drawing.Size(26, 26);
			this.EditSelected.TabIndex = 19;
			this.EditSelected.Text = "⋯";
			this.EditSelected.UseVisualStyleBackColor = true;
			this.EditSelected.Click += new System.EventHandler(this.EditSelected_Click);
			// 
			// Workbench
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.EditSelected);
			this.Controls.Add(this.StatusBar);
			this.Controls.Add(this.Tetta);
			this.Controls.Add(this.LabelOfTetta);
			this.Controls.Add(this.Radius);
			this.Controls.Add(this.LabelOfRadius);
			this.Controls.Add(this.Alpha);
			this.Controls.Add(this.LabelOfAlpha);
			this.Controls.Add(this.UngroupSelected);
			this.Controls.Add(this.GroupSelected);
			this.Controls.Add(this.ToggleLocalPlane);
			this.Controls.Add(this.ImportScene);
			this.Controls.Add(this.ExportScene);
			this.Controls.Add(this.ClearScene);
			this.Controls.Add(this.ToggleGlobalPlane);
			this.Controls.Add(this.RemoveSelected);
			this.Controls.Add(this.AddRandomCut);
			this.Controls.Add(this.PictureBox);
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(600, 600);
			this.Name = "Workbench";
			this.Text = "Workbench";
			((System.ComponentModel.ISupportInitialize)(this.Alpha)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Radius)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Tetta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button AddRandomCut;
		private System.Windows.Forms.Button RemoveSelected;
		private System.Windows.Forms.Button ToggleGlobalPlane;
		private System.Windows.Forms.Button ClearScene;
		private System.Windows.Forms.Button ExportScene;
		private System.Windows.Forms.Button ImportScene;
		private System.Windows.Forms.Button ToggleLocalPlane;
		private System.Windows.Forms.Button GroupSelected;
		private System.Windows.Forms.Button UngroupSelected;
		private System.Windows.Forms.Label LabelOfAlpha;
		private System.Windows.Forms.TrackBar Alpha;
		private System.Windows.Forms.TrackBar Radius;
		private System.Windows.Forms.Label LabelOfRadius;
		private System.Windows.Forms.TrackBar Tetta;
		private System.Windows.Forms.Label LabelOfTetta;
		private System.Windows.Forms.PictureBox PictureBox;
		private System.Windows.Forms.RichTextBox StatusBar;
		private System.Windows.Forms.Button EditSelected;
	}
}