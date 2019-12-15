using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;

namespace CG
{
	public partial class Workbench : Form
	{
		Graphics Graphics;
		Random Random = new Random();
		List<Shape> Shapes = new List<Shape>();
		List<Shape> Selected = new List<Shape>();
		Vertex OldVertex = new Vertex(0, 0, 0, 1);
		Boolean IsMousePressed = false;

		public Workbench()
		{
			InitializeComponent();
			ReloadScene();
			FillStatusBar();
		}

		#region Menu event handlers.

		private void AddRandomCut_Click(object sender, EventArgs e)
		{
			var cut = new Cut(
				a: GetRandomVertex(),
				b: GetRandomVertex());
			Shapes.Add(cut);
			DrawShape(cut, Pens.Black);
			PictureBox.Refresh();
			FillStatusBar();
		}

		private void EditSelected_Click(object sender, EventArgs e)
		{

		}

		private void RemoveSelected_Click(object sender, EventArgs e)
		{
			foreach (var i in Selected) {
				Shapes.Remove(i);
			}

			Selected.Clear();
			ReloadScene();
			RedrawSelected();
			RedrawShapesExceptSelected();
			PictureBox.Refresh();
			FillStatusBar();
		}

		private void ClearScene_Click(object sender, EventArgs e)
		{
			Shapes.Clear();
			Selected.Clear();
			ReloadScene();
			FillStatusBar();
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
				z: 0);
			DrawShape(plane, Pens.LightGray);
			RedrawSelected();
			RedrawShapesExceptSelected();
			PictureBox.Refresh();
		}

		private void ToggleGlobalPlane_MouseUp(object sender, MouseEventArgs e)
		{
			ReloadScene();
			RedrawSelected();
			RedrawShapesExceptSelected();
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
			if (Selected.Count < 2) {
				return;
			}

			var group = new Group();

			foreach (var i in Selected) {
				group.Shapes.Add(i);
				Shapes.Remove(i);
			}

			Shapes.Add(group);
			Selected.Clear();
			Selected.Add(group);
			FillStatusBar();
		}

		private void UngroupSelected_Click(object sender, EventArgs e)
		{
			foreach (var i in Selected) {
				if (i is Group group) {
					foreach (var j in group.Shapes) {
						Shapes.Add(j);
					}

					Shapes.Remove(group);
				}
			}

			Selected.Clear();
			RedrawSelected();
			RedrawShapesExceptSelected();
			PictureBox.Refresh();
			FillStatusBar();
		}

		private void Alpha_Scroll(object sender, EventArgs e)
		{
			ReloadScene();
			RedrawShapesExceptSelected();

			foreach (var i in Selected) {
				var tempShape = (Shape)i.Clone();
				Rotate(tempShape, Alpha.Value * PI / 180, Tetta.Value * PI / 180, Radius.Value);
				DrawShape(tempShape, Pens.Blue);
			}

			PictureBox.Refresh();
		}

		private void Tetta_Scroll(object sender, EventArgs e)
		{
			ReloadScene();
			RedrawShapesExceptSelected();

			foreach (var i in Selected) {
				var tempShape = (Shape)i.Clone();
				Rotate(tempShape, Alpha.Value * PI / 180, Tetta.Value * PI / 180, Radius.Value);
				DrawShape(tempShape, Pens.Blue);
			}

			PictureBox.Refresh();
		}

		private void Radius_Scroll(object sender, EventArgs e)
		{
			ReloadScene();
			RedrawShapesExceptSelected();

			foreach (var i in Selected) {
				var tempShape = (Shape)i.Clone();
				Rotate(tempShape, Alpha.Value * PI / 180, Tetta.Value * PI / 180, Radius.Value);
				DrawShape(tempShape, Pens.Blue);
			}

			PictureBox.Refresh();
		}

		#endregion

		#region PictureBox event handler.

		private void PictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			IsMousePressed = true;
			OldVertex = new Vertex(e.X, e.Y, 0, 1);
			ToVertex(
				shape: OldVertex,
				xFactor: PictureBox.Image.Width / 2,
				yFactor: PictureBox.Image.Height / 2);

			switch (ModifierKeys) {
				default: {
					SelectShape(OldVertex);
					break;
				}

				case Keys.Control: {
					SelectManyShapes(OldVertex);
					break;
				}
			}

			FillStatusBar();
		}

		private void PictureBox_MouseLeave(object sender, EventArgs e)
		{
			FillStatusBar();
		}

		private void PictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			var currentVertex = new Vertex(e.X, e.Y, 0, 1);
			ToVertex(
				shape: currentVertex,
				xFactor: PictureBox.Image.Width / 2,
				yFactor: PictureBox.Image.Height / 2);

			if (IsMousePressed) {

				var offsetX = currentVertex.X - OldVertex.X;
				var offsetY = currentVertex.Y - OldVertex.Y;
				var offsetZ = 0;

				MoveSelected(offsetX, offsetY, offsetZ);
			}

			OldVertex = currentVertex;
			FillStatusBar();
		}

		private void PictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			IsMousePressed = false;
			OldVertex = new Vertex(0, 0, 0, 1);
			FillStatusBar();
		}

		#endregion

		#region Matrix transformations.

		void ToPoint(Shape shape, double xFactor, double yFactor)
		{
			var matrix = new double[] {
				1,          0,          0,  0,
				0,          -1,         0,  0,
				0,          0,          1,  0,
				xFactor,    yFactor,    0,  1
			};

			shape?.Transform(matrix);
		}

		void ToVertex(Shape shape, double xFactor, double yFactor)
		{
			var matrix = new double[] {
				1,          0,          0,  0,
				0,          -1,         0,  0,
				0,          0,          1,  0,
				-xFactor,    yFactor,    0,  1
			};

			shape?.Transform(matrix);
		}

		void Transport(Shape shape, double offsetX, double offsetY, double offsetZ)
		{
			var matrix = new double[] {
				1,          0,          0,          0,
				0,          1,          0,          0,
				0,          0,          1,          0,
				offsetX,    offsetY,    offsetZ,    1
			};

			shape?.Transform(matrix);
		}

		void Rotate(Shape shape, double alpha, double tetta, double radius)
		{
			var matrix = new double[] {
				Cos(alpha), Sin(alpha) * Sin(tetta),	0,	Sin(alpha) * Cos(tetta) / radius,
				0,			Cos(tetta),					0,	-Sin(tetta)/radius,
				Sin(alpha), -Cos(alpha) * Sin(tetta),	0,	-Cos(alpha) * Cos(tetta) / radius,
				0,			0,							0,	1
			};

			shape?.Transform(matrix);
		}

		#endregion

		void ReloadScene()
		{
			PictureBox.Image?.Dispose();
			Graphics?.Dispose();

			PictureBox.Image = new Bitmap(
				PictureBox.Width,
				PictureBox.Height);
			Graphics = Graphics.FromImage(
				PictureBox.Image);
		}

		Vertex GetRandomVertex()
		{
			return new Vertex(
				x: Random.Next(-PictureBox.Width / 2 + 10, PictureBox.Width / 2 - 10),
				y: Random.Next(-PictureBox.Height / 2 + 10, PictureBox.Height / 2 - 10),
				z: 0,
				uniformCoordinate: 1);
		}

		void DrawShape(Shape shape, Pen pen)
		{
			var tempShape = (Shape)shape.Clone();
			ToPoint(
				shape: tempShape,
				xFactor: PictureBox.Image.Width / 2,
				yFactor: PictureBox.Image.Height / 2);
			tempShape.Draw(Graphics, pen);
		}

		void RedrawShapesExceptSelected()
		{
			foreach (var i in Shapes.Except(Selected)) {
				DrawShape(i, Pens.Black);
			}
		}

		void RedrawSelected()
		{
			foreach (var i in Selected) {
				DrawShape(i, Pens.Blue);
			}
		}

		Shape GetNearestShape(Vertex vertex)
		{
			var minDistance = double.PositiveInfinity;
			Shape nearest = null;

			foreach (var i in Shapes) {
				var distance = i.GetDistance(vertex);

				if (minDistance > distance) {
					minDistance = distance;
					nearest = i.GetIntersection(vertex, 5);
				}
			}

			return nearest;
		}

		void SelectShape(Vertex vertex)
		{
			Selected.Clear();

			if (GetNearestShape(vertex) is Shape nearest) {
				Selected.Add(nearest);
			}

			ReloadScene();
			RedrawSelected();
			RedrawShapesExceptSelected();
			PictureBox.Refresh();
		}

		void SelectManyShapes(Vertex vertex)
		{
			if (GetNearestShape(vertex) is Shape nearest) {
				if (Selected.Contains(nearest)) {
					Selected.Remove(nearest);
				} else {
					Selected.Add(nearest);
				}

				ReloadScene();
				RedrawSelected();
				RedrawShapesExceptSelected();
				PictureBox.Refresh();
			}
		}

		void MoveSelected(double offsetX, double offsetY, double offsetZ)
		{
			foreach (var i in Selected) {
				Transport(i, offsetX, offsetY, offsetZ);
			}

			ReloadScene();
			RedrawSelected();
			RedrawShapesExceptSelected();
			PictureBox.Refresh();
		}

		void FillStatusBar()
		{
			StatusBar.Text =
				$"Shapes: {Shapes.Count}, " +
				$"Cursor: {OldVertex}, " +
				$"Equation: {Selected.FirstOrDefault()}";
		}
	}
}
