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
			//ToMatrix (Point.Povorot (p, 30)).Print ();
		}
	}
}
