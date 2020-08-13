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

		[Theory]
		[InlineData("Ridley Scott")]
		[InlineData("Ridley")]
		[InlineData(@"RIDLEY/ \scott")]
		[InlineData("sc0tt")]
		[InlineData("")]
		public void EditMovieDirectorTest(string newDirector)
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("director", newDirector);

			Assert.Equal(newDirector, testMovie.Director);
		}

		[Theory]
		[InlineData("122", 122)]
		[InlineData("10", 10)]
		[InlineData("100000", 100000)]
		[InlineData("1", 1)]
		[InlineData("0", 0)]
		public void EditMovieRuntimeTest(string newRuntime, int expected)
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("runtime", newRuntime);

			Assert.Equal(expected, testMovie.Runtime);
		}

		[Theory]
		[InlineData("2017", 2017)]
		[InlineData("1980", 1980)]
		[InlineData("1965", 1965)]
		[InlineData("2020", 2020)]
		[InlineData("1862", 1862)]
		public void EditMovieYearTest(string newYear, int expected)
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("year", newYear);

			Assert.Equal(expected, testMovie.ReleaseYear);
		}

		[Fact]
		public void EditMovieCastTest1()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("cast", "Fassbender, Waterston, Crudup");
			List<string> result = new List<string> { "Fassbender", "Waterston", "Crudup" };

			Assert.Equal(result, testMovie.Cast);
		}

		[Fact]
		public void EditMovieCastTest2()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("cast", "Michael, Katherine Waterston, Billy Ray Crudup");
			List<string> result = new List<string> { "Michael", "Katherine Waterston", "Billy Ray Crudup" };

			Assert.Equal(result, testMovie.Cast);
		}

		[Fact]
		public void EditMovieCastTest3()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("cast", "Michael Fassbender");
			List<string> result = new List<string> { "Michael Fassbender",};

			Assert.Equal(result, testMovie.Cast);
		}

		[Fact]
		public void EditMovieCastTest4()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("cast", "Michael Fassbender, Katherine Waterston");
			List<string> result = new List<string> { "Michael Fassbender", "Katherine Waterston"};

			Assert.Equal(result, testMovie.Cast);
		}

		[Fact]
		public void EditMovieCastTest5()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("cast", "MICHAEL fassbender, katherine WATERSTON, billy crudup");
			List<string> result = new List<string> { "MICHAEL fassbender", "katherine WATERSTON", "billy crudup" };

			Assert.Equal(result, testMovie.Cast);
		}

		[Theory]
		[InlineData("The crew of a colony ship discover an uncharted planet with a threat beyond their imagination.")]
		[InlineData("I can say whatever I want here.")]
		[InlineData(@"HI/ \there")]
		[InlineData("1234567890")]
		[InlineData("")]
		public void EditMovieDescriptionTest(string newDescription)
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("description", newDescription);

			Assert.Equal(newDescription, testMovie.Description);
		}
	}
}