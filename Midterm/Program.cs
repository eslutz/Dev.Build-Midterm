using System;
using System.Collections.Generic;

namespace Midterm
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Movie> movieList = GenerateMovies();

			foreach(Movie x in movieList)
			{
				Console.WriteLine(x);
			}
		}
	
		//Generates a list of movies and returns the list.
		public static List<Movie> GenerateMovies()
		{
			List<Movie> movies = new List<Movie>();
			movies.Add(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			movies.Add(new Movie("The Matrix", MovieGenre.SciFi, "Wachowski Brothers", 1999, 136, new List<string> { "Keanu Reeves", "Laurence Fishburne", "Carrie-Anne Moss" }, "We're all living in a computer simulation."));
			movies.Add(new Movie("Die Hard", MovieGenre.Action, "John McTiernan", 1988, 132, new List<string> { "Bruce Willis" }, "Terrorists are going to get you at the office Christmas party."));
			movies.Add(new Movie("Evil Dead", MovieGenre.Horror, "Sam Raimi", 1981, 85, new List<string>() { "Bruce Campbell" }, "Deadites are going to get you at the cabin."));
			movies.Add(new Movie("Back to the Future", MovieGenre.Comedy, "Robert Zemeckis", 1985, 116, new List<string> { "Michael J. Fox", "Christopher Lloyd" }, "Go to the past to fix your parents."));
			movies.Add(new Movie("Bad Boys", MovieGenre.Action, "Michael Bay", 1995, 118, new List<string> { "Will Smith", "Martin Lawrence" }, "Two hip detectives protect a witness to a murder."));
			movies.Add(new Movie("Bad Santa", MovieGenre.Comedy, "Terry Zwigoff",  2003, 99, new List<string> { "Billy Bob Thornton", "Tony Cox" }, "The best Santa ever!"));
			movies.Add(new Movie("Bill & Ted's Excellent Adventure", MovieGenre.Comedy, "Stephen Herek", 1989, 89, new List<string> { "Keanu Reeves", "Alex Winter", "George Carlin" }, "Going to the past to pass a test."));
			movies.Add(new Movie("Blade Runner", MovieGenre.SciFi, "Ridley Scott", 1982, 117, new List<string> { "Harrison Ford", "Rutger Hauer" }, "Harrison Ford battles androids."));
			movies.Add(new Movie("The Blues Brothers", MovieGenre.Comedy, "John Landis", 1980, 157, new List<string> { "John Belushi", "Dan Aykroyd" }, "They're on a mission from god."));
			movies.Add(new Movie("Caddyshack", MovieGenre.Comedy, "Harold Ramis", 1980, 98, new List<string> { "Rodney Dangerfield", "Ted Knight", "Michael O'Keefe" } , "Htting balls all over the place."));
			movies.Add(new Movie("A Christmas Story", MovieGenre.Comedy, "Bob Clark", 1983, 93, new List<string> { "Peter Billingsley", "Darren McGavin", "Melinda Dillon" }, "The best Christmas movie ever."));
			movies.Add(new Movie("Dawn of the Dead", MovieGenre.Horror, "George A. Romero", 1978, 127, new List<string> { "Ken Foree", "Scott H.Reiniger", "Gaylen Ross" }, "Zombies are going to get you at the mall."));
			movies.Add(new Movie("Day of the Dead", MovieGenre.Horror, "George A. Romero", 1985, 96, new List<string> { "Lori Cardille", "Terry Alexander", "Joseph Pilato" }, "Zombies are going to get you at the underground bunker."));
			movies.Add(new Movie("Night of the Living Dead", MovieGenre.Horror, "George A. Romero", 1968, 88, new List<string> { "Duane Jones", "Judith O'Dea", "Karl Hardman" }, "Zombies are going to get you at night."));
			movies.Add(new Movie("Dawn of the Dead", MovieGenre.Horror, "Zack Snyder", 2004, 101, new List<string> { "Sarah Polley", "Ving Rhames", "Jake Weber", "Michael Kelly" }, "A good reboot of zombies are going to get you at the mall."));
			movies.Add(new Movie("Night of the Living Dead", MovieGenre.Horror, "Tom Savini", 1990, 92, new List<string> { "Tony Todd", "Patricia Tallman", "Tom Towles" }, "A good reboot of zombies are going to get you at night."));
			movies.Add(new Movie("Dirty Harry", MovieGenre.Thriller, "Don Siegel", 1971, 102, new List<string> { "Clint Eastwood" }, "Go ahead. Make my day."));
			movies.Add(new Movie("The Fifth Element", MovieGenre.SciFi, "Luc Besson", 1997, 125, new List<string> { "Bruce Willis", "Milla Jovovich", "Gary Oldman", "Chris Tucker" }, "Bruce Willis in space saving the world with a loud Chris Tucker."));
			movies.Add(new Movie("Fury", MovieGenre.Action, "David Ayer", 2014, 134, new List<string> { "Brad Pitt", "Shia LaBeouf", "Logan Lerman" }, "Brad Pitt in a tank."));
			movies.Add(new Movie("Gladiator", MovieGenre.Drama, "Ridley Scott", 2000, 155, new List<string> { "Russell Crowe", "Joaquin Phoenix" }, "Slicing and dicing everyone into tiny bits until he kills the Emporer."));
			movies.Add(new Movie("Hidden Figures", MovieGenre.Drama, "Theodore Melfi", 2016, 127, new List<string> { "Taraji P.Henson", "Octavia Spencer", "Janelle Monáe", "Kevin Costner" }, "A team of women in a vital role during the early years of NASA."));
			movies.Add(new Movie("Harold and Kumar Go to White Castle", MovieGenre.Comedy, "Danny Leiner", 2004, 88, new List<string> { "John Cho", "Kal Penn" }, "Mmmm White Castle."));
			movies.Add(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			movies.Add(new Movie("Indiana Jones and the Last Crusade", MovieGenre.Action, "Steven Spielberg", 1989, 126, new List<string> { "Harrison Ford", "Sean Connery" }, "Harisson Ford + Sean Connery = goodness."));
			movies.Add(new Movie("John Wick", MovieGenre.Action, "Chad Stahelski", 2014, 101, new List<string> { "Keanu Reeves" }, "They made the mistake of killing his dog."));
			movies.Add(new Movie("Joker", MovieGenre.Drama, "Todd Phillips", 2019, 121, new List<string> { "Joaquin Phoenix", "Robert De Niro" }, "Can you introduce me as Joker?"));
			movies.Add(new Movie("Jurassic Park", MovieGenre.Action, "Steven Spielberg", 1993, 126, new List<string> { "Sam Neill", "Laura Dern", "Jeff Goldblum" }, "Lets put dinosaurs in an amusement park!"));
			movies.Add(new Movie("The Martian", MovieGenre.SciFi, "Ridley Scott", 2015, 142, new List<string> { "Matt Damon" }, "Lets go rescue Matt Damon again; this time in space!"));
			movies.Add(new Movie("Napoleon Dynamite", MovieGenre.Comedy, "Jared Hess", 2004, 94, new List<string> { "Jon Heder", "Aaron Ruell", "Jon Gries", "Tina Majorino" }, "Knock it off, Napoleon! Make yourself a dang quesadilla!."));
			movies.Add(new Movie("Office Space", MovieGenre.Comedy, "Mike Judge", 1999, 89, new List<string> { "Ron Livingston", "David Herman", "Ajay Naidu"}, "PC Load Letter? What the fuck does that mean?"));
			movies.Add(new Movie("Outland", MovieGenre.SciFi, "Peter Hyams", 1981, 109, new List<string> { "Sean Connery" }, "A marshal at a mining colony on the Jupiter moon of Io, uncovers a drug-smuggling conspiracy."));
			movies.Add(new Movie("Predator", MovieGenre.SciFi, "John McTiernan", 1987, 106, new List<string> { "Arnold Schwarzenegger", "Carl Weathers", "Bill Duke" }, "A team of commandos in a jungle find themselves hunted by an alien."));
			movies.Add(new Movie("Robocop", MovieGenre.Action, "Paul Verhoeven", 1987, 103, new List<string> { "Peter Weller", "Nancy Allen", "Kurtwood Smith" }, "In a dystopian and crime-ridden Detroit, a robot cop rises."));
			movies.Add(new Movie("Scream", MovieGenre.Horror, "Wes Craven", 1996, 110, new List<string> { "Neve Campbell", "Courteney Cox", "David Arquette" }, "Killer on the loose slashing everyone up."));
			movies.Add(new Movie("Gran Torino", MovieGenre.Drama, "Clint Eastwood", 2009, 116, new List<string> { "Clint Eastwood", "Bee Vang", "Ahney Her" }, "A grumpy old man sits on his porch stirring up trouble."));
			movies.Add(new Movie("Contagion", MovieGenre.Thriller, "Steven Soderbergh", 2011, 106, new List<string> { "Laurence Fishburne", "Matt Damon", "Jude Law" }, "The world finds itself in the midst of a pandemic as the CDC works to find a cure."));
			movies.Add(new Movie("Outbreak", MovieGenre.Drama, "Wolfgang Petersen", 1995, 122, new List<string> { "Dustin Hoffman", "Rene Russo", "Cuba Gooding Jr." }, "Army doctors struggle to find a cure for a deadly virus spreading throughout a California town."));
			movies.Add(new Movie("Commando", MovieGenre.Action, "Mark L. Lester", 1985, 90, new List<string> { "Arnold Schwarzenegger", "Vernon Wells", "Bill Duke" }, "A movie where the dialogue consists of nothing but great one-liners."));
			movies.Add(new Movie("Terminator", MovieGenre.Action, "James Cameron", 1984, 107, new List<string> { "Arnold Schwarzenegger", "Linda Hamilton", "Michael Biehn" }, "A machine from the future travels to the past to kill a woman."));
			movies.Add(new Movie("Stargate", MovieGenre.SciFi, "Roland Emmerich", 1994, 121, new List<string> { "Kurt Russell", "James Spader" }, "We found an ancient ring buried in Egypt and now it take us to other planets."));
			movies.Add(new Movie("Starship Troopers", MovieGenre.SciFi, "Paul Verhoeven", 1997, 129, new List<string> { "Casper Van Dien", "Denise Richards", "Jake Busey"}, "Lets fight an interstellar war against bugs!"));
			movies.Add(new Movie("Slither", MovieGenre.Horror, "James Gunn", 2006, 95, new List<string> { "Nathan Fillion", "Elizabeth Banks", "Tania Saulnier" }, "Watch out for those space slugs!"));
			movies.Add(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			movies.Add(new Movie("Serenity", MovieGenre.SciFi, "Joss Whedon", 2005, 118, new List<string> { "Nathan Fillion", "Summer Glau", "Adam Baldwin" }, "I aim to misbehave."));
			movies.Add(new Movie("Shaun of the Dead", MovieGenre.Comedy, "Edgar Wright", 2004, 99, new List<string> { "Simon Pegg", "Nick Frost"}, "Zombies are going to get you in London."));
			return movies;
		}
	}
}