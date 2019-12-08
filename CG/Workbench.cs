﻿using System;
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
		List<Shape> Selected = new List<Shape>();
		Vertex OldVertex = new Vertex(0, 0, 0, 1);
		Boolean IsMousePressed = false;

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
			foreach (var i in Selected) {
				i.Draw(Graphics, new Pen(PictureBox.BackColor));
				Shapes.Remove(i);
			}

			Selected.Clear();
			RedrawAllShapes();
			PictureBox.Refresh();
		}

		private void ClearScene_Click(object sender, EventArgs e)
		{
			PictureBox.Image.Dispose();
			Graphics.Dispose();
			PictureBox.Image = new Bitmap(
				PictureBox.Width,
				PictureBox.Height);
			Graphics = Graphics.FromImage(PictureBox.Image);
			Shapes.Clear();
			Selected.Clear();
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
			RedrawAllShapes();
			PictureBox.Refresh();
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
			IsMousePressed = true;
			OldVertex = new Vertex(e.X, e.Y, 0, 1);

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
		}

		private void PictureBox_MouseLeave(object sender, EventArgs e)
		{
			
		}

		private void PictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (IsMousePressed) {
				var offsetX = e.X - OldVertex.X;
				var offsetY = e.Y - OldVertex.Y;
				var offsetZ = 0;

				MoveSelected(offsetX, offsetY, offsetZ);
				OldVertex = new Vertex(e.X, e.Y, 0, 1);
			}
		}

		private void PictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			IsMousePressed = false;
			OldVertex = new Vertex(0, 0, 0, 1);
		}

		#endregion

		#region Matrix transformations.

		void TogglePlane(Shape shape, double xFactor, double yFactor)
		{
			var matrix = new double[] {
				1,          0,          0,  0,
				0,          -1,         0,  0,
				0,          0,          1,  0,
				xFactor,    yFactor,    0,  1
			};

			shape.Transform(matrix);
		}

		void Transport(Shape shape, double offsetX, double offsetY, double offsetZ)
		{
			var matrix = new double[] {
				1,          0,          0,          0,
				0,          1,          0,          0,
				0,          0,          1,          0,
				offsetX,    offsetY,    offsetZ,    1
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
			foreach (var i in Shapes.Except(Selected)) {
				i.Draw(Graphics, Pens.Black);
			}

			foreach (var i in Selected) {
				i.Draw(Graphics, Pens.Blue);
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
			foreach (var i in Selected) {
				i.Draw(Graphics, Pens.Black);
			}

			Selected.Clear();

			if (GetNearestShape(vertex) is Shape nearest) {
				nearest.Draw(Graphics, Pens.Blue);
				Selected.Add(nearest);
			}

			PictureBox.Refresh();
		}

		void SelectManyShapes(Vertex vertex)
		{
			if (GetNearestShape(vertex) is Shape nearest) {
				if (Selected.Contains(nearest)) {
					nearest.Draw(Graphics, Pens.Black);
					Selected.Remove(nearest);
				} else {
					nearest.Draw(Graphics, Pens.Blue);
					Selected.Add(nearest);
				}

				PictureBox.Refresh();
			}
		}

		void MoveSelected(double offsetX, double offsetY, double offsetZ)
		{
			foreach (var i in Selected) {
				i.Draw(Graphics, new Pen(PictureBox.BackColor));
				Transport(i, offsetX, offsetY, offsetZ);
			}

			RedrawAllShapes();
			PictureBox.Refresh();
		}
	}
}
