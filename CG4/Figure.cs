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
		//Параллельное смещение фигуры
		public static Figure Smestchenie(Figure f, int x,int y){
			Figure res = new Figure ();
			for (int i = 0; i < f.points.Count; i++) {
				res.Add (Point.Smestchenie (f.points [i], x, y));
			}
			return res;
		}
		//Поворот фигуры на x РАДИАН
		public static Figure Povorot(Figure f, double x){
			Figure res = new Figure ();
			for (int i = 0; i < f.points.Count; i++) {
				res.Add (Point.Povorot (f.points [i], x));
			}
			return res;
		}
		//Масштабирование фигуры
		//Если size == 0.5, то это уменьшение фигуры в 2 раза
		public static Figure Size(Figure f, double size){
			Figure res = new Figure ();
			for (int i = 0; i < f.points.Count; i++) {
				res.Add (Point.Size (f.points [i], size));
			}
			return res;
		}
		//Поворот фигуры вокруг точки
		public static Figure povorotPoint(Figure f, Point p, double ug){
			if (f.points.Count != 2)
				throw new Exception ("This is not line");
			Point p1 = f.points [0];
			Point p2 = f.points [1];
			Figure res = new Figure ();
			Point tmp = p;
			p1 = Point.Smestchenie (p1, (int)((-1) * tmp.x), (int)((-1) * tmp.y));
			p2 = Point.Smestchenie (p2, (int)((-1) * tmp.x), (int)((-1) * tmp.y));

			p1 = Point.Povorot (p1, ug);
			p2 = Point.Povorot (p2, ug);

			p1 = Point.Smestchenie (p1, (int)tmp.x, (int)tmp.y);
			p2 = Point.Smestchenie (p2, (int)tmp.x, (int)tmp.y);

			res.Add (p1);
			res.Add (p2);
			return res;
		}
		//Это поворот линии вокруг своего центра.
		//Если угол равен -3.14/2, то это поворот на 90 градусов
		public static Figure PovorotInZentr(Figure f, double ug){
			if (f.points.Count != 2)
				throw new Exception ("This is not line");
			Point p1 = f.points [0];
			Point p2 = f.points [1];

			Point tmp = new Point();
			tmp.x = (p1.x + p2.x) / 2;
			tmp.y = (p1.y + p2.y) / 2;
			return Figure.povorotPoint (f, tmp, ug);
		}
		public static Point GetPoint(Figure f1, Figure f2){
			if (f1.points.Count != f2.points.Count)
				throw new Exception ("this is not lines");
			if (f1.points.Count != 2)
				throw new Exception ("this is not lines");
			double tg1 = (f1.points[1].x-f1.points[0].x)/(f1.points[1].y-f1.points[0].y); 
			double tg2 = (f2.points[1].x-f2.points[0].x)/(f2.points[1].y-f2.points[0].y);
			if (tg1==tg2)
				throw new Exception ("Lines is parallel");
			Point res = new Point ();
			res.x = -((f1.points[0].x*f1.points[1].y-f1.points[1].x*f1.points[0].y) 
				*(f2.points[1].x-f2.points[0].x)-(f2.points[0].x*f2.points[1].y-f2.points[1].x*f2.points[0].y) 
				*(f1.points[1].x-f1.points[0].x))/((f1.points[0].y-f1.points[1].y) 
					*(f2.points[1].x-f2.points[0].x)-(f2.points[0].y-f2.points[1].y)*(f1.points[1].x-f1.points[0].x)); 
			res.y = ((f2.points[0].y-f2.points[1].y)*(-res.x)-(f2.points[0].x*f2.points[1].y-f2.points[1].x*f2.points[0].y))/(f2.points[1].x-f2.points[0].x); 
			return res;
		}
	}
}

