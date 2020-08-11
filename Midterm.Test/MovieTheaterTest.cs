using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Midterm.Test
{
	public class MovieTheaterTest
	{
		[Fact]
		public void AddMovieTest1()
		{
			MovieTheater test = new MovieTheater();

			Assert.True(test.MovieCount() == 0);
		}

		[Fact]
		public void AddMovieTest2()
		{
			MovieTheater test = new MovieTheater();
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));

			Assert.True(test.MovieCount() != 0);
		}

		[Fact]
		public void GetMovieTest()
		{
			MovieTheater test = new MovieTheater();
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));

			Assert.IsType<Movie>(test.GetMovie(0));
		}

		[Fact]
		public void RemoveMovieTest()
		{
			MovieTheater test = new MovieTheater();
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			test.RemoveMovie(0);
			
			Assert.Equal(0, test.MovieCount());
		}

		[Fact]
		public void SortMoviesTest1()
		{
			MovieTheater test = new MovieTheater();
			Movie firstSortedMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(firstSortedMovie);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			test.SortMovies("title");

			Assert.True(test.GetMovie(0) == firstSortedMovie);
		}

		[Fact]
		public void SortMoviesTest2()
		{
			MovieTheater test = new MovieTheater();
			Movie firstSortedMovie = new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in.");
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			test.AddMovie(firstSortedMovie);
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			test.SortMovies("genre");

			Assert.True(test.GetMovie(0) == firstSortedMovie);
		}

		[Fact]
		public void SortMoviesTest3()
		{
			MovieTheater test = new MovieTheater();
			Movie firstSortedMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(firstSortedMovie);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			test.SortMovies("director");

			Assert.True(test.GetMovie(0) == firstSortedMovie);
		}

		[Fact]
		public void SortMoviesTest4()
		{
			MovieTheater test = new MovieTheater();
			Movie firstSortedMovie = new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in.");
			test.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));
			test.AddMovie(firstSortedMovie);
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			test.SortMovies("runtime");

			Assert.True(test.GetMovie(0) == firstSortedMovie);
		}

		[Fact]
		public void SortMoviesTest5()
		{
			MovieTheater test = new MovieTheater();
			Movie firstSortedMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			test.AddMovie(firstSortedMovie);
			test.AddMovie(new Movie("Idiocracy", MovieGenre.Documentary, "Mike Judge", 2007, 84, new List<string> { "Luke Wilson", "Maya Rudolph", "Dax Shepard", "Terry Crews" }, "The world we live in."));
			test.AddMovie(new Movie("Ronin", MovieGenre.Thriller, "John Frankenheimer", 1998, 121, new List<string> { "Robert De Niro", "Jean Reno", "Natascha McElhone" }, "Fight over a mysterious package with great car chases in Europe."));
			test.SortMovies("year");

			Assert.True(test.GetMovie(0) == firstSortedMovie);
		}
	}
}
