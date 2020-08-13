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
		public void EditMovieDirectorTest(string newDirector, bool expected)
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			
			Assert.Equal(expected, testMovie.EditMovie("director", newDirector));
		}

		[Fact]
		public void EditMovieRuntimeTest()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("runtime", "122");

			Assert.Equal(122, testMovie.Runtime);
		}

		[Fact]
		public void EditMovieYearTest1()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("year", "2017");

			Assert.Equal(2017, testMovie.ReleaseYear);
		}

		[Fact]
		public void EditMovieCastTest1()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("cast", "Michael Fassbender, Katherine Waterston, Billy Crudup");
			List<string> result = new List<string> { "Michael Fassbender", "Katherine Waterston", "Billy Crudup" };

			Assert.Equal(result, testMovie.Cast);
		}

		[Fact]
		public void EditMovieDescriptionTest1()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("description", "The crew of a colony ship discover an uncharted planet with a threat beyond their imagination.");

			Assert.Equal("The crew of a colony ship discover an uncharted planet with a threat beyond their imagination.", testMovie.Description);
		}
	}
}