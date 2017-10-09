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
			Console.WriteLine();
			Console.WriteLine ("Поворот вокруг оси");
			Console.WriteLine ();
			{
				Figure fig = new Figure ();
				fig.Add (new Point (2, 2));
				fig.Add (new Point (4, 6));
				ToMatrix (fig, 7, 7).Print();
				Console.WriteLine ();
				ToMatrix (Figure.PovorotInZentr (fig, -1),7,7).Print ();
				Console.WriteLine ();
				ToMatrix (Figure.PovorotInZentr (fig, -3.14/2),7,7).Print ();
				Console.WriteLine ();
				ToMatrix (Figure.povorotPoint (fig, new Point (4, 4),-3.14/2), 7, 7).Print ();
			}
			Console.WriteLine();
			Console.WriteLine ("Точка пересечения");
			Console.WriteLine ();
			{
				Figure f1 = new Figure ();
				f1.Add (new Point (3, 1));
				f1.Add (new Point (3, 6));
				ToMatrix (f1, 7, 7).Print ();
				Console.WriteLine ();
				Figure f2 = new Figure ();
				f2.Add (new Point (1, 3));
				f2.Add (new Point (6, 3));
				ToMatrix (f2, 7, 7).Print ();
				Console.WriteLine ();
				Point tmp = Figure.GetPoint (f1, f2);
				tmp.Print ();
				ToMatrix (tmp, 7, 7).Print();
			}
			Console.WriteLine();
			Console.WriteLine ("Точка в многоугольнике");
			Console.WriteLine ();
			{
				Figure f1 = new Figure ();
				f1.Add (new Point (1, 1));
				f1.Add (new Point (1, 4));
				f1.Add (new Point (4, 6));
				f1.Add (new Point (4, 2));
				f1.Add (new Point (1, 1));

				Point tmp = new Point (2, 4);

				Figure.PointInPolygon res = f1.pointInFigure (tmp);

				Point tmp2 = new Point (6, 6);

				Figure.PointInPolygon res2 = f1.pointInFigure (tmp2);


				if (res==Figure.PointInPolygon.INSIDE)
					Console.WriteLine ("In");
				if (res == Figure.PointInPolygon.BOUNDARY)
					Console.WriteLine ("На границе");
				if (res == Figure.PointInPolygon.OUTSIDE)
					Console.WriteLine ("Вне");

				if (res2==Figure.PointInPolygon.INSIDE)
					Console.WriteLine ("In");
				if (res2 == Figure.PointInPolygon.BOUNDARY)
					Console.WriteLine ("На границе");
				if (res2 == Figure.PointInPolygon.OUTSIDE)
					Console.WriteLine ("Вне");

				f1.Add (tmp);
				f1.Add (tmp2);
				ToMatrix (f1, 7, 7).Print ();
			}
		}
	}
}
