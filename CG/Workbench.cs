using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using static System.Math;

namespace CG
{
	public partial class Workbench : Form
	{
		#region Fields and properties

		Graphics Graphics;
		Random Random = new Random();
		public List<Shape> Shapes = new List<Shape>();
		List<Shape> Selected = new List<Shape>();
		Vertex OldVertex = new Vertex(0, 0, 0, 1);
		Boolean IsMousePressed = false;
		Int32 OldAlpha = 0;
		Int32 OldTetta = 0;
		Int32 OldZetta = 0;
		Double TouchEpsilon = 7;

		public Int32 SpecialActionIndex = -1;
		public Vertex ScreenVertex = new Vertex(3, 0, 0, 1);

		#endregion

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
			DrawExceptSelected();
			DrawSelectedShapes();
			PictureBox.Refresh();
			FillStatusBar();
		}

		private void EditSelected_Click(object sender, EventArgs e)
		{
			if (new ShapeEditor(Selected) { Owner = this }.ShowDialog() == DialogResult.OK) {
				ReloadScene();
				DrawExceptSelected();
				DrawSelectedShapes();
			}
		}

		private void RemoveSelected_Click(object sender, EventArgs e)
		{
			foreach (var i in Selected) {
				Shapes.Remove(i);
			}

			Selected.Clear();
			ReloadScene();
			DrawExceptSelected();
			DrawSelectedShapes();
			PictureBox.Refresh();
			FillStatusBar();
		}

		private void SelectAll_Click(object sender, EventArgs e)
		{
			Selected.Clear();
			Selected.AddRange(Shapes);
			ReloadScene();
			DrawSelectedShapes();
			PictureBox.Refresh();
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
			using (var fileDialog = new SaveFileDialog()) {
				if (fileDialog.ShowDialog() == DialogResult.OK) {
					using (var stream = new FileStream(fileDialog.FileName, FileMode.OpenOrCreate)) {
						new BinaryFormatter().Serialize(stream, Shapes);
					}
				}
			}
		}

		private void ImportScene_Click(object sender, EventArgs e)
		{
			using (var fileDialog = new OpenFileDialog()) {
				if (fileDialog.ShowDialog() == DialogResult.OK) {
					using (var stream = new FileStream(fileDialog.FileName, FileMode.Open)) {
						Shapes = (List<Shape>)new BinaryFormatter().Deserialize(stream);
						Selected.Clear();
					}
				}
			}

			ReloadScene();
			DrawExceptSelected();
			PictureBox.Refresh();
		}

		private void ToggleGlobalPlane_MouseDown(object sender, MouseEventArgs e)
		{
			var plane = new Plane(
				x: PictureBox.Image.Width / 2,
				y: PictureBox.Image.Height / 2,
				z: 0);
			DrawShape(plane, Pens.LightGray);
			DrawExceptSelected();
			DrawSelectedShapes();
			PictureBox.Refresh();
		}

		private void ToggleGlobalPlane_MouseUp(object sender, MouseEventArgs e)
		{
			ReloadScene();
			DrawExceptSelected();
			DrawSelectedShapes();
			PictureBox.Refresh();
		}

		private void ToggleLocalPlane_MouseDown(object sender, MouseEventArgs e)
		{
			if (Selected.Count == 0) {
				return;
			}

			var gravityCenter = Selected.First().GetGravityCenter();
			var plane = new Plane(100, 100, 100);

			ToPoint(plane, gravityCenter.X, gravityCenter.Y);
			DrawShape(plane, Pens.LightGray);
			DrawExceptSelected();
			DrawSelectedShapes();
			PictureBox.Refresh();
		}

		private void ToggleLocalPlane_MouseUp(object sender, MouseEventArgs e)
		{
			ReloadScene();
			DrawExceptSelected();
			DrawSelectedShapes();
			PictureBox.Refresh();
		}

		private void GroupSelected_Click(object sender, EventArgs e)
		{
			if (Selected.Count < 1) {
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
			DrawSelectedShapes();
			DrawExceptSelected();
			PictureBox.Refresh();
			FillStatusBar();
		}

		private void Alpha_Scroll(object sender, EventArgs e)
		{
			foreach (var i in Selected) {
				var gravityCenter = i.GetGravityCenter();
				PreProcessor(i, gravityCenter);
				RotateOnX(i, (Alpha.Value - OldAlpha) * PI / 180);
				OldAlpha = Alpha.Value;
				PostProcessor(i, gravityCenter);
			}

			ReloadScene();
			DrawExceptSelected();
			DrawSelectedShapes();
			PictureBox.Refresh();
		}

		private void Tetta_Scroll(object sender, EventArgs e)
		{
			foreach (var i in Selected) {
				var gravityCenter = i.GetGravityCenter();
				PreProcessor(i, gravityCenter);
				RotateOnY(i, (Tetta.Value - OldTetta) * PI / 180);
				OldTetta = Tetta.Value;
				PostProcessor(i, gravityCenter);
			}

			ReloadScene();
			DrawExceptSelected();
			DrawSelectedShapes();
			PictureBox.Refresh();
		}

		private void Zetta_Scroll(object sender, EventArgs e)
		{
			foreach (var i in Selected) {
				var gravityCenter = i.GetGravityCenter();
				PreProcessor(i, gravityCenter);
				RotateOnZ(i, (Zetta.Value - OldZetta) * PI / 180);
				OldZetta = Zetta.Value;
				PostProcessor(i, gravityCenter);
			}

			ReloadScene();
			DrawExceptSelected();
			DrawSelectedShapes();
			PictureBox.Refresh();
		}

		private void Radius_Scroll(object sender, EventArgs e)
		{
			ReloadScene();
			DrawExceptSelected();
			DrawSelectedShapes();
			PictureBox.Refresh();
		}

		private void AddMedian_Click(object sender, EventArgs e)
		{
			SpecialActionIndex = 0;
		}

		private void Height_Click(object sender, EventArgs e)
		{
			SpecialActionIndex = 1;
		}

		private void Bisector_Click(object sender, EventArgs e)
		{
			SpecialActionIndex = 2;
		}

		private void Morphing_Scroll(object sender, EventArgs e)
		{
			if (Selected.Count == 2 &&
				Selected[0] is Cut cut1 &&
				Selected[1] is Cut cut2) {

				Shapes.Add(new Cut(
					a: new Vertex(
						x: cut1.A.Vertex.X * (1 - Morphing.Value / 10) + cut2.A.Vertex.X * Morphing.Value / 10,
						y: cut1.A.Vertex.Y * (1 - Morphing.Value / 10) + cut2.A.Vertex.Y * Morphing.Value / 10,
						z: cut1.A.Vertex.Z * (1 - Morphing.Value / 10) + cut2.A.Vertex.Z * Morphing.Value / 10,
						uniformCoordinate: 1),
					b: new Vertex(
						x: cut1.B.Vertex.X * (1 - Morphing.Value / 10) + cut2.B.Vertex.X * Morphing.Value / 10,
						y: cut1.B.Vertex.Y * (1 - Morphing.Value / 10) + cut2.B.Vertex.Y * Morphing.Value / 10,
						z: cut1.B.Vertex.Z * (1 - Morphing.Value / 10) + cut2.B.Vertex.Z * Morphing.Value / 10,
						uniformCoordinate: 1)));
			}

			ReloadScene();
			DrawExceptSelected();
			DrawSelectedShapes();
			PictureBox.Refresh();
		}

		private void Shadow_Click(object sender, EventArgs e)
		{
			SpecialActionIndex = 3;
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

			ProcessSpecialAction(OldVertex);
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
				var offsetZ = currentVertex.Z - OldVertex.Z;

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

		void MukhinRotate(Shape shape, double alpha, double tetta, double radius)
		{
			var matrix = new double[] {
				Cos(alpha), Sin(alpha) * Sin(tetta),    0,  Sin(alpha) * Cos(tetta) / radius,
				0,          Cos(tetta),                 0,  -Sin(tetta)/radius,
				Sin(alpha), -Cos(alpha) * Sin(tetta),   0,  -Cos(alpha) * Cos(tetta) / radius,
				0,          0,                          0,  1
			};
		}

		void RotateOnX(Shape shape, double radians)
		{
			var matrix = new double[] {
				1,  0,              0,              0,
				0,  Cos(radians),   Sin(radians),   0,
				0,  -Sin(radians),  Cos(radians),   0,
				0,  0,              0,              1
			};

			shape?.Transform(matrix);
		}

		void RotateOnY(Shape shape, double radians)
		{
			var matrix = new double[] {
				Cos(radians),   0,  -Sin(radians),  0,
				0,              1,  0,              0,
				Sin(radians),   0,  Cos(radians),   0,
				0,              0,  0,              1
			};

			shape?.Transform(matrix);
		}

		void RotateOnZ(Shape shape, double radians)
		{
			var matrix = new double[] {
				Cos(radians),   Sin(radians),   0,  0,
				-Sin(radians),  Cos(radians),   0,  0,
				0,              0,              1,  0,
				0,              0,              0,  1
			};

			shape?.Transform(matrix);
		}

		void ProjectOnXY(Shape shape, double radius)
		{
			var matrix = new double[] {
				1,  0,  0,  0,
				0,  1,  0,  0,
				0,  0,  0,  -1 / radius,
				0,  0,  0,  1
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
				z: Random.Next(-PictureBox.Height / 2 + 10, PictureBox.Height / 2 - 10),
				uniformCoordinate: 1);
		}

		void PreProcessor(Shape shape, Vertex gravityCenter)
		{
			if (UseLocalPlane.Checked && shape != null) {
				Transport(shape, -gravityCenter.X, -gravityCenter.Y, -gravityCenter.Z);
			}
		}

		void PostProcessor(Shape shape, Vertex gravityCenter)
		{
			if (UseLocalPlane.Checked && shape != null) {
				Transport(shape, gravityCenter.X, gravityCenter.Y, gravityCenter.Z);
			}
		}

		void DrawShape(Shape shape, Pen pen)
		{
			var tempShape = (Shape)shape.Clone();
			ProjectOnXY(tempShape, Radius.Value);
			ToPoint(
				shape: tempShape,
				xFactor: PictureBox.Image.Width / 2,
				yFactor: PictureBox.Image.Height / 2);

			if (tempShape is SubVertex subVertex) {
				ProjectOnXY(subVertex.Origin, Radius.Value);
				ToPoint(
					shape: subVertex.Origin,
					xFactor: PictureBox.Image.Width / 2,
					yFactor: PictureBox.Image.Height / 2);
			}

			tempShape.Draw(Graphics, pen);
		}

		void DrawExceptSelected()
		{
			foreach (var i in Shapes.Except(Selected)) {
				DrawShape(i, Pens.Black);
			}
		}

		void DrawSelectedShapes()
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
					nearest = i.GetIntersection(vertex, TouchEpsilon);
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
			DrawExceptSelected();
			DrawSelectedShapes();
			PictureBox.Refresh();
		}

		void SelectManyShapes(Vertex vertex)
		{
			if (GetNearestShape(vertex) is Shape nearest) {
				if (nearest is SubVertex subvertex) {
					nearest = subvertex.Origin;
				}

				if (Selected.Contains(nearest)) {
					Selected.Remove(nearest);
				} else {
					Selected.Add(nearest);
				}

				ReloadScene();
				DrawExceptSelected();
				DrawSelectedShapes();
				PictureBox.Refresh();
			}
		}

		void MoveSelected(double offsetX, double offsetY, double offsetZ)
		{
			foreach (var i in Selected) {
				Transport(i, offsetX, offsetY, offsetZ);
			}

			ReloadScene();
			DrawExceptSelected();
			DrawSelectedShapes();
			PictureBox.Refresh();
		}

		void FillStatusBar()
		{
			StatusBar.Text =
				$"Shapes: {Shapes.Count}, " +
				$"Equation: {(Selected.FirstOrDefault() is Shape shape ? shape.ToString() : "n/a ")}, " +
				$"Cursor: {OldVertex}, " +
				"";
		}

		void ProcessSpecialAction(Vertex vertex)
		{
			switch (SpecialActionIndex) {
				default: {
					break;
				}

				// Добавить медиану.
				case 0: {
					if (Selected.FirstOrDefault() is Cut cut) {
						Shapes.Add(new Cut(vertex, cut.GetGravityCenter()));
					}
					break;
				}

				// Добавить высоту.
				case 1: {
					if (Selected.FirstOrDefault() is Cut cut) {
						var a = cut.A.Vertex.Y - cut.B.Vertex.Y;
						var b = cut.B.Vertex.X - cut.A.Vertex.X;
						var c = cut.A.Vertex.X * cut.B.Vertex.Y - cut.B.Vertex.X * cut.A.Vertex.Y;
						var x = (-a * c - b * a * vertex.Y + Pow(b, 2) * vertex.X) / (Pow(b, 2) + Pow(a, 2));
						var y = (Pow(a, 2) * vertex.Y - a * b * vertex.X - c * b) / (Pow(b, 2) + Pow(a, 2));
						var z = 0d;

						if (Abs(b) > 0.00001) {
							z = cut.A.Vertex.Z + (cut.B.Vertex.Z - cut.A.Vertex.Z) * ((x - cut.A.Vertex.X) / a);
						} else {
							z = cut.A.Vertex.Z + (cut.B.Vertex.Z - cut.A.Vertex.Z) * ((y - cut.A.Vertex.Y) / b);
						}

						Shapes.Add(new Cut(vertex, new Vertex(x, y, z, 1)));
					}
					break;
				}

				// Добавить биссектрису.
				case 2: {
					if (Selected.Count == 2 &&
						Selected.First() is Cut cut1 &&
						Selected.Skip(1).First() is Cut cut2) {
						var A1 = cut1.A.Vertex;
						var B1 = cut1.B.Vertex;
						var A2 = cut2.A.Vertex;
						var B2 = cut2.B.Vertex;
						var a1 = A1.Y - B1.Y;
						var b1 = B1.X - A1.X;
						var c1 = A1.X * B1.Y - B1.X * A1.Y;
						var a2 = A2.Y - B2.Y;
						var b2 = B2.X - A2.X;
						var c2 = A2.X * B2.Y - B2.X * A2.Y;

						if (a1 * b2 - a2 * b1 == 0) {
							return;
						}

						var x1 = (b1 * c2 - b2 * c1) / (a1 * b2 - a2 * b1);
						var y1 = (c1 * a2 - c2 * a1) / (a1 * b2 - a2 * b1);
						var z1 = 0d;

						if (Abs(b1) > 0.00001) {
							z1 = (A1.Z + (B1.Z - A1.Z) * (x1 - A1.X) / b1);
						} else {
							z1 = (A1.Z + (B1.Z - A1.Z) * (y1 - A1.Y) / a1);
						}

						var leftLengthA = Sqrt(Pow((A1.X - x1), 2) + Pow((A1.Y - y1), 2) + Pow((A1.Z - z1), 2));
						var leftLengthB = Sqrt(Pow((B1.X - x1), 2) + Pow((B1.Y - y1), 2) + Pow((B1.Z - z1), 2));
						Vertex maxLeft = leftLengthA > leftLengthB ? A1 : B1;
						var leftLength = Max(leftLengthA, leftLengthB);

						var rightLengthA = Sqrt(Pow((A2.X - x1), 2) + Pow((A2.Y - y1), 2) + Pow((A2.Z - z1), 2));
						var rightLengthB = Sqrt(Pow((B2.X - x1), 2) + Pow((B2.Y - y1), 2) + Pow((B2.Z - z1), 2));
						Vertex maxRight = rightLengthA > rightLengthB ? A2 : B2;
						var rightLength = Max(rightLengthA, rightLengthB);

						var leftMove = leftLength / (leftLength + rightLength);
						var rightMove = rightLength / (leftLength + rightLength);
						var x2 = (float)(rightMove * maxLeft.X + leftMove * maxRight.X);
						var y2 = (float)(rightMove * maxLeft.Y + leftMove * maxRight.Y);
						var z2 = (float)(rightMove * maxLeft.Z + leftMove * maxRight.Z);

						Shapes.Add(new Cut(new Vertex(x1, y1, z1, 1), new Vertex(x2, y2, z2, 1)));
					}
					break;
				}

				// Отрисовать тени.
				case 3: {
					if (Selected.Count == 1 &&
						Selected.FirstOrDefault() is Group group) {
						var shadow = new Group();
						var anchorPoint = new Vertex(
							x: ScreenVertex.X != 0 ? Random.NextDouble() : 0,
							y: ScreenVertex.Y != 0 ? Random.NextDouble() : 0,
							z: ScreenVertex.Z != 0 ? Random.NextDouble() : 0,
							uniformCoordinate: 1);

						foreach (Cut i in group.Shapes) {
							shadow.Shapes.Add(new Cut(
								a: OldVertex + (i.A.Vertex - OldVertex) * (ScreenVertex * (anchorPoint - OldVertex) / (ScreenVertex * (i.A.Vertex - OldVertex))),
								b: OldVertex + (i.B.Vertex - OldVertex) * (ScreenVertex * (anchorPoint - OldVertex) / (ScreenVertex * (i.B.Vertex - OldVertex)))));
						}

						Shapes.Add(shadow);
					}
					break;
				}
			}

			SpecialActionIndex = -1;
			ReloadScene();
			DrawExceptSelected();
			DrawSelectedShapes();
			PictureBox.Refresh();
		}
	}
}
