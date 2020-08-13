using System;
using System.Collections.Generic;
using System.Linq;

namespace Midterm
{
	public class MovieCatalog
	{
		//Private field
		private List<Movie> _movieList = new List<Movie>();

		//Methods
		//Adds the passed movie to the list.
		public void AddMovie(Movie newMovie)
		{
			_movieList.Add(newMovie);
		}

		//Removes the movies at the passed index minus one to convert to a zero based index.
		public void RemoveMovie(int index)
		{
			_movieList.RemoveAt(index - 1);
		}

		//Returns a count of the number of movies in the list.
		public int MovieCount()
		{
			return _movieList.Count;
		}

		//Returns a movie at passed index minus one to convert to a zero based index.
		public Movie GetMovie(int index)
		{
			return _movieList[index - 1];
		}

		//Sorts the list of movies based on the passed argument.  All input validated before calling the method.
		public void SortMovies(string sortField)
		{
			switch (sortField)
			{
				//Sorts movies based on title.
				case "title":
					_movieList = _movieList.OrderBy(movie => movie.Title).ToList();
					break;
				//Sorts movies based on genre.
				case "genre":
					_movieList = _movieList.OrderBy(movie => movie.Genre).ToList();
					break;
				//Sorts movies based on director.
				case "director":
					_movieList = _movieList.OrderBy(movie => movie.Director).ToList();
					break;
				//Sorts movies based on runtime.
				case "runtime":
					_movieList = _movieList.OrderBy(movie => movie.Runtime).ToList();
					break;
				//Sorts movies based on release year.
				case "year":
					_movieList = _movieList.OrderBy(movie => movie.ReleaseYear).ToList();
					break;
			}
		}

		//Searches the list of movies based on the passed arguments and returns a list of the results.  All input validated before calling the method.
		public List<Movie> SearchMovies(string searchField, string searchCriteria)
		{
			List<Movie> foundMovies = new List<Movie>();
			switch (searchField)
			{
				//Finds movies with the matching full title, or contains a partial title, or matching letters.
				case "title":
					foundMovies = _movieList.FindAll(x => x.Title.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase));
					break;
				//Finds movies that match the genre that is passed.  Parses the argument string into a matching MovieGenre enum value for searching.
				case "genre":
					foundMovies = _movieList.FindAll(x => x.Genre.Equals((MovieGenre)Enum.Parse(typeof(MovieGenre), searchCriteria, true)));
					break;
				//Finds director with the matching full name, or contains a partial name, or matching letters.
				case "director":
					foundMovies = _movieList.FindAll(x => x.Director.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase));
					break;
				//Finds movies with runtime that matches the argument.
				case "runtime":
					foundMovies = _movieList.FindAll(x => x.Runtime.Equals(int.Parse(searchCriteria)));
					break;
				//Finds movies with a release year that matches the argument.  
				case "year":
					foundMovies = _movieList.FindAll(x => x.ReleaseYear.Equals(int.Parse(searchCriteria)));
					break;
				//Finds movies with a cast member that matches a full name, a partial name, or matching letters.
				case "cast":
					foundMovies = _movieList.FindAll(x => x.Cast.Any(x => x.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase)));
					break;
			}
			return foundMovies;
		}
	}
}