using System.Collections.Generic;
using Xunit;

namespace Midterm.Test
{
	public class MovieTest
	{
		[Fact]
		public void ToStringOverrideTest()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			string result = "Aliens                                  |SciFi       |James Cameron       |137     |1986  |Sigourney Weaver, Michael Biehn, Bill Paxton, & Carrie Henn       |Aliens are going to get you in space.";

			Assert.Equal(result, testMovie.ToString());
		}

		[Theory]
		[InlineData("Alien: Covenant", true)]
		[InlineData("aliencovenant", true)]
		[InlineData(@"Alien/\Covenant", true)]
		[InlineData("Alien: Covenant53", true)]
		[InlineData("", false)]
		[InlineData(null, false)]
		public void EditMovieTitleTest(string newTitle, bool expected)
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");

			Assert.Equal(expected, testMovie.EditMovie("title", newTitle));
		}

		[Theory]
		[InlineData("Action", true)]
		[InlineData("action", true)]
		[InlineData("ACTION", true)]
		[InlineData("ACtiOn", true)]
		[InlineData("Horror", true)]
		[InlineData("horror", true)]
		[InlineData("HORROR", true)]
		[InlineData("HORror", true)]
		[InlineData("horor", false)]
		[InlineData("actin", false)]
		[InlineData("", false)]
		[InlineData(null, false)]
		public void EditMovieGenreTest(string newGenre, bool expected)
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			
			Assert.Equal(expected, testMovie.EditMovie("genre", newGenre));
		}


		[Theory]
		[InlineData("Ridley Scott", true)]
		[InlineData("ridley scott", true)]
		[InlineData(@"RIDLEY/\scott", true)]
		[InlineData("ridlEY53", true)]
		[InlineData("", false)]
		[InlineData(null, false)]
		public void EditMovieDirectorTest(string newDirector, bool expected)
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			
			Assert.Equal(expected, testMovie.EditMovie("director", newDirector));
		}

		[Theory]
		[InlineData("122", true)]
		[InlineData("10", true)]
		[InlineData("100000", true)]
		[InlineData("1", true)]
		[InlineData("0", false)]
		[InlineData("-100", false)]
		[InlineData("twothousand", false)]
		[InlineData("hello", false)]
		[InlineData("", false)]
		[InlineData(null, false)]
		public void EditMovieRuntimeTest(string newRuntime, bool expected)
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			
			Assert.Equal(expected, testMovie.EditMovie("runtime", newRuntime));
		}

		[Theory]
		[InlineData("2017", true)]
		[InlineData("1980", true)]
		[InlineData("1965", true)]
		[InlineData("2020", true)]
		[InlineData("0", false)]
		[InlineData("1862", false)]
		[InlineData("twothousand", false)]
		[InlineData("hello", false)]
		[InlineData("", false)]
		[InlineData(null, false)]
		public void EditMovieYearTest(string newYear, bool expected)
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");

			Assert.Equal(expected, testMovie.EditMovie("year", newYear));
		}

		[Theory]
		[InlineData("Michael Fassbender, Katherine Waterston, Billy Crudup", true)]
		[InlineData("Fassbender, Waterston, Crudup", true)]
		[InlineData("Michael, Katherine Waterston, Billy Ray Crudup", false)]
		[InlineData("Michael Fassbender", true)]
		[InlineData("Michael Fassbender, Katherine Waterston", true)]
		[InlineData("MICHAEL fassbender, katherine WATERSTON, billy crudup", true)]
		[InlineData("Michael Fassbender Katherine Waterston", false)]
		[InlineData("Michael Fassbender, @Katherine Waterston", false)]
		[InlineData("Michael Fassbender Katherine Waterston3", false)]
		[InlineData("Michael-Fassbender Katherine Waterston", false)]
		[InlineData("", false)]
		[InlineData(null, false)]
		public void EditMovieCastTest(string newCast, bool expected)
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");

			Assert.Equal(expected, testMovie.EditMovie("cast", newCast));
		}

		[Theory]
		[InlineData("The crew of a colony ship discover an uncharted planet with a threat beyond their imagination.", true)]
		[InlineData("I can say whatever I want here.", true)]
		[InlineData(@"HI/ \there", true)]
		[InlineData("1234567890", true)]
		[InlineData("", false)]
		[InlineData(null, false)]
		public void EditMovieDescriptionTest(string newDescription, bool expected)
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			
			Assert.Equal(expected, testMovie.EditMovie("description", newDescription));
		}
	}
}