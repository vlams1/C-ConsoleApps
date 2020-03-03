using System;

namespace Dice_Program {
	class Program {
		static void Main(string[] args) {
			Random rnd = new Random();
			int n;
			while (Console.ReadLine() != "exit") {
				n = rnd.Next(1, 7);
				Console.Clear();
				Console.WriteLine("\n{2}  {4}  {1}\n{3}  {0}  {3}\n{1}  {4}  {2}\n",
					n % 2 == 1 ? "O" : " ",
					n > 1 ? "O" : " ",
					n > 3 ? "O" : " ",
					n > 5 ? "O" : " ",
					n > 7 ? "O" : " ");
			}
		}
	}
}