using System;

namespace CG4
{
	public class Point
	{
		public int x;
		public int y;
		public Point ()
		{
		}
		public Point (int _x, int _y)
		{
			x = _x;
			y = _y;

		}
		public static Point Smestchenie(Point point, int x, int y){
			Matrix p=new Matrix(3,3);
			p.Set(1,0,0);
			p.Set(1,1,1);
			p.Set(1,2,2);
			p.Set(x, 2,0);
			p.Set(y,2,1);
			Matrix p2 = new Matrix(3, 1);
			p2.Set (point.x, 0, 0);
			p2.Set (point.y, 0, 1);
			p2.Set (1, 0, 2);
			Matrix tmp = p2.Mult (p);
			return new Point (tmp.Get (0, 0), tmp.Get (0, 1));
		}
	}
}

