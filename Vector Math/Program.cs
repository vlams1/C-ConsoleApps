using System;
using System.Numerics;

namespace Vector_Math {
	class Program {
		static void Main(string[] args) {
			Vector2 a = new Vector2(1f, 5f);
			Vector3 b = a.yxy();
			Console.WriteLine(b);
		}
	}
}