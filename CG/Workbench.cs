using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG
{
	public partial class Workbench : Form
	{
		Graphics Graphics;
		Random Random = new Random();
		List<Shape> Shapes = new List<Shape>();

		public Workbench()
		{
			InitializeComponent();
			PictureBox.Image = new Bitmap(
				PictureBox.Width,
				PictureBox.Height);
			Graphics = Graphics.FromImage(
				PictureBox.Image);
		}

		#region Menu event handlers.

		private void AddRandomCut_Click(object sender, EventArgs e)
		{
			var cut = new Cut(
				a: GetRandomVertex(),
				b: GetRandomVertex());
			TogglePlane(
				shape: cut,
				xFactor: PictureBox.Image.Width / 2,
				yFactor: PictureBox.Image.Height / 2);
			cut.Draw(Graphics, Pens.Black);
			Shapes.Add(cut);
			PictureBox.Refresh();
		}

		private void EditSelected_Click(object sender, EventArgs e)
		{

		}

		private void RemoveSelected_Click(object sender, EventArgs e)
		{

		}

		private void ClearScene_Click(object sender, EventArgs e)
		{

		}

		private void ExportScene_Click(object sender, EventArgs e)
		{

		}

		private void ImportScene_Click(object sender, EventArgs e)
		{

		}

		private void ToggleGlobalPlane_MouseDown(object sender, MouseEventArgs e)
		{
			var plane = new Plane(
				x: PictureBox.Image.Width / 2,
				y: PictureBox.Image.Height / 2,
				z: PictureBox.Image.Height / 2);
			TogglePlane(
				shape: plane,
				xFactor: PictureBox.Image.Width / 2,
				yFactor: PictureBox.Image.Height / 2);
			plane.Draw(Graphics, Pens.LightGray);
			RedrawAllShapes();
			PictureBox.Refresh();
		}

		private void ToggleGlobalPlane_MouseUp(object sender, MouseEventArgs e)
		{
			var plane = new Plane(
				x: PictureBox.Image.Width / 2,
				y: PictureBox.Image.Height / 2,
				z: PictureBox.Image.Height / 2);
			TogglePlane(
				shape: plane,
				xFactor: PictureBox.Image.Width / 2,
				yFactor: PictureBox.Image.Height / 2);
			plane.Draw(Graphics, new Pen(PictureBox.BackColor));
			RedrawAllShapes();
			PictureBox.Refresh();
		}

		private void ToggleLocalPlane_MouseDown(object sender, MouseEventArgs e)
		{

		}

		private void ToggleLocalPlane_MouseUp(object sender, MouseEventArgs e)
		{

		}

		private void GroupSelected_Click(object sender, EventArgs e)
		{

		}

		private void UngroupSelected_Click(object sender, EventArgs e)
		{

		}

		private void Alpha_Scroll(object sender, EventArgs e)
		{

		}

		private void Tetta_Scroll(object sender, EventArgs e)
		{

		}

		private void Zetta_Scroll(object sender, EventArgs e)
		{

		}

		private void Radius_Scroll(object sender, EventArgs e)
		{

		}

		#endregion

		#region PictureBox event handler.

		private void PictureBox_MouseDown(object sender, MouseEventArgs e)
		{

		}

		private void PictureBox_MouseLeave(object sender, EventArgs e)
		{

		}

		private void PictureBox_MouseMove(object sender, MouseEventArgs e)
		{

		}

		private void PictureBox_MouseUp(object sender, MouseEventArgs e)
		{

		}

		#endregion

		#region Matrix transformations.

		void TogglePlane(Shape shape, double xFactor, double yFactor)
		{
			var matrix = new double[] {
				1,			0,			0,	0,
				0,			-1,			0,	0,
				0,			0,			1,	0,
				xFactor,	yFactor,	0,	1
			};
			
			shape.Transform(matrix);
		}

		#endregion

		Vertex GetRandomVertex()
		{
			return new Vertex(
				x: Random.Next(-PictureBox.Width / 2 + 10, PictureBox.Width / 2 - 10),
				y: Random.Next(-PictureBox.Height / 2 + 10, PictureBox.Height / 2 - 10),
				z: 0,
				uniformCoordinate: 1);
		}

		void RedrawAllShapes()
		{
			foreach (var i in Shapes) {
				i.Draw(Graphics, Pens.Black);
			}
		}
	}
}
