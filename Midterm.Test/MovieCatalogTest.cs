using System.Collections.Generic;
using Xunit;

namespace Midterm.Test
{
	public class MovieCatalogTest
	{
		[Fact]
		public void AddMovieTest1()
		{
			MovieCatalog test = new MovieCatalog();

			Assert.True(test.MovieCount() == 0);
		}

		[Fact]
		public void AddMovieTest2()
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

		public static MovieCatalog expected = new MovieCatalog();

		[Fact]
		public void SearchMoviesTitleTest1()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("title", "Alien"));
		}

		[Fact]
		public void SearchMoviesTitleTest2()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("title", "alien"));
		}

		[Fact]
		public void SearchMoviesTitleTest3()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("title", "al"));
		}

		[Fact]
		public void SearchMoviesGenreTest1()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("genre", "SciFi"));
		}

		[Fact]
		public void SearchMoviesGenreTest2()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("genre", "scifi"));
		}

		[Fact]
		public void SearchMoviesDirectorTest1()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("director", "James"));
		}

		[Fact]
		public void SearchMoviesDirectorTest2()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("director", "james"));
		}

		[Fact]
		public void SearchMoviesDirectorTest3()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("director", "Cameron"));
		}

		[Fact]
		public void SearchMoviesDirectorTest4()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("director", "James Cameron"));
		}

		[Fact]
		public void SearchMoviesDirectorTest5()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult1 = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			Movie movieSearchResult2 = new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe.");
			test.AddMovie(movieSearchResult1);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Fudge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(movieSearchResult2);
			List<Movie> expected = new List<Movie> { movieSearchResult1, movieSearchResult2 };

			Assert.Equal(expected, test.SearchMovies("director", "J"));
		}

		[Fact]
		public void SearchMoviesRuntimeTest()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("runtime", "137"));
		}

		[Fact]
		public void SearchMoviesYearTest()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("year", "1986"));
		}

		[Fact]
		public void SearchMoviesCastTest1()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("cast", "Sigourney Weaver"));
		}

		[Fact]
		public void SearchMoviesCastTest2()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("cast", "sigourney weaver"));
		}

		[Fact]
		public void SearchMoviesCastTest3()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("cast", "Sigourney"));
		}

		[Fact]
		public void SearchMoviesCastTest4()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(movieSearchResult);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult };

			Assert.Equal(expected, test.SearchMovies("cast", "Weaver"));
		}

		[Fact]
		public void SearchMoviesCastTest5()
		{
			MovieCatalog test = new MovieCatalog();
			Movie movieSearchResult1 = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			Movie movieSearchResult2 = new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in.");
			test.AddMovie(movieSearchResult1);
			test.AddMovie(movieSearchResult2);
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			List<Movie> expected = new List<Movie> { movieSearchResult1, movieSearchResult2 };

			Assert.Equal(expected, test.SearchMovies("cast", "W"));
		}
	}
}