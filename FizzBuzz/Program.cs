using System;
using System.Collections.Generic;

namespace FizzBuzz {
	class Program {
		static void Main(string[] args) {
			Dictionary<int, string> words = new Dictionary<int, string>();
			words.Add(3, "Fizz");
			words.Add(5, "Buzz");
			words.Add(7, "Fuzz");
			words.Add(11, "Bizz");
			for (int i = 1; i <= 100; i++) {
				string output = "";
				foreach (var word in words) if (i % word.Key == 0) output += word.Value;
				Console.WriteLine(output != "" ? output : i.ToString());
			}
		}
	}
}