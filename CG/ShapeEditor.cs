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
			var matrix = new double[] {
				(double)X1.Value, (double)Y1.Value, (double)Z1.Value, (double)UC1.Value,
				(double)X2.Value, (double)Y2.Value, (double)Z2.Value, (double)UC2.Value,
				(double)X3.Value, (double)Y3.Value, (double)Z3.Value, (double)UC3.Value,
				(double)X4.Value, (double)Y4.Value, (double)Z4.Value, (double)UC4.Value
			};

			foreach (var i in Shapes) {
				i.Transform(matrix);
			}

			DialogResult = DialogResult.OK;
		}
	}
}
