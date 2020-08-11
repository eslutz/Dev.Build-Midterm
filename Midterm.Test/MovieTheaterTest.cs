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

	}
}
