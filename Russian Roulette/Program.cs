using System;
using System.Linq;

namespace Russian_Roulette {
	class Program {
		static Random rnd = new Random();
		static void Main(string[] args) {
			int input; //Initialize input integer
			
			//SETUP
			
			do { //Amount of players, at least 1
				Console.Clear();
				Console.WriteLine("People:     (must be atleast 1)");
				int.TryParse(Console.ReadLine(), out input); //Check input
			} while (input <= 0); //Repeat if less than 1
			
			string[] names = new string[input]; //Array of names
			
			Console.Clear();
			Console.WriteLine("Names:     (for " + names.Length + " people)");
			
			for (int i = 0; i < names.Length; i++) { //Input names
				names[i] = Console.ReadLine();
			}

			do { //Amount of chambers, at least 1
				Console.Clear();
				Console.WriteLine("Chambers:     (must be atleast 1)");
				int.TryParse(Console.ReadLine(), out input); //Check input
			} while (input <= 0); //Repeat if less than 1

			bool[] chambers = new bool[input];
			
			do { //Amount of bullets, at least one, not more than amount of chambers
				Console.Clear();
				Console.WriteLine("Bullets:     (must be atleast 1, can't be more than " + chambers.Length + ")");
				int.TryParse(Console.ReadLine(), out input);
			} while (input <= 0 || input > chambers.Length); //Repeat if less than 1 or more than chamber count

			for (int i = 0; i < input; i++) { //Fill random chambers
				bool repeat = true;
				do {
					int random = rnd.Next(0, chambers.Length); //Choose random chamber
					if (chambers[random] == false) { //Random chamber empty?
						chambers[random] = true; //Load
						repeat = false; //Don't repeat
					}
				} while (repeat); //Repeat if nothing was loaded
			}

			int chamber = 0; //Curent chamber
			int person = rnd.Next(0,names.Length); //Current player (randomized from start)
			string[] dead = new string[input]; //List of dead players
			int deathcount = 0; //Amount of deaths
			
			Console.Clear();
			
			//GAME
			
			do { //Game loop
				while (dead.Contains(names[person])) person = person + 1 % names.Length; //Make sure current player isn't dead
				Console.WriteLine("It's " + names[person] + "'s turn!");
				Console.WriteLine("Spin or trigger?");
				string command = Console.ReadLine(); //Player input
				if (command.ToLower() == "spin") { //randomize current chamber if player types "spin"
					chamber = rnd.Next(0, chambers.Length);
				}

				if (command.ToLower() == "spin" || command.ToLower() == "trigger") { //shoot if player types "spin" or "trigger"
					if (chambers[chamber]) { //If current chamber is loaded
						dead[deathcount] = names[person]; //Kill player
						deathcount++; //Keep track of death
						Console.WriteLine(names[person] + " died..");
						chambers[chamber] = false; //Unload chamber
						input--; //Subtract from amount of bullets in gun
					} else Console.WriteLine(names[person] + " survived!"); //Player survived
					Console.WriteLine();
					
					person++; //Next person, loop around after last
					if (person >= names.Length) person = 0;
					chamber++; //Next chamber, loop around after last
					if (chamber >= chambers.Length) chamber = 0;
				}

				if (deathcount >= names.Length) break; //End game if all players are dead
			} while (input > 0); //Repeat if gun has bullets
			
			Console.Clear();
			
			//GAME OVER
			
			if (deathcount == names.Length) { //Massacre
				Console.WriteLine("Everyone died...");
				if (input == 0) Console.WriteLine("There were exactly as many bullets as there were players..."); //No bullets left
				else if (input == 1) Console.WriteLine("There is one bullet left in the gun."); //One bullet left
				else Console.WriteLine("There are " + input + " bullets left in the gun."); //Amount of left over bullets
			}
			else { //People survived
				foreach (string name in names) { //Write down all names and their current state of being.
					if (dead.Contains(name)) Console.WriteLine(name + " passed away.."); //Current player died
					else Console.WriteLine(name + " survived."); //Current player survived
				}
				if (deathcount == 0) Console.WriteLine("Noone died today!"); //Noone died
				else if (deathcount == 1) Console.WriteLine("One person died today.."); //One person died
				else Console.WriteLine(deathcount + " people died today..."); //Amount of dead people
			}
		}
	}
}