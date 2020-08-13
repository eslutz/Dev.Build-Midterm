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
		[InlineData("Alien: Covenant")]
		[InlineData("aliencovenant")]
		[InlineData(@"Alien/\Covenant")]
		[InlineData("Alien: Covenant53")]
		[InlineData("")]
		public void EditMovieTitleTest(string newTitle)
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("title", newTitle);

			Assert.Equal(newTitle, testMovie.Title);
		}

		[Theory]
		[InlineData("Action", MovieGenre.Action)]
		[InlineData("action", MovieGenre.Action)]
		[InlineData("ACTION", MovieGenre.Action)]
		[InlineData("ACtiOn", MovieGenre.Action)]
		[InlineData("Drama", MovieGenre.Drama)]
		[InlineData("drama", MovieGenre.Drama)]
		[InlineData("DRAMA", MovieGenre.Drama)]
		[InlineData("dRAmA", MovieGenre.Drama)]
		[InlineData("Horror", MovieGenre.Horror)]
		[InlineData("horror", MovieGenre.Horror)]
		[InlineData("HORROR", MovieGenre.Horror)]
		[InlineData("HORror", MovieGenre.Horror)]
		public void EditMovieGenreTest(string newGenre, MovieGenre expectedgenre)
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("genre", newGenre);

			Assert.Equal(expectedgenre, testMovie.Genre);
		}

		[Fact]
		public void EditMovieDirectorTest()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("director", "Ridley Scott");

			Assert.Equal("Ridley Scott", testMovie.Director);
		}

		[Fact]
		public void EditMovieRuntimeTest()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("runtime", "122");

			Assert.Equal(122, testMovie.Runtime);
		}

		[Fact]
		public void EditMovieYearTest()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("year", "2017");

			Assert.Equal(2017, testMovie.ReleaseYear);
		}

		[Fact]
		public void EditMovieCastTest()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("cast", "Michael Fassbender, Katherine Waterston, Billy Crudup");
			List<string> result = new List<string> { "Michael Fassbender", "Katherine Waterston", "Billy Crudup" };

			Assert.Equal(result, testMovie.Cast);
		}

		[Fact]
		public void EditMovieDescriptionTest()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("description", "The crew of a colony ship discover an uncharted planet with a threat beyond their imagination.");

			Assert.Equal("The crew of a colony ship discover an uncharted planet with a threat beyond their imagination.", testMovie.Description);
		}
	}
}