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
	partial class ShapeEditor : Form
	{
		List<Shape> Shapes;

		public ShapeEditor(List<Shape> shapes)
		{
			InitializeComponent();
			Shapes = shapes;
		}

		private void Apply_Click(object sender, EventArgs e)
		{
			// Матричное преобразование.
			var matrix = new double[] {
				(double)X1.Value, (double)Y1.Value, (double)Z1.Value, (double)UC1.Value,
				(double)X2.Value, (double)Y2.Value, (double)Z2.Value, (double)UC2.Value,
				(double)X3.Value, (double)Y3.Value, (double)Z3.Value, (double)UC3.Value,
				(double)X4.Value, (double)Y4.Value, (double)Z4.Value, (double)UC4.Value
			};

			foreach (var i in Shapes) {
				i.Transform(matrix);
			}

			// Установка точки экрана для отрисовки тени.
			if (ScreenVertexX.Value + ScreenVertexY.Value + ScreenVertexZ.Value != ScreenVertexX.Value &&
				ScreenVertexX.Value + ScreenVertexY.Value + ScreenVertexZ.Value != ScreenVertexY.Value &&
				ScreenVertexX.Value + ScreenVertexY.Value + ScreenVertexZ.Value != ScreenVertexZ.Value) {
				(Owner as Workbench).ScreenVertex = new Vertex(
				x: 3,
				y: 0,
				z: 0,
				uniformCoordinate: 1);
			} else {
				(Owner as Workbench).ScreenVertex = new Vertex(
					x: (double)ScreenVertexX.Value,
					y: (double)ScreenVertexY.Value,
					z: (double)ScreenVertexZ.Value,
					uniformCoordinate: 1);
			}


			// Сигнализирует о том, что Workbench должен перерисовать сцену.
			DialogResult = DialogResult.OK;
		}
	}
}
