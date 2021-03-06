using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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

		//Returns true if a movie title already exists in the list.
		public bool ContainsMovie(string title)
		{


			if (_movieList.Any(x => x.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))
			{
				return true;
			}
			else
			{
				return false;
			}
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
				default:
					break;
			}
		}

		//Search title.  Returns false if invalid search criteria or no results found.  Otherwise, returns true.  Outputs results to a list.
		public bool SearchMovieTitle(string searchCriteria, out List<Movie> searchResults)
		{
			bool found;
			if (string.IsNullOrEmpty(searchCriteria))
			{
				searchResults = new List<Movie>();
				found = false;
			}
			else
			{
				searchResults = _movieList.FindAll(x => x.Title.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase));
				found = true;
			}
			return found;
		}

		//Search genre.  Returns false if invalid search criteria.  Otherwise, returns true.  Outputs results to a list, empyty if nothing found.
		public bool SearchMovieGenre(string searchCriteria, out List<Movie> searchResults)
		{
			bool found;
			if (Enum.TryParse(typeof(MovieGenre), searchCriteria, true, out object convertedValue))
			{
				searchResults = _movieList.FindAll(x => x.Genre.Equals((MovieGenre)convertedValue));
				found = true;
			}
			else
			{
				searchResults = new List<Movie>();
				found = false;
			}
			return found;
		}

		//Search director.  Returns false if invalid search criteria or no results found.  Otherwise, returns true.  Outputs results to a list, empyty if nothing found.
		public bool SearchMovieDirector(string searchCriteria, out List<Movie> searchResults)
		{
			bool found;
			if (string.IsNullOrEmpty(searchCriteria))
			{
				searchResults = new List<Movie>();
				found = false;
			}
			else
			{
				searchResults = _movieList.FindAll(x => x.Director.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase));
				found = true;
			}
			return found;
		}

		//Search runtime.  Returns false if invalid search criteria or no results found.  Otherwise, returns true.  Outputs results to a list, empyty if nothing found.
		public bool SearchMovieRuntime(string searchCriteria, out List<Movie> searchResults)
		{
			bool found;
			if (int.TryParse(searchCriteria, out int convertedRuntime) && convertedRuntime > 0)
			{
				searchResults = _movieList.FindAll(x => x.Runtime.Equals(convertedRuntime));
				found = true;
			}
			else
			{
				searchResults = new List<Movie>();
				found = false;
			}
			return found;
		}

		//Search release year.  Returns false if invalid search criteria or no results found.  Otherwise, returns true.  Outputs results to a list, empyty if nothing found.
		public bool SearchMovieYear(string searchCriteria, out List<Movie> searchResults)
		{
			bool found;
			if (int.TryParse(searchCriteria, out int convertedYear) && (convertedYear > 1885 && convertedYear <= DateTime.Now.Year))
			{
				searchResults = _movieList.FindAll(x => x.ReleaseYear.Equals(convertedYear));
				found = true;
			}
			else
			{
				searchResults = new List<Movie>();
				found = false;
			}
			return found;
		}

		//Search cast.  Returns false if invalid search criteria or no results found.  Otherwise, returns true.  Outputs results to a list, empyty if nothing found.
		public bool SearchMovieCast(string searchCriteria, out List<Movie> searchResults)
		{
			bool found;
			if (string.IsNullOrEmpty(searchCriteria))
			{
				searchResults = new List<Movie>();
				found = false;
			}
			else
			{
				searchResults = _movieList.FindAll(x => x.Cast.Any(x => x.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase)));
				found = true;
			}
			return found;
		}
	}
}