using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
	public class MovieTheater
	{
		//Private field.
		private List<Movie> _movieList = new List<Movie>();

		//Methods
		public void AddMovie(Movie newMovie)
		{
			_movieList.Add(newMovie);
		}

		public int MovieCount()
		{
			return _movieList.Count;
		}

		public Movie GetMovie(int index)
		{
			return _movieList[index];
		}
	}
}
