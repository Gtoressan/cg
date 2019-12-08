using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace CG
{
	abstract class Shape : ICloneable
	{
		public abstract object Clone();

		public abstract void Draw(Graphics graphics, Pen pen);

		public abstract Shape GetIntersection(Vertex vertex, double epsilon);

		public abstract double GetDistance(Vertex vertex);

		public abstract void Transform(double[] matrix);

		public static void Transform(Vertex[] vertices, double[] matrix)
		{
			for (int i = 0; i < vertices.Length; ++i) {
				vertices[i].X =
					vertices[i].X * matrix[0] +
					vertices[i].Y * matrix[4] +
					vertices[i].Z * matrix[8] +
					vertices[i].UC * matrix[12];
				vertices[i].Y =
					vertices[i].X * matrix[1] +
					vertices[i].Y * matrix[5] +
					vertices[i].Z * matrix[9] +
					vertices[i].UC * matrix[13];
				vertices[i].Z =
					vertices[i].X * matrix[2] +
					vertices[i].Y * matrix[6] +
					vertices[i].Z * matrix[10] +
					vertices[i].UC * matrix[14];
				vertices[i].UC =
					vertices[i].X * matrix[3] +
					vertices[i].Y * matrix[7] +
					vertices[i].Z * matrix[11] +
					vertices[i].UC * matrix[15];

				// Нормализация.
				vertices[i].X /= vertices[i].UC;
				vertices[i].Y /= vertices[i].UC;
				vertices[i].Z /= vertices[i].UC;
				vertices[i].UC /= vertices[i].UC;
			}
		}
	}

	class Vertex : Shape
	{
		public double X;
		public double Y;
		public double Z;
		public double UC;

		public Vertex(double x, double y, double z, double uniformCoordinate)
		{
			X = x;
			Y = y;
			Z = z;
			UC = uniformCoordinate;
		}

		public override object Clone()
		{
			return new Vertex(X, Y, Z, UC);
		}

		public override void Draw(Graphics graphics, Pen pen)
		{
			graphics.DrawEllipse(pen, (int)X, (int)Y, 2, 2);
		}

		public override double GetDistance(Vertex vertex)
		{
			return Sqrt(Pow(vertex.Y - Y, 2) + Pow(vertex.X - X, 2));
		}

		public override Shape GetIntersection(Vertex vertex, double epsilon)
		{
			if (GetDistance(vertex) <= epsilon) {
				return this;
			}

			return null;
		}

		public override string ToString() => $"{X}, {Y}, {Z}";

		public override void Transform(double[] matrix)
		{
			Transform(new Vertex[] { this }, matrix);
		}
	}

	class SubVertex : Shape
	{
		public Shape Origin;
		public Vertex Vertex;

		public SubVertex(Vertex vertex, Shape origin)
		{
			Vertex = vertex;
			Origin = origin;
		}

		public override object Clone()
		{
			return new SubVertex((Vertex)Vertex.Clone(), (Shape)Origin.Clone());
		}

		public override void Draw(Graphics graphics, Pen pen)
		{
			Origin.Draw(graphics, pen);
		}

		public override double GetDistance(Vertex vertex)
		{
			return Vertex.GetDistance(vertex);
		}

		public override Shape GetIntersection(Vertex vertex, double epsilon)
		{
			return Vertex.GetIntersection(vertex, epsilon);
		}

		public override string ToString() => $"{Origin} - {Vertex}";

		public override void Transform(double[] matrix)
		{
			Transform(new Vertex[] { Vertex }, matrix);
		}
	}

	class Cut : Shape
	{
		public Vertex A;
		public Vertex B;

		public Cut(Vertex a, Vertex b)
		{
			A = a;
			B = b;
		}

		public override object Clone()
		{
			return new Cut((Vertex)A.Clone(), (Vertex)B.Clone());
		}

		public override void Draw(Graphics graphics, Pen pen)
		{
			graphics.DrawLine(pen, (int)A.X, (int)A.Y, (int)B.X, (int)B.Y);
		}

		public override double GetDistance(Vertex vertex)
		{
			return GetSpace(vertex) * 2 / A.GetDistance(B);
		}

		public override Shape GetIntersection(Vertex vertex, double epsilon)
		{
			if (A.GetIntersection(vertex, epsilon) is Vertex a) {
				return a;
			} else if (B.GetIntersection(vertex, epsilon) is Vertex b) {
				return b;
			} else if (
				GetDistance(vertex) <= epsilon &&
				A.GetDistance(vertex) + B.GetDistance(vertex) <= A.GetDistance(B) + epsilon) {
				return this;
			} else {
				return null;
			}
		}

		public double GetSpace(Vertex vertex)
		{
			return 1d / 2 * Abs((B.Y - A.Y) * vertex.X - (B.X - A.X) * vertex.Y + B.X * A.Y - B.Y * A.X);
		}

		public override void Transform(double[] matrix)
		{
			Transform(new Vertex[] { A, B }, matrix);
		}
	}

	class Plane : Shape
	{
		public Cut OX;
		public Cut OY;
		public Cut OZ;

		public Plane(double x, double y, double z)
		{
			OX = new Cut(new Vertex(-x, 0, 0, 1), new Vertex(x, 0, 0, 1));
			OY = new Cut(new Vertex(0, -y, 0, 1), new Vertex(0, y, 0, 1));
			OZ = new Cut(new Vertex(0, 0, -z, 1), new Vertex(0, 0, z, 1));
		}

		public override object Clone()
		{
			return new Plane(0, 0, 0) {
				OX = (Cut)OX.Clone(),
				OY = (Cut)OY.Clone(),
				OZ = (Cut)OZ.Clone()
			};
		}

		public override void Draw(Graphics graphics, Pen pen)
		{
			OX.Draw(graphics, pen);
			OY.Draw(graphics, pen);
			OZ.Draw(graphics, pen);
		}

		public override double GetDistance(Vertex vertex)
		{
			return Min(
				Min(
					OX.GetDistance(vertex),
					OY.GetDistance(vertex)),
				OZ.GetDistance(vertex));
		}

		public override Shape GetIntersection(Vertex vertex, double epsilon)
		{
			if (OX.GetIntersection(vertex, epsilon) is Shape ox) {
				return ox;
			} else if (OY.GetIntersection(vertex, epsilon) is Shape oy) {
				return oy;
			} else if (OZ.GetIntersection(vertex, epsilon) is Shape oz) {
				return oz;
			} else {
				return null;
			}
		}

		public override void Transform(double[] matrix)
		{
			OX.Transform(matrix);
			OY.Transform(matrix);
			OZ.Transform(matrix);
		}
	}

	class Group : Shape
	{
		public List<Shape> Shapes = new List<Shape>();

		public override object Clone()
		{
			var group = new Group();

			foreach (var i in Shapes) {
				group.Shapes.Add((Shape)i.Clone());
			}

			return group;
		}

		public override void Draw(Graphics graphics, Pen pen)
		{
			foreach (var i in Shapes) {
				i.Draw(graphics, pen);
			}
		}

		public override double GetDistance(Vertex vertex)
		{
			return Shapes.Min(x => x.GetDistance(vertex));
		}

		public override Shape GetIntersection(Vertex vertex, double epsilon)
		{
			foreach (var i in Shapes) {
				if (i.GetIntersection(vertex, epsilon) != null) {
					return this;
				}
			}

			return null;
		}

		public override void Transform(double[] matrix)
		{
			foreach (var i in Shapes) {
				i.Transform(matrix);
			}
		}
	}
}
