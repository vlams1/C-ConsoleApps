using System;

namespace Dice_Program {
	class Program {
		static void Main(string[] args) {
			Random rnd = new Random();
			int n;
			while (true) {
				n = rnd.Next(1, 7);
				
				string a = n % 2 > 0 ? "O" : " ";
				string b = n > 1 ? "O" : " ";
				string c = n > 3 ? "O" : " ";
				string d = n > 5 ? "O" : " ";
				string e = n > 7 ? "O" : " ";
				
				Console.Clear();
				Console.WriteLine("\n{2}  {4}  {1}\n{3}  {0}  {3}\n{1}  {4}  {2}\n",a,b,c,d,e);
				if (Console.ReadLine() == "exit") return;
			}

		}
	}
}