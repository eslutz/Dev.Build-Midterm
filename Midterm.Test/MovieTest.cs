using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Midterm.Test
{
	public class MovieTest
	{
		[Fact]
		public void AddMovieTest()
		{
			Movie.AddMovie(new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space."));

			Assert.NotEmpty(Movie.MovieList);
		}

		[Fact]
		public void ToStringOverrideTest()
		{
			Movie testMovie = new Movie("Aliens", MovieGenre.SciFi, "James Cameron", 1986, 137, new List<string> { "Sigourney Weaver", "Michael Biehn", "Bill Paxton", "Carrie Henn" }, "Aliens are going to get you in space.");
			string result = "Aliens                                  SciFi       James Cameron       1986  137   Sigourney Weaver, Michael Biehn, Bill Paxton, & Carrie Henn       Aliens are going to get you in space.";

			Assert.Equal(result, testMovie.ToString());
		}
	}
}
