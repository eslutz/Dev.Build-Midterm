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

		[Fact]
		public void EditMovieTest1()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("title", "Alien: Covenant");

			Assert.Equal("Alien: Covenant", testMovie.Title);
		}

		[Fact]
		public void EditMovieTest2()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("genre", "thriller");

			Assert.Equal(MovieGenre.Thriller, testMovie.Genre);
		}

		[Fact]
		public void EditMovieTest3()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("director", "Ridley Scott");

			Assert.Equal("Ridley Scott", testMovie.Director);
		}

		[Fact]
		public void EditMovieTest4()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("runtime", "122");

			Assert.Equal(122, testMovie.Runtime);
		}

		[Fact]
		public void EditMovieTest5()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("year", "2017");

			Assert.Equal(2017, testMovie.ReleaseYear);
		}

		[Fact]
		public void EditMovieTest6()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("cast", "Michael Fassbender, Katherine Waterston, Billy Crudup");
			List<string> result = new List<string> { "Michael Fassbender", "Katherine Waterston", "Billy Crudup" };

			Assert.Equal(result, testMovie.Cast);
		}

		[Fact]
		public void EditMovieTest7()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			testMovie.EditMovie("description", "The crew of a colony ship discover an uncharted planet with a threat beyond their imagination.");

			Assert.Equal("The crew of a colony ship discover an uncharted planet with a threat beyond their imagination.", testMovie.Description);
		}
	}
}