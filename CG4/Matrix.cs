using System;

namespace CG4
{
	public class Matrix
	{
		private int [][] _matr;
		private int _m;
		private int _n;
		public Matrix (int n, int m)
		{
			if (n < 0 || m <0)
				throw new Exception ("size>0");
			_m = m;
			_n = n;
			_matr = new int[_m][];
			for (int i = 0; i < _m; i++)
				_matr [i] = new int[_n];
		}

		public void Print(){
			for (int i = 0; i < _m; i++) {
				for (int j = 0; j < _n; j++) {
					Console.Write (_matr [i][j]);
					Console.Write (" ");
				}
				Console.WriteLine ();

			}
				
		}

		public void Set(int x, int i, int j){
			if (i > _m || j > _n || i < 0 || j < 0)
				throw new Exception ();
			_matr [i] [j] = x;
		}

		public Matrix Mult(Matrix m2){
			Matrix res = new Matrix(m2._n, _m);

			for (int i = 0; i < _m; i++) {
				for (int j = 0; j < m2._n; j++) {
					for (int k = 0; k < m2._m; k++) {
						res._matr [i] [j] += _matr [i] [k] * m2._matr [k] [j];
					}
				}
			}

			res.Print ();
			return res;
		}
	}
}

