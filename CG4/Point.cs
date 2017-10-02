using System;

namespace CG4
{
	public class Point
	{
		public double x;
		public double y;
		public Point ()
		{
		}
		public Point (double _x, double _y)
		{
			x = _x;
			y = _y;

		}
		public Matrix ToMatrix(){
			Matrix p2 = new Matrix(3, 1);
			p2.Set (x, 0, 0);
			p2.Set (y, 0, 1);
			p2.Set (1, 0, 2);
			return p2;
		}
		public static Point Smestchenie(Point point, int x, int y){
			return point.ToMatrix ().Mult (Matrix.Smestchenie (x, y)).ToPoint ();
		}
		public static Point Povorot(Point p, double x){
			return p.ToMatrix().Mult(Matrix.Povorot(x)).ToPoint();
		}
	}
}

