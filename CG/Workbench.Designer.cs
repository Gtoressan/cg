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
			this.UseLocalPlane = new System.Windows.Forms.CheckBox();
			this.Zetta = new System.Windows.Forms.TrackBar();
			this.LabelOfZetta = new System.Windows.Forms.Label();
			this.AddMedian = new System.Windows.Forms.Button();
			this.Height = new System.Windows.Forms.Button();
			this.Bisector = new System.Windows.Forms.Button();
			this.SelectAll = new System.Windows.Forms.Button();
			this.Morphing = new System.Windows.Forms.TrackBar();
			this.Shadow = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Alpha)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Radius)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Tetta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Zetta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Morphing)).BeginInit();
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
			this.ExportScene.Text = "Export...";
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
			this.ImportScene.Text = "Import...";
			this.ImportScene.UseVisualStyleBackColor = true;
			this.ImportScene.Click += new System.EventHandler(this.ImportScene_Click);
			// 
			// ToggleLocalPlane
			// 
			this.ToggleLocalPlane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ToggleLocalPlane.Location = new System.Drawing.Point(632, 172);
			this.ToggleLocalPlane.Name = "ToggleLocalPlane";
			this.ToggleLocalPlane.Size = new System.Drawing.Size(119, 26);
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
			this.Alpha.LargeChange = 1;
			this.Alpha.Location = new System.Drawing.Point(632, 258);
			this.Alpha.Maximum = 180;
			this.Alpha.Name = "Alpha";
			this.Alpha.Size = new System.Drawing.Size(140, 45);
			this.Alpha.TabIndex = 10;
			this.Alpha.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.Alpha.Scroll += new System.EventHandler(this.Alpha_Scroll);
			// 
			// Radius
			// 
			this.Radius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Radius.Location = new System.Drawing.Point(632, 450);
			this.Radius.Maximum = 2000;
			this.Radius.Minimum = 50;
			this.Radius.Name = "Radius";
			this.Radius.Size = new System.Drawing.Size(140, 45);
			this.Radius.TabIndex = 12;
			this.Radius.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.Radius.Value = 2000;
			this.Radius.Scroll += new System.EventHandler(this.Radius_Scroll);
			// 
			// LabelOfRadius
			// 
			this.LabelOfRadius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LabelOfRadius.AutoSize = true;
			this.LabelOfRadius.Location = new System.Drawing.Point(629, 434);
			this.LabelOfRadius.Name = "LabelOfRadius";
			this.LabelOfRadius.Size = new System.Drawing.Size(43, 13);
			this.LabelOfRadius.TabIndex = 11;
			this.LabelOfRadius.Text = "Radius:";
			// 
			// Tetta
			// 
			this.Tetta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Tetta.LargeChange = 1;
			this.Tetta.Location = new System.Drawing.Point(632, 322);
			this.Tetta.Maximum = 180;
			this.Tetta.Name = "Tetta";
			this.Tetta.Size = new System.Drawing.Size(140, 45);
			this.Tetta.TabIndex = 14;
			this.Tetta.Tag = "0";
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
			this.PictureBox.Size = new System.Drawing.Size(614, 483);
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
			this.StatusBar.Location = new System.Drawing.Point(12, 504);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.ReadOnly = true;
			this.StatusBar.Size = new System.Drawing.Size(468, 45);
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
			// UseLocalPlane
			// 
			this.UseLocalPlane.AutoSize = true;
			this.UseLocalPlane.Location = new System.Drawing.Point(757, 179);
			this.UseLocalPlane.Name = "UseLocalPlane";
			this.UseLocalPlane.Size = new System.Drawing.Size(15, 14);
			this.UseLocalPlane.TabIndex = 20;
			this.UseLocalPlane.UseVisualStyleBackColor = true;
			// 
			// Zetta
			// 
			this.Zetta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Zetta.LargeChange = 1;
			this.Zetta.Location = new System.Drawing.Point(632, 386);
			this.Zetta.Maximum = 180;
			this.Zetta.Name = "Zetta";
			this.Zetta.Size = new System.Drawing.Size(140, 45);
			this.Zetta.TabIndex = 22;
			this.Zetta.Tag = "0";
			this.Zetta.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.Zetta.Scroll += new System.EventHandler(this.Zetta_Scroll);
			// 
			// LabelOfZetta
			// 
			this.LabelOfZetta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LabelOfZetta.AutoSize = true;
			this.LabelOfZetta.Location = new System.Drawing.Point(629, 370);
			this.LabelOfZetta.Name = "LabelOfZetta";
			this.LabelOfZetta.Size = new System.Drawing.Size(88, 13);
			this.LabelOfZetta.TabIndex = 21;
			this.LabelOfZetta.Text = "Rotate on Z-axis:";
			// 
			// AddMedian
			// 
			this.AddMedian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AddMedian.Location = new System.Drawing.Point(632, 501);
			this.AddMedian.Name = "AddMedian";
			this.AddMedian.Size = new System.Drawing.Size(43, 22);
			this.AddMedian.TabIndex = 23;
			this.AddMedian.Text = "Median";
			this.AddMedian.UseVisualStyleBackColor = true;
			this.AddMedian.Click += new System.EventHandler(this.AddMedian_Click);
			// 
			// Height
			// 
			this.Height.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Height.Location = new System.Drawing.Point(681, 501);
			this.Height.Name = "Height";
			this.Height.Size = new System.Drawing.Size(42, 22);
			this.Height.TabIndex = 24;
			this.Height.Text = "Height";
			this.Height.UseVisualStyleBackColor = true;
			this.Height.Click += new System.EventHandler(this.Height_Click);
			// 
			// Bisector
			// 
			this.Bisector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Bisector.Location = new System.Drawing.Point(729, 501);
			this.Bisector.Name = "Bisector";
			this.Bisector.Size = new System.Drawing.Size(43, 22);
			this.Bisector.TabIndex = 25;
			this.Bisector.Text = "Bisector";
			this.Bisector.UseVisualStyleBackColor = true;
			this.Bisector.Click += new System.EventHandler(this.Bisector_Click);
			// 
			// SelectAll
			// 
			this.SelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SelectAll.Location = new System.Drawing.Point(632, 529);
			this.SelectAll.Name = "SelectAll";
			this.SelectAll.Size = new System.Drawing.Size(91, 22);
			this.SelectAll.TabIndex = 26;
			this.SelectAll.Text = "Select all";
			this.SelectAll.UseVisualStyleBackColor = true;
			this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
			// 
			// Morphing
			// 
			this.Morphing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Morphing.Location = new System.Drawing.Point(486, 504);
			this.Morphing.Name = "Morphing";
			this.Morphing.Size = new System.Drawing.Size(140, 45);
			this.Morphing.TabIndex = 27;
			this.Morphing.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.Morphing.Scroll += new System.EventHandler(this.Morphing_Scroll);
			// 
			// Shadow
			// 
			this.Shadow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Shadow.Location = new System.Drawing.Point(729, 529);
			this.Shadow.Name = "Shadow";
			this.Shadow.Size = new System.Drawing.Size(43, 22);
			this.Shadow.TabIndex = 28;
			this.Shadow.Text = "Shadow";
			this.Shadow.UseVisualStyleBackColor = true;
			this.Shadow.Click += new System.EventHandler(this.Shadow_Click);
			// 
			// Workbench
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.Shadow);
			this.Controls.Add(this.Morphing);
			this.Controls.Add(this.SelectAll);
			this.Controls.Add(this.Bisector);
			this.Controls.Add(this.Height);
			this.Controls.Add(this.AddMedian);
			this.Controls.Add(this.Zetta);
			this.Controls.Add(this.LabelOfZetta);
			this.Controls.Add(this.UseLocalPlane);
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
			((System.ComponentModel.ISupportInitialize)(this.Zetta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Morphing)).EndInit();
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
		private System.Windows.Forms.CheckBox UseLocalPlane;
		private System.Windows.Forms.TrackBar Zetta;
		private System.Windows.Forms.Label LabelOfZetta;
		private System.Windows.Forms.Button AddMedian;
		private System.Windows.Forms.Button Height;
		private System.Windows.Forms.Button Bisector;
		private System.Windows.Forms.Button SelectAll;
		private System.Windows.Forms.TrackBar Morphing;
		private System.Windows.Forms.Button Shadow;
	}
}