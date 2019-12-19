﻿using System;
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
		#region Fields and properties

		Graphics Graphics;
		Random Random = new Random();
		List<Shape> Shapes = new List<Shape>();
		List<Shape> Selected = new List<Shape>();
		Vertex OldVertex = new Vertex(0, 0, 0, 1);
		Boolean IsMousePressed = false;
		Int32 OldAlpha = 0;
		Int32 OldTetta = 0;
		Int32 OldZetta = 0;
		Double TouchEpsilon = 7;

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
			if (new ShapeEditor(Selected).ShowDialog() == DialogResult.OK) {
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
	}
}
