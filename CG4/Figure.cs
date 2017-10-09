﻿using System;
using System.Collections.Generic;

namespace CG4
{
	public class Figure
	{
		List<CustomPoint> points;
		public Figure ()
		{
			points = new List<CustomPoint> ();
		}
		public void Add(CustomPoint t){
			points.Add (t);
		}
		public List<CustomPoint> Points(){
			return points;
		}
		//Параллельное смещение фигуры
		public static Figure Smestchenie(Figure f, int x,int y){
			Figure res = new Figure ();
			for (int i = 0; i < f.points.Count; i++) {
				res.Add (CustomPoint.Smestchenie (f.points [i], x, y));
			}
			return res;
		}
		//Поворот фигуры на x РАДИАН
		public static Figure Povorot(Figure f, double x){
			Figure res = new Figure ();
			for (int i = 0; i < f.points.Count; i++) {
				res.Add (CustomPoint.Povorot (f.points [i], x));
			}
			return res;
		}
		//Масштабирование фигуры
		//Если size == 0.5, то это уменьшение фигуры в 2 раза
		public static Figure Size(Figure f, double size){
			Figure res = new Figure ();
			for (int i = 0; i < f.points.Count; i++) {
				res.Add (CustomPoint.Size (f.points [i], size));
			}
			return res;
		}
		//Поворот фигуры вокруг точки
		public static Figure povorotPoint(Figure f, CustomPoint p, double ug){
			if (f.points.Count != 2)
				throw new Exception ("This is not line");
			CustomPoint p1 = f.points [0];
			CustomPoint p2 = f.points [1];
			Figure res = new Figure ();
			CustomPoint tmp = p;
			p1 = CustomPoint.Smestchenie (p1, (int)((-1) * tmp.x), (int)((-1) * tmp.y));
			p2 = CustomPoint.Smestchenie (p2, (int)((-1) * tmp.x), (int)((-1) * tmp.y));

			p1 = CustomPoint.Povorot (p1, ug);
			p2 = CustomPoint.Povorot (p2, ug);

			p1 = CustomPoint.Smestchenie (p1, (int)tmp.x, (int)tmp.y);
			p2 = CustomPoint.Smestchenie (p2, (int)tmp.x, (int)tmp.y);

			res.Add (p1);
			res.Add (p2);
			return res;
		}
		//Это поворот линии вокруг своего центра.
		//Если угол равен -3.14/2, то это поворот на 90 градусов
		public static Figure PovorotInZentr(Figure f, double ug){
			if (f.points.Count != 2)
				throw new Exception ("This is not line");
			CustomPoint p1 = f.points [0];
			CustomPoint p2 = f.points [1];

			CustomPoint tmp = new CustomPoint();
			tmp.x = (p1.x + p2.x) / 2;
			tmp.y = (p1.y + p2.y) / 2;
			return Figure.povorotPoint (f, tmp, ug);
		}
		//54637276
		public static CustomPoint GetPoint(Figure f1, Figure f2){
			if (f1.points.Count != f2.points.Count)
				throw new Exception ("this is not lines");
			if (f1.points.Count != 2)
				throw new Exception ("this is not lines");
			double tg1 = (f1.points[1].x-f1.points[0].x)/(f1.points[1].y-f1.points[0].y); 
			double tg2 = (f2.points[1].x-f2.points[0].x)/(f2.points[1].y-f2.points[0].y);
			if (tg1==tg2)
				throw new Exception ("Lines is parallel");
			CustomPoint res = new CustomPoint ();
			res.x = -((f1.points[0].x*f1.points[1].y-f1.points[1].x*f1.points[0].y) 
				*(f2.points[1].x-f2.points[0].x)-(f2.points[0].x*f2.points[1].y-f2.points[1].x*f2.points[0].y) 
				*(f1.points[1].x-f1.points[0].x))/((f1.points[0].y-f1.points[1].y) 
					*(f2.points[1].x-f2.points[0].x)-(f2.points[0].y-f2.points[1].y)*(f1.points[1].x-f1.points[0].x)); 
			res.y = ((f2.points[0].y-f2.points[1].y)*(-res.x)-(f2.points[0].x*f2.points[1].y-f2.points[1].x*f2.points[0].y))/(f2.points[1].x-f2.points[0].x); 
			return res;
		}
		public enum PointOverEdge { LEFT, RIGHT, BETWEEN, OUTSIDE } //положение точки относительно отрезка
		public static PointOverEdge classify(CustomPoint p, CustomPoint v, CustomPoint w) //положение точки p относительно отрезка vw
		{
			//коэффициенты уравнения прямой
			double a = v.y - w.y;
			double b = w.x - v.x;
			double c = v.x * w.y - w.x * v.y;

			//подставим точку в уравнение прямой
			double f = a * p.x + b * p.y + c;
			if (f > 0)
				return PointOverEdge.RIGHT; //точка лежит справа от отрезка
			if (f < 0)
				return PointOverEdge.LEFT; //слева от отрезка

			double minX = Math.Min(v.x, w.x);
			double maxX = Math.Max(v.x, w.x);
			double minY = Math.Min(v.y, w.y);
			double maxY = Math.Max(v.y, w.y);

			if (minX <= p.x && p.x <= maxX && minY <= p.y && p.y <= maxY)
				return PointOverEdge.BETWEEN; //точка лежит на отрезке
			return PointOverEdge.OUTSIDE; //точка лежит на прямой, но не на отрезке
		}

		private enum EdgeType { TOUCHING, CROSSING, INESSENTIAL } //положение ребра

		private static EdgeType edgeType(CustomPoint a, CustomPoint v, CustomPoint w) //тип ребра vw для точки a
		{
			switch (classify(a, v, w))
			{
				case PointOverEdge.LEFT:
					return ((v.y < a.y) && (a.y <= w.y)) ? EdgeType.CROSSING : EdgeType.INESSENTIAL;
				case PointOverEdge.RIGHT:
					return ((w.y < a.y) && (a.y <= v.y)) ? EdgeType.CROSSING : EdgeType.INESSENTIAL;
				case PointOverEdge.BETWEEN:
					return EdgeType.TOUCHING;
				default:
					return EdgeType.INESSENTIAL;
			}
		}
		public enum PointInPolygon { INSIDE, OUTSIDE, BOUNDARY } //положение точки в многоугольнике

		public PointInPolygon pointInFigure(CustomPoint a) //положение точки в многоугольнике
		{
			bool parity = true;
			for (int i = 0; i < points.Count; i++)
			{
				CustomPoint v = points[i];
				CustomPoint w = points[(i + 1) % points.Count];

				switch (edgeType(a, v, w))
				{
					case EdgeType.TOUCHING:
						return PointInPolygon.BOUNDARY;
					case EdgeType.CROSSING:
						parity = !parity;
						break;
				}
			}

			return parity ? PointInPolygon.OUTSIDE : PointInPolygon.INSIDE;
		}
	}
}

