using System.Collections.Generic;
using Xunit;

namespace Midterm.Test
{
	public class MovieCatalogTest
	{
		[Fact]
		public void AddMovieTest()
		{
			MovieCatalog test = new MovieCatalog();
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));

			Assert.True(test.MovieCount() != 0);
		}

		[Fact]
		public void RemoveMovieTest()
		{
			MovieCatalog test = new MovieCatalog();
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			test.RemoveMovie(1);

			Assert.Equal(0, test.MovieCount());
		}

		[Fact]
		public void MovieCountTest()
		{
			MovieCatalog test = new MovieCatalog();
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));

			Assert.Equal(3, test.MovieCount());
		}

		[Fact]
		public void GetMovieTest()
		{
			MovieCatalog test = new MovieCatalog();
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));

			Assert.IsType<Movie>(test.GetMovie(1));
		}

		[Fact]
		public void SortMoviesTest1()
		{
			MovieCatalog test = new MovieCatalog();
			Movie firstSortedMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(firstSortedMovie);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			test.SortMovies("title");

			Assert.True(test.GetMovie(1) == firstSortedMovie);
		}

		[Fact]
		public void SortMoviesTest2()
		{
			MovieCatalog test = new MovieCatalog();
			Movie firstSortedMovie = new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in.");
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			test.AddMovie(firstSortedMovie);
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			test.SortMovies("genre");

			Assert.True(test.GetMovie(1) == firstSortedMovie);
		}

		[Fact]
		public void SortMoviesTest3()
		{
			MovieCatalog test = new MovieCatalog();
			Movie firstSortedMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(firstSortedMovie);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			test.SortMovies("director");

			Assert.True(test.GetMovie(1) == firstSortedMovie);
		}

		[Fact]
		public void SortMoviesTest4()
		{
			MovieCatalog test = new MovieCatalog();
			Movie firstSortedMovie = new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in.");
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			test.AddMovie(firstSortedMovie);
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			test.SortMovies("runtime");

			Assert.True(test.GetMovie(1) == firstSortedMovie);
		}

		[Fact]
		public void SortMoviesTest5()
		{
			MovieCatalog test = new MovieCatalog();
			Movie firstSortedMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(firstSortedMovie);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			test.SortMovies("year");

			Assert.True(test.GetMovie(1) == firstSortedMovie);
		}

		[Theory]
		[InlineData("Aliens", true)]
		[InlineData("a", true)]
		[InlineData("aliens", true)]
		[InlineData("Alien", true)]
		[InlineData("ALIEN", true)]
		[InlineData("asdf", true)]
		[InlineData("", false)]
		[InlineData(null, false)]
		public void SearchMovieTitleTest(string searchCriteria, bool expected)
		{
			MovieCatalog test = new MovieCatalog();
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));

			Assert.Equal(expected, test.SearchMovieTitle(searchCriteria, out List<Movie> results));
		}

		[Theory]
		[InlineData("Action", true)]
		[InlineData("action", true)]
		[InlineData("ACTION", true)]
		[InlineData("ACtiOn", true)]
		[InlineData("horror", true)]
		[InlineData("HORROR", true)]
		[InlineData("horor", false)]
		[InlineData("actin", false)]
		[InlineData("", false)]
		[InlineData(null, false)]
		public void SearchMovieGenreTest(string searchCriteria, bool expected)
		{
			MovieCatalog test = new MovieCatalog();
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Action, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));

			Assert.Equal(expected, test.SearchMovieGenre(searchCriteria, out List<Movie> results));
		}

		[Theory]
		[InlineData("James Cameron", true)]
		[InlineData("james cameron", true)]
		[InlineData("James", true)]
		[InlineData("Cameron", true)]
		[InlineData("ridlEY53", true)]
		[InlineData("", false)]
		[InlineData(null, false)]
		public void SearchMovieDirectorTest(string searchCriteria, bool expected)
		{
			MovieCatalog test = new MovieCatalog();
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Action, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));

			Assert.Equal(expected, test.SearchMovieDirector(searchCriteria, out List<Movie> results));
		}

		[Theory]
		[InlineData("121", true)]
		[InlineData("10", true)]
		[InlineData("100000", true)]
		[InlineData("137", true)]
		[InlineData("0", false)]
		[InlineData("-100", false)]
		[InlineData("twothousand", false)]
		[InlineData("", false)]
		[InlineData(null, false)]
		public void SearchMovieRuntimeTest(string searchCriteria, bool expected)
		{
			MovieCatalog test = new MovieCatalog();
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Action, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));

			Assert.Equal(expected, test.SearchMovieRuntime(searchCriteria, out List<Movie> results));
		}

		[Theory]
		[InlineData("2017", true)]
		[InlineData("1986", true)]
		[InlineData("1965", true)]
		[InlineData("2007", true)]
		[InlineData("0", false)]
		[InlineData("1862", false)]
		[InlineData("twothousand", false)]
		[InlineData("", false)]
		[InlineData(null, false)]
		public void SearchMovieYearTest(string searchCriteria, bool expected)
		{
			MovieCatalog test = new MovieCatalog();
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Action, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));

			Assert.Equal(expected, test.SearchMovieYear(searchCriteria, out List<Movie> results));
		}

		[Theory]
		[InlineData("Sigourney Weaver", true)]
		[InlineData("sigourney weaver", true)]
		[InlineData("Sigourney", true)]
		[InlineData("Weaver", true)]
		[InlineData("W", true)]
		[InlineData("Scott", true)]
		[InlineData("", false)]
		[InlineData(null, false)]
		public void SearchMovieCastTest(string searchCriteria, bool expected)
		{
			MovieCatalog test = new MovieCatalog();
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Action, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));

			Assert.Equal(expected, test.SearchMovieCast(searchCriteria, out List<Movie> results));
		}

		[Theory]
		[InlineData("Aliens", true)]
		[InlineData("aliens", true)]
		[InlineData("ALIENS", true)]
		[InlineData("Alien", false)]
		[InlineData("", false)]
		[InlineData(null, false)]
		public void ContainsMovieTest(string title, bool expected)
		{
			MovieCatalog test = new MovieCatalog();
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));

			Assert.Equal(expected, test.ContainsMovie(title));
		}

	}
}