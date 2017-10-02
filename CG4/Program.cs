using System;

namespace CG4
{
	class MainClass
	{
		public static void Main (string[] args)
		{
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
		}
	}
}
