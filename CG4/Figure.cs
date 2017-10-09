using System;
using System.Collections.Generic;

namespace CG4
{
	public class Figure
	{
		List<Point> points;
		public Figure ()
		{
			points = new List<Point> ();
		}
		public void Add(Point t){
			points.Add (t);
		}
		public List<Point> Points(){
			return points;
		}
		public static Figure Smestchenie(Figure f, int x,int y){
			Figure res = new Figure ();
			for (int i = 0; i < f.points.Count; i++) {
				res.Add (Point.Smestchenie (f.points [i], x, y));
			}
			return res;
		}
		public static Figure Povorot(Figure f, double x){
			Figure res = new Figure ();
			for (int i = 0; i < f.points.Count; i++) {
				res.Add (Point.Povorot (f.points [i], x));
			}
			return res;
		}
		public static Figure Size(Figure f, double size){
			Figure res = new Figure ();
			for (int i = 0; i < f.points.Count; i++) {
				res.Add (Point.Size (f.points [i], size));
			}
			return res;
		}
	}
}

