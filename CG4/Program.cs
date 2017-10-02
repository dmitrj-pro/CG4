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
			res.Set (1, res.M()- p.y-1, p.x);
		}
		public static Matrix ToMatrix(Point p, int x, int y){
			Matrix res = new Matrix(x,y);
			setPoint (ref res, p);
			return res;
		}
		public static Matrix ToMatrix(Point p){
			return ToMatrix(p, p.x+1, p.y+1);
		}

		public static void Main (string[] args)
		{
			Point p = new Point (3, 5);
			//DrawPoint (ToMatrix (p, 6, 8));
			ToMatrix (p, 7, 9).Print();
			Console.WriteLine ();
			ToMatrix (Point.Smestchenie (p, 2, 2),7,9).Print ();

			/*
			Console.WriteLine ();
			Matrix m = new Matrix (2, 3);
			m.Set (1, 0, 0);
			m.Set (2, 0, 1);
			m.Set (3, 1, 0);
			m.Set (4, 1, 1);
			m.Set (5, 2, 0);
			m.Set (6, 2, 1);
			m.Print ();

			Matrix m1 = new Matrix (2, 2);
			m1.Set (1, 0, 0);
			m1.Set (2, 0, 1);
			m1.Set (2, 1, 0);
			m1.Set (3, 1, 1);
			m1.Print ();
			m.Mult (m1).Print ();
			Console.WriteLine ("Hello World!");
			*/
		}
	}
}
