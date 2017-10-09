﻿using System;

namespace CG4
{
	public class CustomPoint
	{
		public double x;
		public double y;
		public CustomPoint ()
		{
		}
		public CustomPoint (double _x, double _y)
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
		public void Print(){
			Console.Write("(");
			Console.Write (x);
			Console.Write (", ");
			Console.Write (y);
			Console.WriteLine (")");
		}
		//Параллельное смещение
		public static CustomPoint Smestchenie(CustomPoint point, int x, int y){
			return point.ToMatrix ().Mult (Matrix.Smestchenie (x, y)).ToPoint ();
		}
		//Поворот вокруг оси координат
		public static CustomPoint Povorot(CustomPoint p, double x){
			return p.ToMatrix().Mult(Matrix.Povorot(x)).ToPoint();
		}
		//Масштабирование
		public static CustomPoint Size(CustomPoint p, double size){
			return p.ToMatrix().Mult(Matrix.Size(size)).ToPoint();
		}
	}
}

