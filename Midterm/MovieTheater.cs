using System;
using System.Collections.Generic;
using System.Linq;
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

		public void RemoveMovie(int index)
		{
			_movieList.RemoveAt(index-1);
		}

		public int MovieCount()
		{
			return _movieList.Count;
		}

		public Movie GetMovie(int index)
		{
			return _movieList[index];
		}

		public void SortMovies(string sortField)
		{
			switch (sortField)
			{
				case "title":
					_movieList = _movieList.OrderBy(movie => movie.Title).ToList();
					break;
				case "genre":
					_movieList = _movieList.OrderBy(movie => movie.Genre).ToList();
					break;
				case "director":
					_movieList = _movieList.OrderBy(movie => movie.Director).ToList();
					break;
				case "runtime":
					_movieList = _movieList.OrderBy(movie => movie.Runtime).ToList();
					break;
				case "year":
					_movieList = _movieList.OrderBy(movie => movie.ReleaseYear).ToList();
					break;
			}
		}
	}
}
