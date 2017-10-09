using System;

namespace CG4
{
	class MainClass
	{
		public static void DrawPoint(Matrix p){
			for (int i = 0; i < p.M(); i++) {
				for (int j = 0; j < p.N(); j++) {
					if (p.Get (i, j) == 0) {
						Console.Write (" ");
					} else {
						Console.Write ("0");
					}
					Console.Write (" ");
				}
				Console.WriteLine ();
			}
		}
		public static void setPoint(ref Matrix res, Point p){
			res.Set (1.0, (int)(res.M()- p.y-1), (int) p.x);
		}
		public static Matrix ToMatrix(Point p, int x, int y){
			Matrix res = new Matrix(x,y);
			setPoint (ref res, p);
			return res;
		}
		public static Matrix ToMatrix(Figure f, int x, int y){
			Matrix res = new Matrix(x,y);
			System.Collections.Generic.List<Point> p = f.Points ();
			for (int i = 0; i < p.Count; i++) {
				setPoint (ref res, p [i]);
			}
			return res;
		}
		public static Matrix ToMatrix(Point p){
			return ToMatrix(p, (int)(p.x+1), (int)(p.y+1));
		}

		public static void Main (string[] args)
		{
			Point p = new Point (3, 5);
			//DrawPoint (ToMatrix (p, 6, 8));
			ToMatrix (p, 7, 9).Print();
			Console.WriteLine ();
			ToMatrix (Point.Smestchenie (p, 2, 3),7,9).Print ();
			Console.WriteLine ();
			{
				Point tmp = Point.Povorot (p, 6);
				tmp.Print ();
				ToMatrix (tmp, 7, 9).Print ();
			}
			Console.WriteLine ();
			{
				ToMatrix (Point.Size (p, 0.5), 7, 9).Print ();
			}
			Console.WriteLine ();
			Console.WriteLine ("Figure");
			Console.WriteLine ();
			Figure f = new Figure ();
			f.Add (new Point (1, 1));
			f.Add (new Point (1, 3));
			f.Add (new Point (3, 1));
			f.Add (new Point (3, 3));
			ToMatrix (f, 7, 7).Print ();
			{
				ToMatrix (Figure.Smestchenie (f, 2, 3), 7, 7).Print ();
			}
			Console.WriteLine ();
			{
				ToMatrix (Figure.Size (f, 0.5), 7, 7).Print ();
			}
			Console.WriteLine ();
			{
				ToMatrix (Figure.Povorot (f, 0.4), 7, 7).Print ();
			}
		}
	}
}
