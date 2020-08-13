using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Midterm
{
	class Program
	{
		static void Main(string[] args)
		{
			//Customzies starting console settings.
			Console.SetWindowSize(275, 75);
			Console.Title = "Dev.Build(4.0) Movie Listing Mania!";
			//Declare MovieCatalog object and fill it with a starting list of movies.
			MovieCatalog catalog = new MovieCatalog();
			GenerateDefaultMovieList(catalog);
			//Loops through until the user quits the program.
			bool runProgram = true;
			do
			{
				Console.WriteLine("Welcome to the Dev.Build(4.0) Movie Listing Mania!\n");
				ShowMovies(catalog);
				int userChoice = ShowMenu(catalog);
				Console.Clear();
				Console.WriteLine();
				switch (userChoice)
				{
					//Sort movies.
					case 1:
						SortMovies(catalog);
						break;
					//Search movies.
					case 2:
						SearchMovies(catalog);
						break;
					//Admin (add/edit/remove).
					case 3:
						Admin(catalog);
						break;
					//Quit the program.
					case 4:
						runProgram = false;
						break;
				}
				Console.Clear();
			} while (runProgram);
			Console.WriteLine("Thanks for going though the Movie Listing Mania!");
		}

		//Displays formatted output of all the movies in the list.
		public static void ShowMovies(MovieCatalog catalog)
		{
			Console.WriteLine($"{"",-4}{"Title",-40}|{"Genre",-12}|{"Director",-20}|{"Runtime",-8}|{"Year",-6}|{"Cast",-66}|{"Description"}");
			Console.WriteLine($"{new string('*', 44)}|{new string('*', 12)}|{new string('*', 20)}|{new string('*', 8)}|{new string('*', 6)}|{new string('*', 66)}|{new string('*', 40)}");
			for (int index = 1; index <= catalog.MovieCount(); index++)
			{
				if (index % 2 == 0)
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine($"{$"{index}.",-4}{catalog.GetMovie(index)}");
					Console.ResetColor();
				}
				else
				{
					Console.WriteLine($"{$"{index}.",-4}{catalog.GetMovie(index)}");
				}
			}
			Console.WriteLine($"{new string('*', 202)}\n\n");
		}

		//Shows the menu of the options available to the user and gets their validated input.
		public static int ShowMenu(MovieCatalog catalog)
		{
			Console.WriteLine("Pick an option:");
			Console.WriteLine($"{new string('-', 28)}");
			Console.WriteLine($"{$"1.",-4}{"Sort Movies"}");
			Console.WriteLine($"{$"2.",-4}{"Search Movies"}");
			Console.WriteLine($"{$"3.",-4}{"Admin (add/edit/remove)"}");
			Console.WriteLine($"{$"4.",-4}{"Quit"}");
			Console.WriteLine($"{new string('-', 28)}");
			Console.Write($"{"=>",-4}");
			bool isValid = int.TryParse(Console.ReadLine(), out int option);
			while (!isValid || !(option >= 1 && option <= 4))
			{
				Console.SetCursorPosition(0, catalog.MovieCount() + 6);
				Console.WriteLine("That is not a valid option.");
				Console.SetCursorPosition(0, catalog.MovieCount() + 14);
				Console.Write(new string(' ', Console.WindowWidth));
				Console.SetCursorPosition(0, catalog.MovieCount() + 14);
				Console.Write($"{"=>",-4}");
				isValid = int.TryParse(Console.ReadLine(), out option);
			}
			return option;
		}

		//Generates a list of movies and returns the list.
		public static void GenerateDefaultMovieList(MovieCatalog catalog)
		{
			catalog.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			catalog.AddMovie(new Movie("The Matrix", MovieGenre.SciFi, "Wachowski Brothers", 1999, 136, new List<string> { "Keanu Reeves", "Laurence Fishburne", "Carrie-Anne Moss" }, "We're all living in a computer simulation."));
			catalog.AddMovie(new Movie("Die Hard", MovieGenre.Action, "John McTiernan", 1988, 132, new List<string> { "Bruce Willis" }, "Terrorists are going to get you at the office Christmas party."));
			catalog.AddMovie(new Movie("Evil Dead", MovieGenre.Horror, "Sam Raimi", 1981, 85, new List<string>() { "Bruce Campbell" }, "Deadites are going to get you at the cabin."));
			catalog.AddMovie(new Movie("Back to the Future", MovieGenre.Comedy, "Robert Zemeckis", 1985, 116, new List<string> { "Michael J. Fox", "Christopher Lloyd" }, "Go to the past to fix your parents."));
			catalog.AddMovie(new Movie("Bad Boys", MovieGenre.Action, "Michael Bay", 1995, 118, new List<string> { "Will Smith", "Martin Lawrence" }, "Two hip detectives protect a witness to a murder."));
			catalog.AddMovie(new Movie("Bad Santa", MovieGenre.Comedy, "Terry Zwigoff", 2003, 99, new List<string> { "Billy Bob Thornton", "Tony Cox" }, "The best Santa ever!"));
			catalog.AddMovie(new Movie("Bill & Ted's Excellent Adventure", MovieGenre.Comedy, "Stephen Herek", 1989, 89, new List<string> { "Keanu Reeves", "Alex Winter", "George Carlin" }, "Going to the past to pass a test."));
			catalog.AddMovie(new Movie("Blade Runner", MovieGenre.SciFi, "Ridley Scott", 1982, 117, new List<string> { "Harrison Ford", "Rutger Hauer" }, "Harrison Ford battles androids."));
			catalog.AddMovie(new Movie("The Blues Brothers", MovieGenre.Comedy, "John Landis", 1980, 157, new List<string> { "John Belushi", "Dan Aykroyd" }, "They're on a mission from god."));
			catalog.AddMovie(new Movie("Caddyshack", MovieGenre.Comedy, "Harold Ramis", 1980, 98, new List<string> { "Rodney Dangerfield", "Ted Knight", "Michael O'Keefe" }, "Hitting balls all over the place."));
			catalog.AddMovie(new Movie("A Christmas Story", MovieGenre.Comedy, "Bob Clark", 1983, 93, new List<string> { "Peter Billingsley", "Darren McGavin", "Melinda Dillon" }, "The best Christmas movie ever."));
			catalog.AddMovie(new Movie("Dawn of the Dead", MovieGenre.Horror, "George A. Romero", 1978, 127, new List<string> { "Ken Foree", "Scott H.Reiniger", "Gaylen Ross" }, "Zombies are going to get you at the mall."));
			catalog.AddMovie(new Movie("Day of the Dead", MovieGenre.Horror, "George A. Romero", 1985, 96, new List<string> { "Lori Cardille", "Terry Alexander", "Joseph Pilato" }, "Zombies are going to get you at the underground bunker."));
			catalog.AddMovie(new Movie("Night of the Living Dead", MovieGenre.Horror, "George A. Romero", 1968, 88, new List<string> { "Duane Jones", "Judith O'Dea", "Karl Hardman" }, "Zombies are going to get you at night."));
			catalog.AddMovie(new Movie("Dawn of the Dead", MovieGenre.Horror, "Zack Snyder", 2004, 101, new List<string> { "Sarah Polley", "Ving Rhames", "Jake Weber", "Michael Kelly" }, "A good reboot of zombies are going to get you at the mall."));
			catalog.AddMovie(new Movie("Night of the Living Dead", MovieGenre.Horror, "Tom Savini", 1990, 92, new List<string> { "Tony Todd", "Patricia Tallman", "Tom Towles" }, "A good reboot of zombies are going to get you at night."));
			catalog.AddMovie(new Movie("Dirty Harry", MovieGenre.Thriller, "Don Siegel", 1971, 102, new List<string> { "Clint Eastwood" }, "Go ahead. Make my day."));
			catalog.AddMovie(new Movie("The Fifth Element", MovieGenre.SciFi, "Luc Besson", 1997, 125, new List<string> { "Bruce Willis", "Milla Jovovich", "Gary Oldman", "Chris Tucker" }, "Bruce Willis in space saving the world with a loud Chris Tucker."));
			catalog.AddMovie(new Movie("Fury", MovieGenre.Action, "David Ayer", 2014, 134, new List<string> { "Brad Pitt", "Shia LaBeouf", "Logan Lerman" }, "Brad Pitt in a tank."));
			catalog.AddMovie(new Movie("Antitrust", MovieGenre.Thriller, "Peter Howitt", 2001, 108, new List<string> { "Ryan Phillippe", "Tim Robbins", "Rachael Leigh Cook" }, "A computer programmer confronts his muderous boss."));
			catalog.AddMovie(new Movie("Gladiator", MovieGenre.Drama, "Ridley Scott", 2000, 155, new List<string> { "Russell Crowe", "Joaquin Phoenix" }, "Slicing and dicing everyone into tiny bits until he kills the Emporer."));
			catalog.AddMovie(new Movie("Hidden Figures", MovieGenre.Drama, "Theodore Melfi", 2016, 127, new List<string> { "Taraji P.Henson", "Octavia Spencer", "Janelle Monáe", "Kevin Costner" }, "A team of women in a vital role during the early years of NASA."));
			catalog.AddMovie(new Movie("Harold and Kumar Go to White Castle", MovieGenre.Comedy, "Danny Leiner", 2004, 88, new List<string> { "John Cho", "Kal Penn" }, "Mmmm White Castle."));
			catalog.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			catalog.AddMovie(new Movie("Indiana Jones and the Last Crusade", MovieGenre.Action, "Steven Spielberg", 1989, 126, new List<string> { "Harrison Ford", "Sean Connery" }, "Harisson Ford + Sean Connery = goodness."));
			catalog.AddMovie(new Movie("John Wick", MovieGenre.Action, "Chad Stahelski", 2014, 101, new List<string> { "Keanu Reeves" }, "They made the mistake of killing his dog."));
			catalog.AddMovie(new Movie("Joker", MovieGenre.Drama, "Todd Phillips", 2019, 121, new List<string> { "Joaquin Phoenix", "Robert De Niro" }, "Can you introduce me as Joker?"));
			catalog.AddMovie(new Movie("Hackers", MovieGenre.Drama, "Iain Softley", 1995, 105, new List<string> { "Jonny Lee Miller", "Angelina Jolie", "Matthew Lillard" }, "Totally how computers work."));
			catalog.AddMovie(new Movie("Jurassic Park", MovieGenre.Action, "Steven Spielberg", 1993, 126, new List<string> { "Sam Neill", "Laura Dern", "Jeff Goldblum" }, "Lets put dinosaurs in an amusement park!"));
			catalog.AddMovie(new Movie("The Martian", MovieGenre.SciFi, "Ridley Scott", 2015, 142, new List<string> { "Matt Damon" }, "Lets go rescue Matt Damon again; this time in space!"));
			catalog.AddMovie(new Movie("Napoleon Dynamite", MovieGenre.Comedy, "Jared Hess", 2004, 94, new List<string> { "Jon Heder", "Aaron Ruell", "Jon Gries", "Tina Majorino" }, "Knock it off, Napoleon! Make yourself a dang quesadilla!."));
			catalog.AddMovie(new Movie("Office Space", MovieGenre.Comedy, "Mike Judge", 1999, 89, new List<string> { "Ron Livingston", "David Herman", "Ajay Naidu" }, "PC Load Letter? What the fuck does that mean?"));
			catalog.AddMovie(new Movie("Outland", MovieGenre.SciFi, "Peter Hyams", 1981, 109, new List<string> { "Sean Connery" }, "A marshal at a mining colony on the Jupiter moon of Io, uncovers a drug-smuggling conspiracy."));
			catalog.AddMovie(new Movie("Predator", MovieGenre.SciFi, "John McTiernan", 1987, 106, new List<string> { "Arnold Schwarzenegger", "Carl Weathers", "Bill Duke" }, "A team of commandos in a jungle find themselves hunted by an alien."));
			catalog.AddMovie(new Movie("Robocop", MovieGenre.Action, "Paul Verhoeven", 1987, 103, new List<string> { "Peter Weller", "Nancy Allen", "Kurtwood Smith" }, "In a dystopian and crime-ridden Detroit, a robot cop rises."));
			catalog.AddMovie(new Movie("Scream", MovieGenre.Horror, "Wes Craven", 1996, 110, new List<string> { "Neve Campbell", "Courteney Cox", "David Arquette", "Matthew Lillard" }, "Killer on the loose slashing everyone up."));
			catalog.AddMovie(new Movie("The Net", MovieGenre.Drama, "Irwin Winkler", 1995, 114, new List<string> { "Sandra Bullock", "Jeremy Northam", "Wendy Gazelle" }, "A computer programmer stumbles upon a conspiracy, putting her life in great danger."));
			catalog.AddMovie(new Movie("Gran Torino", MovieGenre.Drama, "Clint Eastwood", 2009, 116, new List<string> { "Clint Eastwood", "Bee Vang", "Ahney Her" }, "A grumpy old man sits on his porch stirring up trouble."));
			catalog.AddMovie(new Movie("Contagion", MovieGenre.Thriller, "Steven Soderbergh", 2011, 106, new List<string> { "Laurence Fishburne", "Matt Damon", "Jude Law" }, "The world finds itself in the midst of a pandemic as the CDC works to find a cure."));
			catalog.AddMovie(new Movie("Outbreak", MovieGenre.Drama, "Wolfgang Petersen", 1995, 122, new List<string> { "Dustin Hoffman", "Rene Russo", "Cuba Gooding Jr." }, "Army doctors struggle to find a cure for a deadly virus spreading throughout a California town."));
			catalog.AddMovie(new Movie("Commando", MovieGenre.Action, "Mark L. Lester", 1985, 90, new List<string> { "Arnold Schwarzenegger", "Vernon Wells", "Bill Duke" }, "A movie where the dialogue consists of nothing but great one-liners."));
			catalog.AddMovie(new Movie("Terminator", MovieGenre.Action, "James Cameron", 1984, 107, new List<string> { "Arnold Schwarzenegger", "Linda Hamilton", "Michael Biehn" }, "A machine from the future travels to the past to kill a woman."));
			catalog.AddMovie(new Movie("Stargate", MovieGenre.SciFi, "Roland Emmerich", 1994, 121, new List<string> { "Kurt Russell", "James Spader" }, "We found an ancient ring buried in Egypt and now it take us to other planets."));
			catalog.AddMovie(new Movie("Starship Troopers", MovieGenre.SciFi, "Paul Verhoeven", 1997, 129, new List<string> { "Casper Van Dien", "Denise Richards", "Jake Busey" }, "Lets fight an interstellar war against bugs!"));
			catalog.AddMovie(new Movie("Slither", MovieGenre.Horror, "James Gunn", 2006, 95, new List<string> { "Nathan Fillion", "Elizabeth Banks", "Tania Saulnier" }, "Watch out for those space slugs!"));
			catalog.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			catalog.AddMovie(new Movie("Serenity", MovieGenre.SciFi, "Joss Whedon", 2005, 118, new List<string> { "Nathan Fillion", "Summer Glau", "Adam Baldwin" }, "I aim to misbehave."));
			catalog.AddMovie(new Movie("Shaun of the Dead", MovieGenre.Comedy, "Edgar Wright", 2004, 99, new List<string> { "Simon Pegg", "Nick Frost" }, "Zombies are going to get you in London."));
			catalog.AddMovie(new Movie("The Watch", MovieGenre.Comedy, "Akiva Schaffer", 2012, 102, new List<string> { "Ben Stiller", "Vince Vaughn", "Jonah Hill", "Richard Ayoade" }, "Keeping the neighborhood safe, from aliens."));
		}

		//Sorts the movies in the list by the validated criteria specified by the user.
		public static void SortMovies(MovieCatalog catalog)
		{
			//Displays options for sorting.
			Console.WriteLine("How would you like to sort the movies?");
			Console.WriteLine($"{new string('-', 16)}");
			Console.WriteLine($"{$"1.",-4}{"Title"}");
			Console.WriteLine($"{$"2.",-4}{"Genre"}");
			Console.WriteLine($"{$"3.",-4}{"Director"}");
			Console.WriteLine($"{$"4.",-4}{"Runtime"}");
			Console.WriteLine($"{$"5.",-4}{"Year"}");
			Console.WriteLine($"{$"6.",-4}{"Back"}");
			Console.WriteLine($"{new string('-', 16)}");
			Console.Write($"{"=>",-4}");
			//Gets user input and validates that it is a number within range.
			bool isValid = int.TryParse(Console.ReadLine(), out int option);
			while (!isValid || !(option >= 1 && option <= 6))
			{
				Console.SetCursorPosition(0, 0);
				Console.WriteLine("That is not a valid option.");
				Console.SetCursorPosition(0, 10);
				Console.Write(new string(' ', Console.WindowWidth));
				Console.SetCursorPosition(0, 10);
				Console.Write($"{"=>",-4}");
				isValid = int.TryParse(Console.ReadLine(), out option);
			}
			//Based on the option picked the object sort method is called with the appropriate argument.
			switch (option)
			{
				case 1:
					catalog.SortMovies("title");
					break;
				case 2:
					catalog.SortMovies("genre");
					break;
				case 3:
					catalog.SortMovies("director");
					break;
				case 4:
					catalog.SortMovies("runtime");
					break;
				case 5:
					catalog.SortMovies("year");
					break;
				case 6:
					break;
			}
		}

		//Seraches and displays the movies found, if any, based on the validated user input for the search criteria.
		public static void SearchMovies(MovieCatalog catalog)
		{
			//Using Regex to verify the user is choosing a valid field to search.
			Regex fieldMatch = new Regex(@"^(title)$|^(genre)$|^(director)$|^(runtime)$|^(year)$|^(cast)$");
			string allFields = "Title/Genre/Director/Runtime/Year/Cast";
			Console.WriteLine($"What would you like to search ({allFields})?");
			Console.Write($"{"=>",-4}");
			string searchField = Console.ReadLine().ToLower();
			while (!fieldMatch.IsMatch(searchField))
			{
				Console.SetCursorPosition(0, 0);
				Console.WriteLine("That is not a valid option.");
				Console.SetCursorPosition(0, 2);
				Console.Write(new string(' ', Console.WindowWidth));
				Console.SetCursorPosition(0, 2);
				Console.Write($"{"=>",-4}");
				searchField = Console.ReadLine().ToLower();
			}
			Console.SetCursorPosition(0, 0);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.Write(new string(' ', Console.WindowWidth));
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, 0);
			//Based on the field the user picks, appropriate followup question is asked to get the validated search criteria from the user.
			string searchCriteria;
			switch (searchField)
			{
				//Search titles.  Search criteria cannot be blank.  User can enter a full title, partial title, or a letter to get any movie that contains that entry.
				case "title":
					Console.WriteLine("\nEnter the title you would like to search for.");
					Console.Write($"{"=>",-4}");
					searchCriteria = Console.ReadLine();
					while (string.IsNullOrEmpty(searchCriteria))
					{
						Console.SetCursorPosition(0, 0);
						Console.Write("Title search criteria cannot be blank.");
						Console.SetCursorPosition(0, 2);
						Console.Write(new string(' ', Console.WindowWidth));
						Console.SetCursorPosition(0, 2);
						Console.Write($"{"=>",-4}");
						searchCriteria = Console.ReadLine();
					}
					break;
				//Search genre. Validates that the user must enter one of the existing genres. 
				case "genre":
					string[] genres = Enum.GetNames(typeof(MovieGenre));
					string allGenres = "";
					for (int i = 0; i < genres.Length - 1; i++)
					{
						allGenres += $"{genres[i]}/";
					}
					allGenres += genres[genres.Length - 1];
					Console.WriteLine($"\nEnter the movie genre you would like to search for ({allGenres}).");
					Console.Write($"{"=>",-4}");
					searchCriteria = Console.ReadLine().ToLower();
					//Verifies the user didn't leave the criteria blank and that the users input matches one of the existing genres.
					while (!genres.Any(x => x.Equals(searchCriteria, StringComparison.OrdinalIgnoreCase)) || string.IsNullOrEmpty(searchCriteria))
					{
						if (string.IsNullOrEmpty(searchCriteria))
						{
							Console.SetCursorPosition(0, 0);
							Console.Write("Genre search criteria cannot be blank.");
							Console.SetCursorPosition(0, 2);
							Console.Write(new string(' ', Console.WindowWidth));
							Console.SetCursorPosition(0, 2);
							Console.Write($"{"=>",-4}");
							searchCriteria = Console.ReadLine().ToLower();
						}
						else
						{
							Console.SetCursorPosition(0, 0);
							Console.Write("That is not a valid genre.");
							Console.SetCursorPosition(0, 2);
							Console.Write(new string(' ', Console.WindowWidth));
							Console.SetCursorPosition(0, 2);
							Console.Write($"{"=>",-4}");
							searchCriteria = Console.ReadLine().ToLower();
						}
					}
					break;
				//Search director.  Search criteria cannot be blank.  User can enter a full name, a partial name, or a letter to get any director that contains that entry.
				case "director":
					Console.WriteLine($"\nEnter the movie director you would like to search for.");
					Console.Write($"{"=>",-4}");
					searchCriteria = Console.ReadLine();
					while (string.IsNullOrEmpty(searchCriteria))
					{
						Console.SetCursorPosition(0, 0);
						Console.Write("Director search criteria cannot be blank.");
						Console.SetCursorPosition(0, 2);
						Console.Write(new string(' ', Console.WindowWidth));
						Console.SetCursorPosition(0, 2);
						Console.Write($"{"=>",-4}");
						searchCriteria = Console.ReadLine();
					}
					break;
				//Search runtime.  Search criteria must be greater than zero.  Finds any movie with that exact runtime.
				case "runtime":
					Console.WriteLine("\nEnter the movie runtime (in minutes) you would like to search for.");
					Console.Write($"{"=>",-4}");
					bool isValid = int.TryParse(Console.ReadLine(), out int runtime);
					while (!isValid || runtime <= 0)
					{
						Console.SetCursorPosition(0, 0);
						Console.Write("That is not a valid runtime.");
						Console.SetCursorPosition(0, 2);
						Console.Write(new string(' ', Console.WindowWidth));
						Console.SetCursorPosition(0, 2);
						Console.Write($"{"=>",-4}");
						isValid = int.TryParse(Console.ReadLine(), out runtime);
					}
					searchCriteria = runtime.ToString();
					break;
				//Search release year.  Search criteria must be the same year or later than the first film and cannot be greater than the current year.  Finds any movie with that exact release year.
				case "year":
					Console.WriteLine("\nEnter the release year you would like to search for.");
					Console.Write($"{"=>",-4}");
					isValid = int.TryParse(Console.ReadLine(), out int year);
					while (!isValid || year < 1895 || year > DateTime.Now.Year)
					{
						if (isValid && year < 1895)
						{
							Console.SetCursorPosition(0, 0);
							Console.Write("The release year must be after the first film in 1895.");
							Console.SetCursorPosition(0, 2);
							Console.Write(new string(' ', Console.WindowWidth));
							Console.SetCursorPosition(0, 2);
							Console.Write($"{"=>",-4}");
							isValid = int.TryParse(Console.ReadLine(), out year);
						}
						else if (isValid && year > DateTime.Now.Year)
						{
							Console.SetCursorPosition(0, 0);
							Console.Write("The release year cannot be in the future.");
							Console.SetCursorPosition(0, 2);
							Console.Write(new string(' ', Console.WindowWidth));
							Console.SetCursorPosition(0, 2);
							Console.Write($"{"=>",-4}");
							isValid = int.TryParse(Console.ReadLine(), out year);
						}
						else
						{
							Console.SetCursorPosition(0, 0);
							Console.Write("That is not a valid year.");
							Console.SetCursorPosition(0, 2);
							Console.Write(new string(' ', Console.WindowWidth));
							Console.SetCursorPosition(0, 2);
							Console.Write($"{"=>",-4}");
							isValid = int.TryParse(Console.ReadLine(), out year);
						}
						Console.SetCursorPosition(0, 0);
						Console.Write(new string(' ', Console.WindowWidth));
						Console.SetCursorPosition(0, 0);
					}
					searchCriteria = year.ToString();
					break;
				//Search cast.  Search criteria cannot be blank.  User can enter a full name, a partial name, or a letter to get any cast member that contains that entry.
				case "cast":
					Console.WriteLine($"\nEnter the movie cast member you would like to search for.");
					Console.Write($"{"=>",-4}");
					searchCriteria = Console.ReadLine();
					while (string.IsNullOrEmpty(searchCriteria))
					{
						Console.SetCursorPosition(0, 0);
						Console.Write("Cast member search criteria cannot be blank.");
						Console.SetCursorPosition(0, 2);
						Console.Write(new string(' ', Console.WindowWidth));
						Console.SetCursorPosition(0, 2);
						Console.Write($"{"=>",-4}");
						searchCriteria = Console.ReadLine();
					}
					break;
				default:
					searchCriteria = "";
					break;
			}
			Console.SetCursorPosition(0, 0);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.Write(new string(' ', Console.WindowWidth));
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, 0);
			//Calls search method with the validated field and criteria and retuns a list of the matched movies.
			List<Movie> searchResult = catalog.SearchMovies(searchField, searchCriteria);
			//Checks if the list contains any results and prints out the movies.
			if (searchResult.Count != 0)
			{
				Console.WriteLine($"{"",-4}{"Title",-40}|{"Genre",-12}|{"Director",-20}|{"Runtime",-8}|{"Year",-6}|{"Cast",-66}|{"Description"}");
				Console.WriteLine($"{new string('*', 44)}|{new string('*', 12)}|{new string('*', 20)}|{new string('*', 8)}|{new string('*', 6)}|{new string('*', 66)}|{new string('*', 40)}");
				for (int index = 1; index <= searchResult.Count; index++)
				{
					if (index % 2 == 0)
					{
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine($"{$"{index}.",-4}{searchResult[index - 1]}");
						Console.ResetColor();
					}
					else
					{
						Console.WriteLine($"{$"{index}.",-4}{searchResult[index - 1]}");
					}
				}
				Console.WriteLine($"{new string('*', 202)}");
			}
			//Search did not return any matching results.
			else
			{
				Console.WriteLine("Your search did not return any results.");
			}
			Console.Write("\nPress any key to continue.");
			Console.ReadKey();
		}

		//Shows admin menu options and gets validated user input for admin choice.
		public static void Admin(MovieCatalog catalog)
		{
			Console.WriteLine("What would you like to do?");
			Console.WriteLine($"{new string('-', 16)}");
			Console.WriteLine($"{$"1.",-4}{"Add Movie"}");
			Console.WriteLine($"{$"2.",-4}{"Edit Movie"}");
			Console.WriteLine($"{$"3.",-4}{"Remove Movie"}");
			Console.WriteLine($"{$"4.",-4}{"Back"}");
			Console.WriteLine($"{new string('-', 16)}");
			Console.Write($"{"=>",-4}");
			//Validates input is an integer within range.
			bool isValid = int.TryParse(Console.ReadLine(), out int option);
			while (!isValid || !(option >= 1 && option <= 4))
			{
				Console.SetCursorPosition(0, 0);
				Console.WriteLine("That is not a valid option.");
				Console.SetCursorPosition(0, 8);
				Console.Write(new string(' ', Console.WindowWidth));
				Console.SetCursorPosition(0, 8);
				Console.Write($"{"=>",-4}");
				isValid = int.TryParse(Console.ReadLine(), out option);
			}
			Console.Clear();
			//Calls the appropriate admin method based on user input.
			switch (option)
			{
				case 1:
					AdminAddMovie(catalog);
					break;
				case 2:
					AdminEditMovie(catalog);
					break;
				case 3:
					AdminRemoveMovie(catalog);
					break;
				case 4:
					break;
			}
		}

		//Gets validated user input to add a movie to the list.
		public static void AdminAddMovie(MovieCatalog catalog)
		{
			//Regex pattern used for validating cast entry.
			Regex castValidation = new Regex(@"^(([A-Za-z]+(\s[A-Za-z]+)?,\s){0,2}[A-Za-z]+(\s[A-Za-z]+)?)$");
			//Creating a string of all the MovieGenre enums to display as options when picking a genre.
			string[] genres = Enum.GetNames(typeof(MovieGenre));
			string allGenres = "";
			for (int index = 0; index < genres.Length - 1; index++)
			{
				allGenres += $"{genres[index]}/";
			}
			allGenres += genres[genres.Length - 1];
			//Gets a movie title.  Validates that it is not left empty.
			Console.WriteLine("\nEnter the movie title.");
			Console.Write($"{"=>",-4}");
			string title = Console.ReadLine();
			while (string.IsNullOrEmpty(title))
			{
				Console.SetCursorPosition(0, 0);
				Console.Write("Title cannot be blank.");
				Console.SetCursorPosition(0, 2);
				Console.Write(new string(' ', Console.WindowWidth));
				Console.SetCursorPosition(0, 2);
				Console.Write($"{"=>",-4}");
				title = Console.ReadLine();
			}
			Console.SetCursorPosition(0, 0);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, 3);
			//Gets a movie genre.  Verifies that it is not left empty and that it is a valid genre.
			Console.WriteLine($"\nEnter the movie genre ({allGenres}).");
			Console.Write($"{"=>",-4}");
			string genre = Console.ReadLine().ToLower();
			while (!allGenres.ToLower().Contains(genre) || string.IsNullOrEmpty(genre))
			{
				Console.SetCursorPosition(0, 3);
				Console.Write("That is not a valid genre.");
				Console.SetCursorPosition(0, 5);
				Console.Write(new string(' ', Console.WindowWidth));
				Console.SetCursorPosition(0, 5);
				Console.Write($"{"=>",-4}");
				genre = Console.ReadLine().ToLower();
			}
			Console.SetCursorPosition(0, 3);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, 6);
			//Gets a movie director.  Verifies that it is not left empty.
			Console.WriteLine($"\nEnter the movie director.");
			Console.Write($"{"=>",-4}");
			string director = Console.ReadLine();
			while (string.IsNullOrEmpty(director))
			{
				Console.SetCursorPosition(0, 6);
				Console.Write("Director cannot be blank.");
				Console.SetCursorPosition(0, 8);
				Console.Write(new string(' ', Console.WindowWidth));
				Console.SetCursorPosition(0, 8);
				Console.Write($"{"=>",-4}");
				director = Console.ReadLine();
			}
			Console.SetCursorPosition(0, 6);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, 9);
			//Gets a movie release year.  Verifies that the year is not in the future or before the first film was made.
			Console.WriteLine("\nEnter the release year.");
			Console.Write($"{"=>",-4}");
			bool isValid = int.TryParse(Console.ReadLine(), out int year);
			while (!isValid || year < 1895 || year > DateTime.Now.Year)
			{
				if (isValid && year < 1895)
				{
					Console.SetCursorPosition(0, 9);
					Console.Write("The release year must be after the first film in 1895.");
					Console.SetCursorPosition(0, 11);
					Console.Write(new string(' ', Console.WindowWidth));
					Console.SetCursorPosition(0, 11);
					Console.Write($"{"=>",-4}");
					isValid = int.TryParse(Console.ReadLine(), out year);
				}
				else if (isValid && year > DateTime.Now.Year)
				{
					Console.SetCursorPosition(0, 9);
					Console.Write("The release year cannot be in the future.");
					Console.SetCursorPosition(0, 11);
					Console.Write(new string(' ', Console.WindowWidth));
					Console.SetCursorPosition(0, 11);
					Console.Write($"{"=>",-4}");
					isValid = int.TryParse(Console.ReadLine(), out year);
				}
				else
				{
					Console.SetCursorPosition(0, 9);
					Console.Write("That is not a valid year.");
					Console.SetCursorPosition(0, 11);
					Console.Write(new string(' ', Console.WindowWidth));
					Console.SetCursorPosition(0, 11);
					Console.Write($"{"=>",-4}");
					isValid = int.TryParse(Console.ReadLine(), out year);
				}
				Console.SetCursorPosition(0, 9);
				Console.Write(new string(' ', Console.WindowWidth));
			}
			Console.SetCursorPosition(0, 12);
			//Gets the movie runtime.  Verifies the value is greater than zero.
			Console.WriteLine("\nEnter the movie runtime (in minutes).");
			Console.Write($"{"=>",-4}");
			isValid = int.TryParse(Console.ReadLine(), out int runtime);
			while (!isValid || runtime <= 0)
			{
				Console.SetCursorPosition(0, 12);
				Console.Write("That is not a valid runtime.");
				Console.SetCursorPosition(0, 14);
				Console.Write(new string(' ', Console.WindowWidth));
				Console.SetCursorPosition(0, 14);
				Console.Write($"{"=>",-4}");
				isValid = int.TryParse(Console.ReadLine(), out runtime);
			}
			Console.SetCursorPosition(0, 12);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, 15);
			//Gets the movie cast.  Verifies that it is not left empty and entered in the specified format.
			Console.WriteLine("\nEnter up to three cast members (cast1, cast2, cast3).");
			Console.Write($"{"=>",-4}");
			string cast = Console.ReadLine();
			while (!castValidation.IsMatch(cast))
			{
				Console.SetCursorPosition(0, 15);
				Console.Write("That is not a valid option.");
				Console.SetCursorPosition(0, 17);
				Console.Write(new string(' ', Console.WindowWidth));
				Console.SetCursorPosition(0, 17);
				Console.Write($"{"=>",-4}");
				cast = Console.ReadLine();
			}
			List<string> movieCast = cast.Split(", ").ToList();
			Console.SetCursorPosition(0, 15);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, 18);
			//Gets the movie description.  Verifies that it is not left empty.
			Console.WriteLine("\nEnter the movie description.");
			Console.Write($"{"=>",-4}");
			string description = Console.ReadLine();
			while (string.IsNullOrEmpty(description))
			{
				Console.SetCursorPosition(0, 18);
				Console.Write("Description cannot be blank.");
				Console.SetCursorPosition(0, 20);
				Console.Write(new string(' ', Console.WindowWidth));
				Console.SetCursorPosition(0, 20);
				Console.Write($"{"=>",-4}");
				description = Console.ReadLine();
			}
			//Adds a movie to the list using all the user entered information.
			catalog.AddMovie(new Movie(title, (MovieGenre)Enum.Parse(typeof(MovieGenre), genre, true), director, year, runtime, movieCast, description));
		}

		//Gets validated user input to edit a movie.
		public static void AdminEditMovie(MovieCatalog catalog)
		{
			//Displays all the movies available to edit.
			ShowMovies(catalog);
			//Checks that the movies list isn't empty, and if it isn't, gets the users selection.
			if (catalog.MovieCount() != 0)
			{
				//Gets user input for movie they want to edit.  Verifies the number is within the range of available movies.
				Console.Write($"Which movie would you like to edit (1 - {catalog.MovieCount()})? ");
				bool isValid = int.TryParse(Console.ReadLine(), out int index);
				while (!isValid || !(index >= 1 && index <= catalog.MovieCount()))
				{
					Console.SetCursorPosition(0, catalog.MovieCount() + 6);
					Console.WriteLine("That is not a valid option.");
					Console.SetCursorPosition(0, catalog.MovieCount() + 7);
					Console.Write(new string(' ', Console.WindowWidth));
					Console.SetCursorPosition(0, catalog.MovieCount() + 7);
					Console.Write($"Which movie would you like to edit (1 - {catalog.MovieCount()})? ");
					isValid = int.TryParse(Console.ReadLine(), out index);
				}
				Console.Clear();
				//Loops until the user is done editing the movie.
				bool keepEditing = true;
				while (keepEditing)
				{
					//Using Regex to verify the user is choosing a valid field to edit.
					Regex fieldMatch = new Regex(@"^(title)$|^(genre)$|^(director)$|^(runtime)$|^(year)$|^(cast)$|^(description)$");
					//Displays the movie the user selected to edit and it's current values.
					Console.WriteLine($"{"",-4}{"Title",-40}|{"Genre",-12}|{"Director",-20}|{"Runtime",-8}|{"Year",-6}|{"Cast",-66}|{"Description"}");
					Console.WriteLine($"{new string('*', 44)}|{new string('*', 12)}|{new string('*', 20)}|{new string('*', 8)}|{new string('*', 6)}|{new string('*', 66)}|{new string('*', 40)}");
					Console.WriteLine($"{"",-4}{catalog.GetMovie(index)}");
					Console.WriteLine($"{new string('*', 202)}\n\n");
					//Asks user which filed they want to edit and validates they entered a correct field.
					string allFields = "Title/Genre/Director/Runtime/Year/Cast/Description";
					Console.WriteLine($"What would you like to edit ({allFields})?");
					Console.Write($"{"=>",-4}");
					string editField = Console.ReadLine().ToLower();
					while (!fieldMatch.IsMatch(editField))
					{
						Console.SetCursorPosition(0, 5);
						Console.WriteLine("That is not a valid option.");
						Console.SetCursorPosition(0, 7);
						Console.Write(new string(' ', Console.WindowWidth));
						Console.SetCursorPosition(0, 7);
						Console.Write($"{"=>",-4}");
						editField = Console.ReadLine().ToLower();
					}
					Console.SetCursorPosition(0, 5);
					Console.WriteLine(new string(' ', Console.WindowWidth));
					Console.WriteLine(new string(' ', Console.WindowWidth));
					Console.WriteLine(new string(' ', Console.WindowWidth));
					Console.SetCursorPosition(0, 5);
					//Based on the user input prompts user for the appropriate information.
					switch (editField)
					{
						//Edit title.  Validates that the new title isn't blank.
						case "title":
							Console.WriteLine("\nEnter the movie title.");
							Console.Write($"{"=>",-4}");
							string title = Console.ReadLine();
							while (string.IsNullOrEmpty(title))
							{
								Console.SetCursorPosition(0, 5);
								Console.Write("Title cannot be blank.");
								Console.SetCursorPosition(0, 7);
								Console.Write(new string(' ', Console.WindowWidth));
								Console.SetCursorPosition(0, 7);
								Console.Write($"{"=>",-4}");
								title = Console.ReadLine();
							}
							catalog.GetMovie(index).EditMovie(editField, title);
							break;
						//Edit genre.  Validates that the user picks one of the existing genres available.
						case "genre":
							string[] genres = Enum.GetNames(typeof(MovieGenre));
							string allGenres = "";
							for (int i = 0; i < genres.Length - 1; i++)
							{
								allGenres += $"{genres[i]}/";
							}
							allGenres += genres[genres.Length - 1];
							Console.WriteLine($"\nEnter the movie genre ({allGenres}).");
							Console.Write($"{"=>",-4}");
							string genre = Console.ReadLine().ToLower();
							while (!genres.Any(x => x.Equals(genre, StringComparison.OrdinalIgnoreCase)) || string.IsNullOrEmpty(genre))
							{
								Console.SetCursorPosition(0, 5);
								Console.Write("That is not a valid genre.");
								Console.SetCursorPosition(0, 7);
								Console.Write(new string(' ', Console.WindowWidth));
								Console.SetCursorPosition(0, 7);
								Console.Write($"{"=>",-4}");
								genre = Console.ReadLine().ToLower();
							}
							catalog.GetMovie(index).EditMovie(editField, genre);
							break;
						//Edit director.  Validates that the new director isn't blank.
						case "director":
							Console.WriteLine($"\nEnter the movie director.");
							Console.Write($"{"=>",-4}");
							string director = Console.ReadLine();
							while (string.IsNullOrEmpty(director))
							{
								Console.SetCursorPosition(0, 5);
								Console.Write("Director cannot be blank.");
								Console.SetCursorPosition(0, 7);
								Console.Write(new string(' ', Console.WindowWidth));
								Console.SetCursorPosition(0, 7);
								Console.Write($"{"=>",-4}");
								director = Console.ReadLine();
							}
							catalog.GetMovie(index).EditMovie(editField, director);
							break;
						//Edit runtime.  Validates that the new runtime is greater than zero.
						case "runtime":
							Console.WriteLine("\nEnter the movie runtime (in minutes).");
							Console.Write($"{"=>",-4}");
							isValid = int.TryParse(Console.ReadLine(), out int runtime);
							while (!isValid || runtime <= 0)
							{
								Console.SetCursorPosition(0, 5);
								Console.Write("That is not a valid runtime.");
								Console.SetCursorPosition(0, 7);
								Console.Write(new string(' ', Console.WindowWidth));
								Console.SetCursorPosition(0, 7);
								Console.Write($"{"=>",-4}");
								isValid = int.TryParse(Console.ReadLine(), out runtime);
							}
							catalog.GetMovie(index).EditMovie(editField, runtime.ToString());
							break;
						//Edit release year.  Verifies that the year is not in the future or before the first film was made.
						case "year":
							Console.WriteLine("\nEnter the release year.");
							Console.Write($"{"=>",-4}");
							isValid = int.TryParse(Console.ReadLine(), out int year);
							while (!isValid || year < 1895 || year > DateTime.Now.Year)
							{
								if (isValid && year < 1895)
								{
									Console.SetCursorPosition(0, 5);
									Console.Write("The release year must be after the first film in 1895.");
									Console.SetCursorPosition(0, 7);
									Console.Write(new string(' ', Console.WindowWidth));
									Console.SetCursorPosition(0, 7);
									Console.Write($"{"=>",-4}");
									isValid = int.TryParse(Console.ReadLine(), out year);
								}
								else if (isValid && year > DateTime.Now.Year)
								{
									Console.SetCursorPosition(0, 5);
									Console.Write("The release year cannot be in the future.");
									Console.SetCursorPosition(0, 7);
									Console.Write(new string(' ', Console.WindowWidth));
									Console.SetCursorPosition(0, 7);
									Console.Write($"{"=>",-4}");
									isValid = int.TryParse(Console.ReadLine(), out year);
								}
								else
								{
									Console.SetCursorPosition(0, 5);
									Console.Write("That is not a valid year.");
									Console.SetCursorPosition(0, 7);
									Console.Write(new string(' ', Console.WindowWidth));
									Console.SetCursorPosition(0, 7);
									Console.Write($"{"=>",-4}");
									isValid = int.TryParse(Console.ReadLine(), out year);
								}
								Console.SetCursorPosition(0, 5);
								Console.Write(new string(' ', Console.WindowWidth));
								Console.SetCursorPosition(0, 5);
							}
							catalog.GetMovie(index).EditMovie(editField, year.ToString());
							break;
						//Edit cast.  Verifies that at least one to three cast members are entered.
						case "cast":
							//Use regex to make sure cast entry is formatted correctly to be passed to the edit method.
							Regex castValidation = new Regex(@"^(([A-Za-z]+(\s[A-Za-z]+)?,\s){0,2}[A-Za-z]+(\s[A-Za-z]+)?)$");
							Console.WriteLine("\nEnter up to three cast members (cast1, cast2, cast3).");
							Console.Write($"{"=>",-4}");
							string cast = Console.ReadLine();
							while (!castValidation.IsMatch(cast))
							{
								Console.SetCursorPosition(0, 5);
								Console.Write("That is not a valid option.");
								Console.SetCursorPosition(0, 7);
								Console.Write(new string(' ', Console.WindowWidth));
								Console.SetCursorPosition(0, 7);
								Console.Write($"{"=>",-4}");
								cast = Console.ReadLine();
							}
							catalog.GetMovie(index).EditMovie(editField, cast);
							break;
						//Edit description.  Validates that the new description isn't blank.
						case "description":
							Console.WriteLine("\nEnter the movie description.");
							Console.Write($"{"=>",-4}");
							string description = Console.ReadLine();
							while (string.IsNullOrEmpty(description))
							{
								Console.SetCursorPosition(0, 5);
								Console.Write("Description cannot be blank.");
								Console.SetCursorPosition(0, 7);
								Console.Write(new string(' ', Console.WindowWidth));
								Console.SetCursorPosition(0, 7);
								Console.Write($"{"=>",-4}");
								description = Console.ReadLine();
							}
							catalog.GetMovie(index).EditMovie(editField, description);
							break;
					}
					//Asks user if they want to edit continue editing this movie and validates their input.
					Console.WriteLine("\nDo you want to edit another field (y/n)?");
					Console.Write($"{"=>",-4}");
					string yesOrNo = Console.ReadLine().ToLower();
					while (!(yesOrNo == "yes" | yesOrNo == "y" | yesOrNo == "no" | yesOrNo == "n"))
					{
						Console.SetCursorPosition(0, 8);
						Console.Write("Invalid input.");
						Console.SetCursorPosition(0, 10);
						Console.Write(new string(' ', Console.WindowWidth));
						Console.SetCursorPosition(0, 10);
						Console.Write($"{"=>",-4}");
						yesOrNo = Console.ReadLine().ToLower();
					}
					if (yesOrNo == "no" || yesOrNo == "n")
					{
						keepEditing = false;
					}
					Console.Clear();
				}
			}
			//There are no movies in the list to edit.
			else
			{
				Console.WriteLine("Sorry, there are no movies available to edit.");
			}
		}

		//Gets validated input for the movie the user wants to remove.
		public static void AdminRemoveMovie(MovieCatalog catalog)
		{
			//Displays all the movies available to remove.
			ShowMovies(catalog);
			//Checks that the movies list isn't empty, and if it isn't, gets the users selection.
			if (catalog.MovieCount() != 0)
			{
				//Gets user input for movie they want removed.  Verifies the number is within the range of available movies.
				Console.Write($"Which movie would you like to remove (1 - {catalog.MovieCount()})? ");
				bool isValid = int.TryParse(Console.ReadLine(), out int index);
				while (!isValid || !(index >= 1 && index <= catalog.MovieCount()))
				{
					Console.SetCursorPosition(0, catalog.MovieCount() + 6);
					Console.WriteLine("That is not a valid option.");
					Console.SetCursorPosition(0, catalog.MovieCount() + 7);
					Console.Write(new string(' ', Console.WindowWidth));
					Console.SetCursorPosition(0, catalog.MovieCount() + 7);
					Console.Write($"Which movie would you like to remove (1 - {catalog.MovieCount()})? ");
					isValid = int.TryParse(Console.ReadLine(), out index);
				}
				//Removes the selected movie.
				catalog.RemoveMovie(index);
			}
			//There are no movies in the list to remove.
			else
			{
				Console.WriteLine("Sorry, there are no movies available to remove.");
			}
		}
	}
}