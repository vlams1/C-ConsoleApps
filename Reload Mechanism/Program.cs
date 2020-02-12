using System;

namespace Reload_Mechanism {
	class Program {
		static void Main(string[] args) {
			int ammoClipMax = 5;
			int ammoPocketMax = ammoClipMax * 3;
			int ammoClip = ammoClipMax;
			int ammoPocket= ammoPocketMax;
			
			while (true) {
				switch (Console.ReadLine().ToLower()) {
					case "shoot":
						if (ammoClip > 0) {
							ammoClip--;
							Console.WriteLine("Bang!");
						}
						else Console.WriteLine("Click.");
						break;
					case "reload":
						if (ammoPocket > 0) {
							int amount = Math.Min(ammoClipMax, ammoPocket);
							ammoPocket -= amount;
							ammoClip = ammoClip > 0 ? amount + 1 : amount;
							Console.WriteLine("Reloaded weapon.");
						}
						else Console.WriteLine("Pockets empty.");
						break;
					case "exit":
						return;
				}

				Console.CursorTop--;
				Console.CursorLeft = 20;
				Console.WriteLine("{0}   {1}", ammoClip, ammoPocket);
			}
		}
	}
}