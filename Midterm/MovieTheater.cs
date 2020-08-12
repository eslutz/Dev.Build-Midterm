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
			return _movieList[index-1];
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

		public List<Movie> SearchMovies(string searchField, string searchCriteria)
		{
			List<Movie> foundMovies = new List<Movie>();
			switch (searchField)
			{
				case "title":
					foundMovies = _movieList.FindAll(x => x.Title.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase));
					break;
				case "genre":
					foundMovies = _movieList.FindAll(x => x.Genre.Equals((MovieGenre)Enum.Parse(typeof(MovieGenre), searchCriteria, true)));
					break;
				case "director":
					foundMovies = _movieList.FindAll(x => x.Director.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase));
					break;
				case "runtime":
					foundMovies = _movieList.FindAll(x => x.Runtime.Equals(int.Parse(searchCriteria)));
					break;
				case "year":
					foundMovies = _movieList.FindAll(x => x.ReleaseYear.Equals(int.Parse(searchCriteria)));
					break;
				case "cast":
					foundMovies = _movieList.FindAll(x => x.Cast.Any(x => x.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase)));
					break;
			}

			return foundMovies;
		}
	}
}
