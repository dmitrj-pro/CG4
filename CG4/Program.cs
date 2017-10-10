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
		public static void setPoint(ref Matrix res, CustomPoint p){
			res.Set (1.0, (int)(res.M()- p.y-1), (int) p.x);
		}
		public static Matrix ToMatrix(CustomPoint p, int x, int y){
			Matrix res = new Matrix(x,y);
			setPoint (ref res, p);
			return res;
		}
		public static Matrix ToMatrix(Figure f, int x, int y){
			Matrix res = new Matrix(x,y);
			System.Collections.Generic.List<CustomPoint> p = f.Points ();
			for (int i = 0; i < p.Count; i++) {
				setPoint (ref res, p [i]);
			}
			return res;
		}
		public static Matrix ToMatrix(CustomPoint p){
			return ToMatrix(p, (int)(p.x+1), (int)(p.y+1));
		}

		public static void Main (string[] args)
		{
		}
	}
}
